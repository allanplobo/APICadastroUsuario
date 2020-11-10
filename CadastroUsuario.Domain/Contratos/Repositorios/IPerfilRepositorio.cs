using CadastroUsuario.Domain.Entidades;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CadastroUsuario.Domain.Contratos.Repositorios
{
    public interface IPerfilRepositorio:IRepositorio<Perfil>
    {
        Task<List<Perfil>> RecuperarPorNomeAsync(string nome, CancellationToken cancellationToken = default);
    }
}
