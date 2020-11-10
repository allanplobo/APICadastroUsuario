using CadastroUsuario.Domain.Contratos.Repositorios;
using CadastroUsuario.Domain.Entidades;
using CadastroUsuario.Infra.Conexoes;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CadastroUsuario.Infra.Repositorios
{
    public class PerfilRepositorio : Repositorio<Perfil>, IPerfilRepositorio
    {
        public PerfilRepositorio(CadastroUsuarioSqliteDbContext dataContext) : base(dataContext)
        {
        }

        public Task<List<Perfil>> RecuperarPorNomeAsync(string nome, CancellationToken cancelationToken = default) => _dataContext
            .Set<Perfil>()
            .Where(p => EF.Functions.Like(p.Nome, $"%{nome}%"))
            .ToListAsync(cancelationToken);
    }
}
