using Fiap.TechChallenge.Fase1.Data.Repository;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO.Contato;
using Fiap.TechChallenge.Fase1.SharedKernel.Model;
using Fiap.TechChallenge.Fase1.Data.Entidades;
using Fiap.TechChallenge.Fase1.SharedKernel;
using Fiap.TechChallenge.Fase1.SharedKernel.MensagensErro;


namespace Fiap.TechChallenge.Fase1.Dominio;

public class ContatoService(IContatoRepository contatoRepository) : IContatoService
{
    private readonly IContatoRepository _contatoRepository = contatoRepository;
    private List<string> _mensagem = [];

    public async Task<ResponseModel> SalvarContato(CriarContatoDTO contatoDTO)
    {
        var validacao = new CriarContatoDTOValidator().Validate(contatoDTO);

        if (!validacao.IsValid)
        {
            _mensagem = validacao.Errors.Select(x => x.ErrorMessage).ToList();
            return new ResponseModel(_mensagem, false, null);
        }

        var contato = await _contatoRepository.ObterPorEmailAsync(contatoDTO.Email);

        if (contato is null)
        {
            var novoContato = new Contato(contatoDTO.Nome, contatoDTO.DDD, contatoDTO.Telefone, contatoDTO.Email);

            await _contatoRepository.AdicionarAsync(novoContato);

            _mensagem.Add(MensagemErroGenerico.MENSAGEM_SUCESSO);

            return new ResponseModel(_mensagem, true, novoContato);
        }

        _mensagem.Add(MensagemErroContato.MENSAGEM_CONTATO_JA_EXISTENTE);

        return new ResponseModel(_mensagem, false, null);
    }
}
