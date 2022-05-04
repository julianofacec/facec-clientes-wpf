using System.Text.Json.Serialization;

namespace Facec.Teste.WPF
{
    internal class Cliente
    {

        [JsonPropertyName("documento")]
        public string Documento { get; private set; }

        [JsonPropertyName("nome")]
        public string Nome { get; private set; }

        public Cliente(string documento, string nome)
        {
            Documento = documento;
            Nome = nome;
        }
    }
}