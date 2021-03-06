﻿using System;
using DojoDDD.Model.Enums;

namespace DojoDDD.Model.Models.ViewModels
{
    public class OrdemCompraViewModel
    {
        public OrdemCompraViewModel()
        {
            Status = OrdemCompraStatus.Solicitado;
        }

        public string Id { get; } = Guid.NewGuid().ToString();

        public DateTime DataOperacao { get; set; }
        public int ProdutoId { get; set; }
        public string ClienteId { get; set; }
        public int QuantidadeSolicitada { get; set; }
        public decimal ValorOperacao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public OrdemCompraStatus Status { get; set; }
    }
}