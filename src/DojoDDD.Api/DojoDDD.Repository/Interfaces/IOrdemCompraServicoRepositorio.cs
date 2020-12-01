using System.Threading.Tasks;

namespace DojoDDD.Repository.Interfaces
{
    public interface IOrdemCompraServicoRepositorio
    {
        Task<bool> AlterarStatudOrdemDeCompraParaEmAnalise(string ordemDeCompraId);
        Task<string> RegistrarOrdemCompra(string clienteId, int produtoId, int quantidadeCompra);
    }
}