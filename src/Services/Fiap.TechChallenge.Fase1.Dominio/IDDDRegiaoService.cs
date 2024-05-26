namespace Fiap.TechChallenge.Fase1.Dominio;

public interface IDDDRegiaoService
{
    Task<Dominio.Entidades.DDDRegiao> BuscarDDDRegiao(int DDD);
}
