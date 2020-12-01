using System.Threading.Tasks;
using DojoDDD.Model.Models.Ordem;
using DojoDDD.Model.Enums;

namespace DojoDDD.Repository.Interfaces
{
    public interface IOrdemCompraRepositorio
    {
        Task<string> RegistrarOrdemCompra(OrdemCompra ordemCompra);
        Task<bool> AlterarOrdemCompra(string ordemId, OrdemCompraStatus novoOrdemCompraStatus);
        Task<string> ConsultarPorId(string id);
    }
}