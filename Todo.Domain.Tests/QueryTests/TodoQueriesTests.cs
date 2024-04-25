

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueryTests
{
    [TestClass]
    public class TodoQueriesTests
    {
        private List<TodoItem> _items;

        public TodoQueriesTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa 1", "usuario1", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 2", "usuario1", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 3", "lucas apalosqui", DateTime.Now.AddDays(1)));
            _items.Add(new TodoItem("Tarefa 4", "usuario1", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 5", "lucas apalosqui", DateTime.Now));

        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefas_apenas_do_usuario_lucas_apalosqui()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("lucas apalosqui"));
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefas_concluidas()
        {
            foreach (var item in _items)
                item.MarkAsDone();

            var result = _items.AsQueryable().Where(TodoQueries.GetAllDone("lucas apalosqui"));
            Assert.AreEqual(2, result.Count());

        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefas_não_concluidas()
        {
            foreach (var item in _items)
                item.MarkAsUnDone();

            var result = _items.AsQueryable().Where(TodoQueries.GetAllUndone("lucas apalosqui"));
            Assert.AreEqual(2, result.Count());

        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefas_do_periodo_de_amanha_concluidas()
        {
            foreach(var item in _items)
                item.MarkAsDone();

            var result = _items.AsQueryable().Where(TodoQueries.GetByPeriod("lucas apalosqui", DateTime.Now.AddDays(1), true));
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefa_pelo_id()
        {
            var tarefa = _items[4];
            var result = _items.AsQueryable().Where(TodoQueries.GetById("lucas apalosqui", tarefa.Id));

            Assert.AreEqual(result.Count(), 1);

        }
    }
}
