using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler : Notifiable, IHandler<CreateTodoCommand>, IHandler<UpdateTodoCommand>, IHandler<MarkTodoAsDoneCommand>, IHandler<MarkTodoAsUndoneCommand>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository reporitory)
        {
            _repository = reporitory;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            // fail fast validate
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada", command.Notifications);

            // gerar TodoItem
            var todo = new TodoItem(command.Title, command.User, command.Date);

            // salvar no banco
            _repository.Create(todo);

            // retorna o resultado
            return new GenericCommandResult(true, "Tarefa salva com sucesso!", todo);
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            // fail fast validate
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada", command.Notifications);

            var todo = _repository.GetById(command.Id, command.User);

            _repository.GetById(command.Id, command.User);

            todo.UpdateTitle(command.Title);

            _repository.Update(todo);

            return new GenericCommandResult(true, "Tarefa Atualizada", todo);

            
        }

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
            // fail fast validate
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada", command.Notifications);

            var todo = _repository.GetById(command.Id, command.User);

            todo.MarkAsDone();

            _repository.Update(todo);

            return new GenericCommandResult(true, "Tarefa está marcada como concluida!", todo);

        }

        public ICommandResult Handle(MarkTodoAsUndoneCommand command)
        {
            // fail fast validate
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada", command.Notifications);

            var todo = _repository.GetById(command.Id, command.User);

            todo.MarkAsUnDone();

            _repository.Update(todo);

            return new GenericCommandResult(true, "Tarefa está marcada como não concluida!", todo);
        }
    }
}
