namespace Fiap.TechChallenge.Fase1.Infraestructure.DTO.Contato;

public class ContatoDTO
{
    public Guid Id { get; set; }
    public string Nome { get; private set; }
    public int DDD { get; private set; }
    public string Telefone { get; private set; }
    public string Email { get; private set; }

    public ContatoDTO(Guid id, string nome, int ddd, string telefone, string email)
    {
        Id = id;
        Nome = nome;
        DDD = ddd;
        Telefone = telefone;
        Email = email;
    }
}
