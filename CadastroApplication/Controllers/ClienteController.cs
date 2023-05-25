using CadastroApplication.Domain;
using CadastroApplication.Dtos;
using CadastroApplication.Service;
using Microsoft.AspNetCore.Mvc;

namespace CadastroApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public IActionResult ObterClientes()
        {
            var listaClientes =_clienteService.BuscarClientes().ToList();
            return Ok(listaClientes);
        }

        [HttpPost]
        public IActionResult AdicionarCliente(Cliente cliente)
        {
            _clienteService.AdicionaCliente(cliente);
            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCliente(int id, ClienteAtualizaDto clienteAtualizaDto)
        {
            _clienteService.AtualizaCliente(id, clienteAtualizaDto);
            return Ok(clienteAtualizaDto);
        }

        [HttpDelete]
        public IActionResult RemoverCliente(int id)
        {
            _clienteService.RemoveCliente(id);
            return NoContent();
        }

    }
}
