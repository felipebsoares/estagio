using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClientesController : ControllerBase
    {
        private static List<Cliente> clientes = new List<Cliente>();
        private readonly DataContext context;

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> MostrarClientes(){
            return Ok(await this.context.Clientes.ToListAsync());
        }


        [HttpPost]
        public async Task<ActionResult<List<Cliente>>> AdicionarCliente(string nome, int idade, int id) {
            
            context.Clientes.Add(new Cliente(nome, idade, id));
            await this.context.SaveChangesAsync();
            return Ok(await this.context.Clientes.ToListAsync());
        }

        
        [HttpDelete]
         public async Task<ActionResult<List<Cliente>>> Deletar(int id) 
         {
            var dbcliente = await this.context.Clientes.FindAsync(id);
            if (dbcliente == null) return BadRequest("Cliente não encontrado!");
            this.context.Clientes.Remove(dbcliente);
            await this.context.SaveChangesAsync();


            return Ok(await this.context.Clientes.ToListAsync());
         }
        [HttpPut]
        public async Task<ActionResult<List<Cliente>>> AtualizarCliente(Cliente novo) {
            var dbcliente = await this.context.Clientes.FindAsync(novo.Id);
            if (dbcliente == null) return BadRequest("Cliente não encontrado!");

            
            dbcliente.Nome = novo.Nome;
            dbcliente.Idade = novo.Idade;
            dbcliente.Id = novo.Id;

            await this.context.SaveChangesAsync();


            return Ok(await this.context.Clientes.ToListAsync());
        }
        public ClientesController(DataContext context) {
            this.context = context;
        }
    }
}