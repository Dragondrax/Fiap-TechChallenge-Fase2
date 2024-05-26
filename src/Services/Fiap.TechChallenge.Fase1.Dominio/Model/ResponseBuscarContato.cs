using Fiap.TechChallenge.Fase1.Dominio.Entidades;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO.Contato;

namespace Fiap.TechChallenge.Fase1.Dominio.Model;

public class ResponseBuscarContato
{
    public ContatoDTO Contato { get; set; }
    public string Regiao { get; set; }
    public string Estado { get; set; }

    public ResponseBuscarContato(ContatoDTO contato, string regiao, string estado)
    {
        Contato = contato;
        Regiao = regiao;
        Estado = estado;
    }
}
