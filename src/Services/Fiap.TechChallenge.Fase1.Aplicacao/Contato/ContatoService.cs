using Fiap.TechChallenge.Fase1.Dominio;
using Fiap.TechChallenge.Fase1.Dominio.Entidades;
using Fiap.TechChallenge.Fase1.Dominio.Model;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO.Contato;
using Fiap.TechChallenge.Fase1.SharedKernel;
using Fiap.TechChallenge.Fase1.SharedKernel.MensagensErro;
using Fiap.TechChallenge.Fase1.SharedKernel.Model;


namespace Fiap.TechChallenge.Fase1.Aplicacao;

public class ContatoService(IContatoRepository contatoRepository, IDDDRegiaoService regiaoService) : IContatoService
{
    private readonly IContatoRepository _contatoRepository = contatoRepository;
    private readonly IDDDRegiaoService _regiaoService = regiaoService;
    private List<string> _mensagem = [];

    public async Task<ResponseModel> SalvarContato(CriarAlterarContatoDTO contatoDTO)
    {
        var validacao = new CriarContatoDTOValidator().Validate(contatoDTO);

        if (!validacao.IsValid)
        {
            _mensagem = validacao.Errors.Select(x => x.ErrorMessage).ToList();
            return new ResponseModel(_mensagem, false, null);
        }

        var contato = await _contatoRepository.ObterPorEmailAsync(contatoDTO.Email.ToLower());

        if (contato is null)
        {
            var novoContato = new Contato(contatoDTO.Nome, contatoDTO.DDD, contatoDTO.Telefone, contatoDTO.Email);

            await _contatoRepository.AdicionarAsync(novoContato);

            Dominio.Entidades.DDDRegiao regiao = await _regiaoService.BuscarDDDRegiao(novoContato.DDD);
            if (regiao is not null)
            {
                ContatoDTO contatoRetornoDTO = new(novoContato.Id, novoContato.Nome, novoContato.DDD, novoContato.Telefone, novoContato.Email);

                ResponseBuscarContato contatoRegiao = new(contatoRetornoDTO, regiao.Regiao, regiao.Estado);

                _mensagem.Add(MensagemErroGenerico.MENSAGEM_SUCESSO);
                return new ResponseModel(_mensagem, true, contatoRegiao);
            }

            _mensagem.Add(MensagemErroContato.MENSAGEM_LISTA_DE_REGIAO_VAZIA);
            return new ResponseModel(_mensagem, false, null);
        }

        _mensagem.Add(MensagemErroContato.MENSAGEM_CONTATO_JA_EXISTENTE);
        return new ResponseModel(_mensagem, false, null);
    }

    public async Task<ResponseModel> BuscarContatosPorDDD(int DDD)
    {
        bool verificaDDDValido = DDDValidator.DDDsValidos.Contains(DDD.ToString());

        if (!verificaDDDValido)
        {
            _mensagem.Add(MensagemErroContato.MENSAGEM_DDD_INVALIDO);

            return new ResponseModel(_mensagem, false, null);
        }

        List<ResponseBuscarContato> listaDeContatoComRegiao = [];

        List<Contato> listaDeContatos = await _contatoRepository.BuscaContatosPorDDD(DDD);

        if (!listaDeContatos.Any())
        {
            _mensagem.Add(MensagemErroContato.MENSAGEM_LISTA_DE_CONTATO_VAZIA);

            return new ResponseModel(_mensagem, false, null);
        }

        foreach (var contato in listaDeContatos)
        {
            Dominio.Entidades.DDDRegiao regiao = await _regiaoService.BuscarDDDRegiao(contato.DDD);

            if(regiao is not null)
            {
                ContatoDTO contatoRetornoDTO = new(contato.Id, contato.Nome, contato.DDD, contato.Telefone, contato.Email);
                ResponseBuscarContato contatoRegiao = new(contatoRetornoDTO, regiao.Regiao, regiao.Estado);
                listaDeContatoComRegiao.Add(contatoRegiao);
            }
            else
            {
                _mensagem.Add(MensagemErroContato.MENSAGEM_LISTA_DE_REGIAO_VAZIA);
                return new ResponseModel(_mensagem, false, null);
            }
        }

        _mensagem.Add(MensagemErroGenerico.MENSAGEM_SUCESSO);
        return new ResponseModel(_mensagem, true, listaDeContatoComRegiao);
    }

    public async Task<ResponseModel> BuscarContatoPorEmail(BuscarContatoDTO contatoDTO)
    {
        var validacao = new BuscarContatoDTOValidator().Validate(contatoDTO);

        if (!validacao.IsValid)
        {
            _mensagem = validacao.Errors.Select(x => x.ErrorMessage).ToList();
            return new ResponseModel(_mensagem, false, null);
        }

        var contato = await _contatoRepository.ObterPorEmailAsync(contatoDTO.Email);

        if (contato is null)
        {
            _mensagem.Add(MensagemErroContato.MENSAGEM_CONTATO_NAO_EXISTE);
            return new ResponseModel(_mensagem, false, null);
        }

        Dominio.Entidades.DDDRegiao regiao = await _regiaoService.BuscarDDDRegiao(contato.DDD);

        ContatoDTO contatoRetornoDTO = new(contato.Id, contato.Nome, contato.DDD, contato.Telefone, contato.Email);

        ResponseBuscarContato contatoRegiao = new (contatoRetornoDTO, regiao.Regiao, regiao.Estado);

        _mensagem.Add(MensagemErroGenerico.MENSAGEM_SUCESSO);
        return new ResponseModel(_mensagem, true, contatoRegiao);
    }

    public async Task<ResponseModel> AlterarContato(CriarAlterarContatoDTO contatoDTO)
    {
        var validacao = new CriarContatoDTOValidator().Validate(contatoDTO);

        if (!validacao.IsValid)
        {
            _mensagem = validacao.Errors.Select(x => x.ErrorMessage).ToList();
            return new ResponseModel(_mensagem, false, null);
        }

        var contato = await _contatoRepository.ObterPorEmailAsync(contatoDTO.Email.ToLower());

        if (contato is null)
        {
            _mensagem.Add(MensagemErroContato.MENSAGEM_CONTATO_NAO_EXISTE);
            return new ResponseModel(_mensagem, false, null);
        }

        contato.AlterarDDDRegiao(contatoDTO.Nome, contatoDTO.DDD, contatoDTO.Telefone, contatoDTO.Email.ToLower());

        await _contatoRepository.AtualizarAsync(contato);

        Dominio.Entidades.DDDRegiao regiao = await _regiaoService.BuscarDDDRegiao(contato.DDD);

        ContatoDTO contatoRetornoDTO = new(contato.Id, contato.Nome, contato.DDD, contato.Telefone, contato.Email);

        ResponseBuscarContato contatoRegiao = new(contatoRetornoDTO, regiao.Regiao, regiao.Estado);

        _mensagem.Add(MensagemErroGenerico.MENSAGEM_SUCESSO);
        return new ResponseModel(_mensagem, true, contatoRegiao);
    }

    public async Task<ResponseModel> RemoverContato(Guid id)
    {
        var contato = await _contatoRepository.ObterPorIdAsync(id);

        if (contato is not null)
        {
            contato.ExcluirDDDRegiao();

            await _contatoRepository.RemoverAsync(contato);

            _mensagem.Add(MensagemErroGenerico.MENSAGEM_SUCESSO);
            return new ResponseModel(_mensagem, true, contato);
        }

        _mensagem.Add(MensagemErroContato.MENSAGEM_CONTATO_NAO_ENCONTRADO);
        return new ResponseModel(_mensagem, false, null);
    }
}
