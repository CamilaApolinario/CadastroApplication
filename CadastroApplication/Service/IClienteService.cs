using CadastroApplication.Domain;
using CadastroApplication.Dtos;

namespace CadastroApplication.Service
{
    public interface IClienteService
    {
        Cliente AdicionaCliente(Cliente cliente);
        Cliente AtualizaCliente(int id, ClienteAtualizaDto cliente);
        List<Cliente> BuscarClientes();
        void RemoveCliente(int id);
    }
}