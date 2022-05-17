using System.Text.Json.Serialization;

namespace Facec.Teste.WPF
{
    public class Cliente
    {

        [JsonPropertyName("documento")]
        public string Documento { get; set; } = string.Empty;

        [JsonPropertyName("nome")]
        public string Nome { get; set; } = string.Empty;

        public Cliente() { }

        public Cliente(string documento, string nome)
        {
            Documento = documento;
            Nome = nome;
        }
    }
}