using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DojoDDD.Business.Interfaces;
using DojoDDD.Model.Models;

namespace DojoDDD.Business
{
    public class ProdutoServico: IProdutoBusiness
    {
        public async Task<Produto> ConsultarPorId(int id) {
            
            return new Produto();
        }
        public async Task<IEnumerable<Produto>> Consultar() {
            return new List<Produto>();

        }
    }
}
