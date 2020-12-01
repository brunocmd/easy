using System.Collections.Generic;
using System.Threading.Tasks;
using DojoDDD.Model.Models;
//todo: inteface para business
namespace DojoDDD.Business.Interfaces
{
    public interface IClienteBusiness
    {
        Task<Cliente> ConsultarPorId(string id);
        Task<IEnumerable<Cliente>> ConsultarTodosCliente();
    }
}
