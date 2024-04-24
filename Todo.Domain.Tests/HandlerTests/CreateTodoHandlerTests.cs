using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests
{
    [TestClass]
    public class CreateTodoHandlerTests
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("pao de queijo", "lucas apalosqui", DateTime.Now.AddDays(1));
        private readonly TodoHandler _todoHandler = new TodoHandler(new FakeTodoRepository());
        private GenericCommandResult _commandResult = new GenericCommandResult();

        [TestMethod]
        public void Dado_um_comando_invalido_deve_interromper_a_execucao()
        {
            _commandResult = (GenericCommandResult)_todoHandler.Handle(_invalidCommand);
            Assert.AreEqual(_commandResult.Success, false);
        }

        [TestMethod]
        public void Dado_um_comando_valido_deve_criar_a_tarefa()
        {
            _commandResult = (GenericCommandResult)_todoHandler.Handle(_validCommand);
            Assert.AreEqual(_commandResult.Success, true);
        }
    }
}
