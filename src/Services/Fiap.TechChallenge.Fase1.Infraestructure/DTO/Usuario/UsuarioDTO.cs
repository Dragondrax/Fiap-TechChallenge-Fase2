using Fiap.TechChallenge.Fase1.Infraestructure.Enum;

namespace Fiap.TechChallenge.Fase1.Infraestructure.DTO.Usuario
{
    public class UsuarioDTO
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public Roles Role { get; private set; }
    }
}
