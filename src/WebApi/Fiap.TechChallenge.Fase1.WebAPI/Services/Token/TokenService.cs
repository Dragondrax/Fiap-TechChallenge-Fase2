using Fiap.TechChallenge.Fase1.Data.Entidades;
using Fiap.TechChallenge.Fase1.Data.Repository;
using Fiap.TechChallenge.Fase1.Dominio;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO.Usuario;
using Fiap.TechChallenge.Fase1.WebAPI.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Fiap.TechChallenge.Fase1.Aplicacao.Token;

public class TokenService(IConfiguration configuration, IUsuarioRepository repository, IUsuarioService service) : ITokenService
{
    private readonly IConfiguration _configuration = configuration;
    private readonly IUsuarioRepository _repository = repository;
    private readonly IUsuarioService _service = service;

    public async Task<string> GetToken(AutenticarUsuarioDTO usuario)
    {
        Usuario usuarioExiste = await _repository.ObterPorEmailAsync(usuario.Email);

        if (usuarioExiste == null)
            return string.Empty;

        if (usuarioExiste.Role == Infraestructure.Enum.Roles.Usuario)
            return string.Empty;

        bool verificaSenha = _service.VerificaSenhaUsuario(usuario.Senha, usuarioExiste.Senha);


        if (!verificaSenha)
            return string.Empty;

        var tokenHandler = new JwtSecurityTokenHandler();

        var chaveCriptografia = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretJWT")!);

        var tokenPropriedades = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new(ClaimTypes.Name, usuario.Email),
            }),
            Expires = DateTime.UtcNow.AddHours(8),

            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(chaveCriptografia),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenPropriedades);


        return tokenHandler.WriteToken(token);
     
    }

}
