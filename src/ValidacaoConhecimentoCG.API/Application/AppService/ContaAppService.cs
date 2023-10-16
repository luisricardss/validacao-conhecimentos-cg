using ValidacaoConhecimentoCG.API.Application.AppService.Interface;
using ValidacaoConhecimentoCG.API.Application.Requests.Conta;
using ValidacaoConhecimentoCG.API.Application.Responses.Conta;
using ValidacaoConhecimentoCG.API.Application.Validators;
using ValidacaoConhecimentoCG.API.Domain.Entidades;
using ValidacaoConhecimentoCG.API.Domain.Repository;
using ValidacaoConhecimentoCG.API.Infrastructure.Base.Paginacao;
using ValidacaoConhecimentoCG.API.Infrastructure.Notificacoes;

namespace ValidacaoConhecimentoCG.API.Application.AppService
{
    public class ContaAppService : IContaAppService
    {
        private readonly IContaRepository _contaRepository;
        private readonly INotificador _notificador;

        public ContaAppService(IContaRepository contaRepository, INotificador notificador)
        {
            _contaRepository = contaRepository;
            _notificador = notificador;
        }

        public async Task<ContaResponse?> ObterPorId(Guid id)
        {
            var conta = await _contaRepository.ObterPorId(id);
            if (conta is null)
            {
                _notificador.AdicionarNotificacao(MensagensValidacoes.IdInvalido);
                return null;
            }

            return new ContaResponse
            {
                Id = conta.Id,
                Nome = conta.Nome,
                Descricao = conta.Descricao,
            };
        }

        public async Task<PaginacaoResponse<ContaResponse>> ObterTodosPaginado(PaginacaoRequest request)
        {
            var contas = await _contaRepository.ObterTodosPaginado(request);

            return new PaginacaoResponse<ContaResponse>
            {
                Itens = contas.Itens.Select(x => new ContaResponse
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Descricao = x.Descricao
                }),
                Paginacao = contas.Paginacao,
            };
        }

        public async Task<bool> Remover(Guid id)
        {
            if (id == Guid.Empty)
            {
                _notificador.AdicionarNotificacao(MensagensValidacoes.IdInvalido);
                return false;
            }

            var conta = await _contaRepository.ObterPorId(id, true);
            if (conta == null)
            {
                _notificador.AdicionarNotificacao(MensagensValidacoes.IdInvalido);
                return false;
            }

            _contaRepository.Remover(conta);
            return await _contaRepository.UnitOfWork.CommitAsync();
        }

        public async Task<Guid?> Adicionar(ContaRequest request)
        {
            if (!request.EhValido())
            {
                _notificador.AdicionarNotificacoes(request.Validar().Errors);
                return null;
            }

            var conta = new Conta(request.Nome!, request.Descricao!);
            _contaRepository.Adicionar(conta);

            if (!await _contaRepository.UnitOfWork.CommitAsync())
            {
                _notificador.AdicionarNotificacao(MensagensValidacoes.OcorreuErro);
                return null;
            }

            return conta.Id;
        }

        public async Task<bool> Atualizar(AtualizarContaRequest request)
        {
            if (request.Id == Guid.Empty)
            {
                _notificador.AdicionarNotificacao(MensagensValidacoes.IdInvalido);
                return false;
            }

            if (!request.EhValido())
            {
                _notificador.AdicionarNotificacoes(request.Validar().Errors);
                return false;
            }

            var conta = await _contaRepository.ObterPorId(request.Id, true);
            if (conta == null)
            {
                _notificador.AdicionarNotificacao(MensagensValidacoes.IdInvalido);
                return false;
            }

            conta.Nome = request.Nome!;
            conta.Descricao = request.Descricao!;

            _contaRepository.Atualizar(conta);
            return await _contaRepository.UnitOfWork.CommitAsync();
        }


        //public async Task<Guid?> Salvar(ContaRequest request)
        //{
        //    if (!request.EhValido())
        //    {
        //        _notificador.AdicionarNotificacoes(request.Validar().Errors);
        //        return null;
        //    }

        //    var id = Guid.Empty;
        //    if (request.Id.HasValue)
        //    {
        //        if (id == Guid.Empty)
        //        {
        //            _notificador.AdicionarNotificacao(MensagensValidacoes.IdInvalido);
        //            return null;
        //        }

        //        var conta = await _contaRepository.ObterPorId(request.Id.Value, true);
        //        if (conta == null)
        //        {
        //            _notificador.AdicionarNotificacao(MensagensValidacoes.IdInvalido);
        //            return null;
        //        }

        //        conta.Nome = request.Nome!;
        //        conta.Descricao = request.Descricao!;

        //        _contaRepository.Atualizar(conta);
        //        if (await _contaRepository.UnitOfWork.CommitAsync())
        //            id = conta.Id;
        //    }
        //    else
        //    {
        //        var conta = new Conta(request.Nome!, request.Descricao!);
        //        _contaRepository.Adicionar(conta);

        //        if (await _contaRepository.UnitOfWork.CommitAsync())
        //            id = conta.Id;
        //    }

        //    if (id == Guid.Empty)
        //    {
        //        _notificador.AdicionarNotificacao(MensagensValidacoes.OcorreuErro);
        //        return null;
        //    }

        //    return id;
        //}
    }
}
