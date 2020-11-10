using CadastroUsuario.Domain.Contratos.Modelos.Entradas;
using CadastroUsuario.Domain.Contratos.Modelos.Saidas;
using CadastroUsuario.Domain.Contratos.Repositorios;
using CadastroUsuario.Domain.Contratos.Servicos;
using CadastroUsuario.Domain.Entidades;
using System.Threading;
using System.Threading.Tasks;

namespace CadastroUsuario.Business.Servicos
{
    public class PerfilServico : IPerfilServico
    {
        private readonly IPerfilRepositorio _repositorio;

        public PerfilServico(IPerfilRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<Resposta> CadastrarPerfilAsync(PerfilCadastroModel model, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(model.Nome))
                return Resposta.Aviso("Perfil não informado!");

            if (model.Nome.Length > 200)
                return Resposta.Aviso("O nome do perfil não pode ter mais do que 200 caracteres!");

            var perfil = new Perfil(model.Nome);
            await _repositorio.IncluirAsync(perfil, cancellationToken);

            return Resposta.Sucesso($"Perfil {perfil.Nome} cadastrado com sucesso!", new { perfil.Id, perfil.Nome });
        }
    }
}
