using System.Collections.Generic;
using System.Threading.Tasks;
using DojoDDD.Model.Models;

namespace DojoDDD.Repository.Interfaces
{
    public interface IProdutoRepositorio
    {
        Task<Produto> ConsultarPorId(int id);
        Task<IEnumerable<Produto>> Consultar();
    }
}