using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private readonly SistemaDeTarefasDBContext _dbContext;

        public UsuarioRepositorio(SistemaDeTarefasDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> Listar()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
        public async Task<UsuarioModel> Adicionar(UsuarioModel model)
        {
            await _dbContext.Usuarios.AddAsync(model);
            await _dbContext.SaveChangesAsync();

            return model;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel model, int id)
        {
            UsuarioModel user = await BuscarPorId(id);

            if (user == null) { throw new Exception($"Usuário com o id: {id} não foi encontrado!"); }

            user.Nome = model.Nome;
            user.Email = model.Email;

            _dbContext.Usuarios.Update(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<bool> Apagar(int id)
        {

            UsuarioModel user = await BuscarPorId(id);

            if (user == null) { throw new Exception($"Usuário com o id: {id} não foi encontrado!"); }

            _dbContext.Usuarios.Remove(user);

            await _dbContext.SaveChangesAsync();

            return true;
        }

        

        
    }
}
