using CadastroApplication.Domain;
using CadastroApplication.Dtos;
using CadastroApplication.Infra;

namespace CadastroApplication.Service
{
    public class ClienteService : IClienteService
    {
        private readonly CadastroApplicationContext _context;

        public ClienteService(CadastroApplicationContext context)
        {
            _context = context;
        }

        public List<Cliente> BuscarClientes()
        {
            return _context.Clientes.ToList();
        }

        public Cliente AdicionaCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return cliente;
        }

        public Cliente AtualizaCliente(int id, ClienteAtualizaDto cliente)
        {
            var clienteExistente = _context.Clientes.FirstOrDefault(c => c.Id == id);
            if (clienteExistente != null)
            {
                clienteExistente.Nome = cliente.Nome;
                clienteExistente.PorteDaEmpresa = cliente.PorteDaEmpresa;
            }
            _context.Update(clienteExistente);
            _context.SaveChanges();

            return clienteExistente;
        }

        public void RemoveCliente(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.Id == id);

            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
        }
    }
}
