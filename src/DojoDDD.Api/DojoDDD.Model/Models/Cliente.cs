namespace DojoDDD.Model.Models
{
    public class Cliente
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int Idade { get; set; }
        public decimal Saldo { get; set; } //todo: Esse campo não faz parte do domino de cliente
    }
}