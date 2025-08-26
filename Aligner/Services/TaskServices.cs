using System;
using System.Runtime.CompilerServices;
using Aligner.Models;

namespace Aligner.Services;

public class TaskServices
{
    public List<TaskList> Operation = [];

    public Result<TaskList> CreateList(string Name, string Desc = "No Description Added")
    {
        try
        {
            TaskList NewList = new(Name, Desc);
            Operation.Add(NewList);
            return Result<TaskList>.Ok(NewList, "List Created successfully");
        }
        catch (Exception e)
        {
            return Result<TaskList>.Fail(e);
        }
    }

    public Result<TaskItem> AddTask( int ListIndex, string Name, string Desc = "No Description Available" )
    {
        if (ListIndex > Operation.Count - 1)
        {
            return Result<TaskItem>.Fail("ListIndex cannot exceed the number of Lists present");
        }
        try
        {
            TaskItem NewTask = new(Name, Desc);
            Operation[ListIndex].List.Add(NewTask);
            return Result<TaskItem>.Ok(NewTask, "Task added successfully");
        }
        catch (Exception e)
        {
            return  Result<TaskItem>.Fail(e);
        }
    }


}
