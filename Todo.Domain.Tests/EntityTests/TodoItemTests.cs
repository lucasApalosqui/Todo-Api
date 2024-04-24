using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTests
{
    [TestClass]
    public class TodoItemTests
    {
        private readonly TodoItem _todoItem = new TodoItem("tarefa 1", "lucas apalosqui", DateTime.Now);

        [TestMethod]
        public void Dado_um_novo_todo_o_mesmo_deve_estar_marcado_como_nao_concluido()
        {
            Assert.AreEqual(_todoItem.Done, false);
        }

        [TestMethod]
        public void Ao_marcar_todo_como_concluido_o_mesmo_deve_estar_marcado_como_true()
        {
            _todoItem.MarkAsDone();
            Assert.AreEqual(_todoItem.Done, true);
        }

        [TestMethod]
        public void Ao_marcar_todo_como_inconcluido_o_mesmo_deve_estar_marcado_como_false()
        {
            _todoItem.MarkAsUnDone();
            Assert.AreEqual(_todoItem.Done, false);
        }

        [TestMethod]
        public void Ao_atualizar_o_titulo_do_todo_o_mesmo_deve_ser_alterado()
        {
            string newTitle = "novo titulo da tarefa";
            _todoItem.UpdateTitle(newTitle);
            Assert.AreEqual(_todoItem.Title, newTitle);
        }
    }
}
