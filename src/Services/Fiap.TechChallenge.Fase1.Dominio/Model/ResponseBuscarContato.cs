using Fiap.TechChallenge.Fase1.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.TechChallenge.Fase1.Dominio.Model;

public class ResponseBuscarContato
{
    public Contato Contato { get; set; }
    public string Regiao { get; set; }
    public string Estado { get; set; }

    public ResponseBuscarContato(Contato contato, string regiao, string estado)
    {
        Contato = contato;
        Regiao = regiao;
        Estado = estado;
    }
}
