using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {

        private readonly ITarefaRepositorio _tarefaRepositorio;

        public TarefaController(ITarefaRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<TarefaModel>>> BuscarTodasTarefas() {

            var tarefas = await _tarefaRepositorio.Listar();

            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaModel>> BuscarPorId(int id)
        {

            var tarefa = await _tarefaRepositorio.BuscarPorId(id);

            return Ok(tarefa);
        }

        [HttpPost]

        public async Task<ActionResult<TarefaModel>> Cadastrar([FromBody] TarefaModel tarefaModel)
        {
            var tarefa = await _tarefaRepositorio.Adicionar(tarefaModel);
            return Ok(tarefa);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<TarefaModel>> Atualizar([FromBody] TarefaModel tarefa, int id)
        {
            tarefa.Id = id;
            var tarefaAtualizada = await _tarefaRepositorio.Atualizar(tarefa, id);
            return Ok(tarefaAtualizada);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<bool>> Apagar(int id)
        {
            bool apagado = await _tarefaRepositorio.Apagar(id); 
            return Ok(apagado);
        }
    }
}
