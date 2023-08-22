using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
    {

        private readonly SistemaDeTarefasDBContext _dbContext;

        public TarefaRepositorio(SistemaDeTarefasDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TarefaModel> BuscarPorId(int id)
        {
            return await _dbContext.Tarefas.Include(x => x.Usuario).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TarefaModel>> Listar()
        {
            return await _dbContext.Tarefas.Include(x => x.Usuario).ToListAsync();
        }
        public async Task<TarefaModel> Adicionar(TarefaModel model)
        {
            await _dbContext.Tarefas.AddAsync(model);
            await _dbContext.SaveChangesAsync();

            return model;
        }

        public async Task<TarefaModel> Atualizar(TarefaModel model, int id)
        {
            TarefaModel tarefa = await BuscarPorId(id);

            if (tarefa == null) { throw new Exception($"Usuário com o id: {id} não foi encontrado!"); }

            tarefa.Name = model.Name;
            tarefa.Descricao = model.Descricao;
            tarefa.Status = model.Status;
            tarefa.UsuarioId = model.UsuarioId;

            _dbContext.Tarefas.Update(tarefa);
            await _dbContext.SaveChangesAsync();

            return tarefa;
        }

        public async Task<bool> Apagar(int id)
        {

            TarefaModel tarefa = await BuscarPorId(id);

            if (tarefa == null) { throw new Exception($"Usuário com o id: {id} não foi encontrado!"); }

            _dbContext.Tarefas.Remove(tarefa);

            await _dbContext.SaveChangesAsync();

            return true;
        }

        

        
    }
}
