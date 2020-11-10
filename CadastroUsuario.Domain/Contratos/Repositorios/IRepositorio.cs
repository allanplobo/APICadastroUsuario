using CadastroUsuario.Domain.Entidades;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CadastroUsuario.Domain.Contratos.Repositorios
{
    public interface IRepositorio<T>where T:Entidade
    {
        Task IncluirAsync(T entidade, CancellationToken cancellationToken = default);
        void Excluir(T entidade);
        Task<T> RecuperarAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
