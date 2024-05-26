using Fiap.TechChallenge.Fase1.Dominio;

namespace Fiap.TechChallenge.Fase1.Aplicacao.DDDRegiao;

public class DDDRegiaoService : IDDDRegiaoService
{
    private readonly IDDDRegiaoRepository _regiaoRepository;

    public DDDRegiaoService(IDDDRegiaoRepository regiaoRepository)
    {
        _regiaoRepository = regiaoRepository;
    }

    public async Task<Dominio.Entidades.DDDRegiao> BuscarDDDRegiao(int DDD)
    {
        return await _regiaoRepository.BuscarRegiaoPorDDD(DDD);
    }
}
