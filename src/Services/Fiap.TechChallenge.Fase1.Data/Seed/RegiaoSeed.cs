using Fiap.TechChallenge.Fase1.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.TechChallenge.Fase1.Data.Seed
{
    internal static class RegiaoSeed
    {
        internal static void AdicionarRegioes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(11, "SP", "Sudeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(12, "SP", "Sudeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(13, "SP", "Sudeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(14, "SP", "Sudeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(15, "SP", "Sudeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(16, "SP", "Sudeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(17, "SP", "Sudeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(18, "SP", "Sudeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(19, "SP", "Sudeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(21, "RJ", "Sudeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(22, "RJ", "Sudeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(24, "RJ", "Sudeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(27, "ES", "Sudeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(28, "ES", "Sudeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(31, "MG", "Sudeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(32, "MG", "Sudeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(33, "MG", "Sudeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(34, "MG", "Sudeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(35, "MG", "Sudeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(37, "MG", "Sudeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(38, "MG", "Sudeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(41, "PR", "Sul"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(42, "SC", "Sul"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(43, "PR", "Sul"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(44, "PR", "Sul"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(45, "PR", "Sul"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(46, "PR", "Sul"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(47, "SC", "Sul"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(48, "SC", "Sul"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(49, "SC", "Sul"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(51, "RS", "Sul"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(53, "RS", "Sul"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(54, "RS", "Sul"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(55, "RS", "Sul"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(61, "DF", "Centro-Oeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(62, "GO", "Centro-Oeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(63, "TO", "Norte"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(64, "GO", "Centro-Oeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(65, "MT", "Centro-Oeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(66, "MT", "Centro-Oeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(67, "MS", "Centro-Oeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(68, "AC", "Norte"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(69, "RO", "Norte"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(71, "BA", "Nordeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(73, "BA", "Nordeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(74, "BA", "Nordeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(75, "BA", "Nordeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(77, "BA", "Nordeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(79, "SE", "Nordeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(81, "PE", "Nordeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(82, "AL", "Nordeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(83, "PB", "Nordeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(84, "RN", "Nordeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(85, "CE", "Nordeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(86, "PI", "Nordeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(87, "PE", "Nordeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(88, "CE", "Nordeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(89, "PI", "Nordeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(91, "PA", "Norte"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(92, "AM", "Norte"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(93, "PA", "Norte"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(94, "PA", "Norte"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(95, "RR", "Norte"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(96, "AP", "Norte"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(97, "AM", "Norte"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(98, "MA", "Nordeste"));
            modelBuilder.Entity<DDDRegiao>().HasData(new DDDRegiao(99, "MA", "Nordeste"));

        }
    }
}
