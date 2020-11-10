using CadastroUsuario.Domain.Contratos.Repositorios;
using CadastroUsuario.Domain.Entidades;
using CadastroUsuario.Infra.Conexoes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CadastroUsuario.Infra.Repositorios
{
    public abstract class Repositorio<T> : IRepositorio<T> where T : Entidade
    {
        protected readonly CadastroUsuarioSqliteDbContext _dataContext;
        protected Repositorio(CadastroUsuarioSqliteDbContext dataContext) => _dataContext = dataContext;
        public void Excluir(T entidade) => _dataContext
            .Set<T>()
            .Remove(entidade);

        public async Task IncluirAsync(T entidade, CancellationToken cancellationToken = default) => await _dataContext
            .AddAsync(entidade, cancellationToken);

        public async Task<T> RecuperarAsync(Guid id, CancellationToken cancellationToken = default) => await _dataContext
            .Set<T>()
            .FirstOrDefaultAsync(e=>e.Id==id, cancellationToken);
    }
}
