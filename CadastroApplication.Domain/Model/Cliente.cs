using Newtonsoft.Json;

namespace CadastroApplication.Domain
{
    public class Cliente
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("porteDaEmpresa")]
        public string PorteDaEmpresa { get; set; } 

    }
}