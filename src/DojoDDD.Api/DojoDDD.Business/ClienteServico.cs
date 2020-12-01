using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DojoDDD.Business.Interfaces;
using DojoDDD.Model.Models;

namespace DojoDDD.Business
{
    public class ClienteServico: IClienteBusiness
    {
        public async Task<Cliente> ConsultarPorId(string id)
        {
            return new Cliente();
        }
        public async Task<IEnumerable<Cliente>> ConsultarTodosCliente()
        {
            return new List<Cliente>();
        }
    }
}
