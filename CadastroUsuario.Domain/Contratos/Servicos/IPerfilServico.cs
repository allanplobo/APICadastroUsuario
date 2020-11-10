using CadastroUsuario.Domain.Contratos.Modelos.Entradas;
using CadastroUsuario.Domain.Contratos.Modelos.Saidas;
using System.Threading;
using System.Threading.Tasks;

namespace CadastroUsuario.Domain.Contratos.Servicos
{
    public interface IPerfilServico
    {
        Task<Resposta> CadastrarPerfilAsync(PerfilCadastroModel model, CancellationToken cancellationToken = default);
    }
}
