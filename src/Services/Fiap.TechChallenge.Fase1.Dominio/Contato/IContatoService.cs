using Fiap.TechChallenge.Fase1.Infraestructure.DTO;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO.Contato;
using Fiap.TechChallenge.Fase1.SharedKernel.Model;

namespace Fiap.TechChallenge.Fase1.Dominio;

public interface IContatoService
{
    Task<ResponseModel> SalvarContato(CriarContatoDTO contatoDTO);
}
