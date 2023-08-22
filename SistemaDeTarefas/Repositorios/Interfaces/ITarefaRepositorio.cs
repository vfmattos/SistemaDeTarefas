using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositorios.Interfaces
{
    public interface ITarefaRepositorio
    {

        Task<TarefaModel> BuscarPorId(int id);
        Task<List<TarefaModel>> Listar();
        Task<TarefaModel> Adicionar(TarefaModel model);
        Task<TarefaModel> Atualizar(TarefaModel model, int id);
        Task<bool> Apagar(int id);

    }
}
