using System.Collections.Generic;
using System.Threading.Tasks;
using DojoDDD.Model.Models;

namespace DojoDDD.Business.Interfaces
{
    public interface IProdutoBusiness
    {
        Task<Produto> ConsultarPorId(int id);
        Task<IEnumerable<Produto>> Consultar();
    }
}
