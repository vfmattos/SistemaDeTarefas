using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {

        Task<UsuarioModel> BuscarPorId(int id);
        Task<List<UsuarioModel>> Listar();
        Task<UsuarioModel> Adicionar(UsuarioModel model);
        Task<UsuarioModel> Atualizar(UsuarioModel model, int id);
        Task<bool> Apagar(int id);

    }
}
