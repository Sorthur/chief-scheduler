using chief_schedule.Application.Common.Mappings;
using chief_schedule.Domain.Entities;

namespace chief_schedule.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
