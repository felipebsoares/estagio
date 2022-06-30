namespace API.Models
{
    public class Cliente
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public int Id { get; set; }
        public Cliente(string nome, int idade, int id)
        {
            this.Nome = nome;
            this.Idade = idade;
            this.Id = id;
        }
        
    }
}