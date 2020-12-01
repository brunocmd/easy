using System.Threading.Tasks;
using DojoDDD.Model.Models.Ordem;
using DojoDDD.Model.Enums;

namespace DojoDDD.Business.Interfaces
{
    public interface IOrdemCompraBusiness
    {
        Task<string> RegistrarOrdemCompra(OrdemCompra ordemCompra);
        Task<bool> AlterarOrdemCompra(string ordemId, OrdemCompraStatus novoOrdemCompraStatus);
        Task<string> ConsultarPorId(string id);

        Task<bool> AlterarStatudOrdemDeCompraParaEmAnalise(string ordemDeCompraId);
        Task<string> RegistrarOrdemCompra(string clienteId, int produtoId, int quantidadeCompra);
    }
}
