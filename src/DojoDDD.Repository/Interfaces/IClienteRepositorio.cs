using System.Collections.Generic;
using System.Threading.Tasks;
using DojoDDD.Model.Models;

namespace DojoDDD.Repository.Interfaces
{
    public interface IClienteRepositorio
    {
        Task<Cliente> ConsultarPorId(string id);
        Task<IEnumerable<Cliente>> ConsultarTodosCliente();
    }
}