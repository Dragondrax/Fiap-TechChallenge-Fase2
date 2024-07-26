using Fiap.TechChallenge.Fase1.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.TechChallenge.Fase1.Data.Seed
{
    internal static class UsuarioPadraoSeed
    {
        internal static void AdicionarUsuarioPadraoAdministrador(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(new Usuario("Administrador", "admin@gmail.com", "$2b$12$/nj7LJgiUFp32SZ9A2A98e83JwjOtWPhOLTnplHMCRQqKfqGHAmVS", Infraestructure.Enum.Roles.Administrador));
        }
    }
}
