using chief_schedule.Application.TodoLists.Queries.ExportTodos;

namespace chief_schedule.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
