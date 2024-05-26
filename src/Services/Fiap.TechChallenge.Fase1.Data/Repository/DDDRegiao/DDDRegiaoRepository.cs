using Fiap.TechChallenge.Fase1.Data.Context;
using Fiap.TechChallenge.Fase1.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Fiap.TechChallenge.Fase1.Data.Repository;

public class DDDRegiaoRepository : Repository<Dominio.Entidades.DDDRegiao>, IDDDRegiaoRepository
{

    public DDDRegiaoRepository(ContextTechChallenge db) : base(db)
    { 
    }

    public async Task<Dominio.Entidades.DDDRegiao> BuscarRegiaoPorDDD(int DDD)
    {
        return await Db.DDDRegiao.FirstOrDefaultAsync(x => x.DDD == DDD && x.Excluido == false);
    }
}
