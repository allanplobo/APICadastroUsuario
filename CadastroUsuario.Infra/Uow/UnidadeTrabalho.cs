using CadastroUsuario.Domain.Contratos.Uow;
using CadastroUsuario.Infra.Conexoes;
using System.Threading;
using System.Threading.Tasks;

namespace CadastroUsuario.Infra.Uow
{
    public class UnidadeTrabalho : IUow
    {
        private readonly CadastroUsuarioSqliteDbContext _dataContext;

        public UnidadeTrabalho(CadastroUsuarioSqliteDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default) => await _dataContext.SaveChangesAsync(cancellationToken);
    }
}
