using chief_schedule.Application.Common.Exceptions;
using chief_schedule.Application.TodoItems.Commands.CreateTodoItem;
using chief_schedule.Application.TodoItems.Commands.DeleteTodoItem;
using chief_schedule.Application.TodoLists.Commands.CreateTodoList;
using chief_schedule.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace chief_schedule.Application.IntegrationTests.TodoItems.Commands;

using static Testing;

public class DeleteTodoItemTests : TestBase
{
    [Test]
    public async Task ShouldRequireValidTodoItemId()
    {
        var command = new DeleteTodoItemCommand { Id = 99 };

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteTodoItem()
    {
        var listId = await SendAsync(new CreateTodoListCommand
        {
            Title = "New List"
        });

        var itemId = await SendAsync(new CreateTodoItemCommand
        {
            ListId = listId,
            Title = "New Item"
        });

        await SendAsync(new DeleteTodoItemCommand
        {
            Id = itemId
        });

        var item = await FindAsync<TodoItem>(itemId);

        item.Should().BeNull();
    }
}
