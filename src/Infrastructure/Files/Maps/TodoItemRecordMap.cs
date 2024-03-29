﻿using System.Globalization;
using chief_schedule.Application.TodoLists.Queries.ExportTodos;
using CsvHelper.Configuration;

namespace chief_schedule.Infrastructure.Files.Maps;

public class TodoItemRecordMap : ClassMap<TodoItemRecord>
{
    public TodoItemRecordMap()
    {
        AutoMap(CultureInfo.InvariantCulture);

        Map(m => m.Done).ConvertUsing(c => c.Done ? "Yes" : "No");
    }
}
