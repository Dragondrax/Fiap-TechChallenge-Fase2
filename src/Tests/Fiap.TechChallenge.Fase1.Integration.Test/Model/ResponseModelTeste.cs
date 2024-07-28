using System.Text.Json;

namespace Fiap.TechChallenge.Fase1.Integration.Tests.Model;

public class ResponseModelTeste
{
    public List<string> Mensagem { get; set; }
    public bool Sucesso { get; set; }
    public JsonElement Objeto { get; set; }

    public ResponseModelTeste(List<string> mensagem, bool sucesso, JsonElement objeto)
    {
        Mensagem = mensagem;
        Sucesso = sucesso;
        Objeto = objeto;
    }
}
