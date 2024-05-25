using Fiap.TechChallenge.Fase1.Infraestructure.DTO.Contato;
using Fiap.TechChallenge.Fase1.SharedKernel.Model;

namespace Fiap.TechChallenge.Fase1.Dominio;

public interface IContatoService
{
    Task<ResponseModel> SalvarContato(CriarAlterarContatoDTO contatoDTO);
    Task<ResponseModel> BuscarContatosPorDDD(int DDD);
    Task<ResponseModel> BuscarContatoPorEmail(BuscarContatoDTO contatoDTO);
    Task<ResponseModel> AlterarContato(CriarAlterarContatoDTO contatoDTO);
    Task<ResponseModel> RemoverContato(Guid id);
}
