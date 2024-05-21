using Fiap.TechChallenge.Fase1.Infraestructure.Enum;
using System.Data;

namespace Fiap.TechChallenge.Fase1.Infraestructure.DTO.Usuario
{
    public class UsuarioDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public Roles Role { get; set; }

        public UsuarioDTO(string nome, string email, Roles role) 
        {
            Nome = nome;
            Email = email;
            Role = role;
        }
    }
}
