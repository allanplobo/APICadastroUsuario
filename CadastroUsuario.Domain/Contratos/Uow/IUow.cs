using System.Threading;
using System.Threading.Tasks;

namespace CadastroUsuario.Domain.Contratos.Uow
{
    public interface IUow
    {
        Task CommitAsync(CancellationToken cancellationToken = default);
    }
}
