using System;
using System.Threading.Tasks;
using DojoDDD.Business.Interfaces;
using DojoDDD.Model.Models.Ordem;
using DojoDDD.Model.Enums;
using DojoDDD.Repository.Interfaces;
using DojoDDD.Repository;

namespace DojoDDD.Business
{
    public class OrdemCompraServico : IOrdemCompraBusiness
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IOrdemCompraRepositorio _ordemCompraRepositorio;
        private readonly DataStore _dataStore;

        public OrdemCompraServico(IClienteRepositorio clienteRepositorio,
                                  IProdutoRepositorio produtoRepositorio,
                                  IOrdemCompraRepositorio ordemCompraRepositorio,
                                  DataStore dataStore)
        {
            _clienteRepositorio = clienteRepositorio;
            _produtoRepositorio = produtoRepositorio;
            _ordemCompraRepositorio = ordemCompraRepositorio;
            _dataStore = dataStore;
        }

        public async Task<string> RegistrarOrdemCompra(string clienteId, int produtoId, int quantidadeCompra)
        {
            var cliente = await _clienteRepositorio.ConsultarPorId(clienteId).ConfigureAwait(false);
            var produto = await _produtoRepositorio.ConsultarPorId(produtoId).ConfigureAwait(false);

            if (quantidadeCompra <= 0)
                throw new InvalidOperationException("Quantidade solicitada não suficiente para compra.");

            if (produto.Estoque <= 0)
                throw new InvalidOperationException("Quantidade em estoque não suficiente para compra.");

            var valorOperacao = Math.Round(decimal.Parse(produto.PrecoUnitario) * quantidadeCompra, 2);
            if (valorOperacao > cliente.Saldo)
                throw new InvalidOperationException("Cliente não possui saldo suficiente para compra.");

            if (Math.Round(quantidadeCompra * decimal.Parse(produto.PrecoUnitario), 2) < produto.ValorMinimoDeCompra)
                throw new InvalidOperationException("Quantidade mínima não atendida para compra.");

            if (valorOperacao > produto.Estoque)
                throw new InvalidOperationException("Quantidade em estoque não suficiente para compra.");

            var novaOrdemDeCompra = new OrdemCompra
            {
                ClienteId = cliente.Id,
                ProdutoId = produto.Id,
                DataOperacao = DateTime.Now,
                PrecoUnitario = decimal.Parse(produto.PrecoUnitario),
                ValorOperacao = valorOperacao,
                QuantidadeSolicitada = quantidadeCompra
            };

            return await _ordemCompraRepositorio.RegistrarOrdemCompra(novaOrdemDeCompra).ConfigureAwait(false);
        }

        public async Task<bool> AlterarStatudOrdemDeCompraParaEmAnalise(string ordemDeCompraId)
        {
            var ordemDeCompra = await _ordemCompraRepositorio.ConsultarPorId(ordemDeCompraId).ConfigureAwait(false);
            if (string.IsNullOrEmpty(ordemDeCompra))
                throw new InvalidOperationException("");

            try
            {
                await _ordemCompraRepositorio.AlterarOrdemCompra(ordemDeCompra, OrdemCompraStatus.EmAnalise).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }

            return true;
        }

        public Task<bool> AlterarOrdemCompra(OrdemCompra ordemCompra)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AlterarOrdemCompra(string ordemId, OrdemCompraStatus novoOrdemCompraStatus)
        {
            throw new NotImplementedException();
        }

        public async Task<string> ConsultarPorId(string id)
        {
            var ordemCompra = await Task.FromResult(_dataStore.OrdensCompras.Find(x => x.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase))).ConfigureAwait(false);
            return ordemCompra.Id;
        }

        public async Task<string> RegistrarOrdemCompra(OrdemCompra ordemCompra)
        {
            await Task.Run(() => _dataStore.OrdensCompras.Add(ordemCompra)).ConfigureAwait(false);
            return ordemCompra.Id;
        }
    }
}