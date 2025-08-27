using System;
using System.Runtime.CompilerServices;
using Aligner.Models;

namespace Aligner.Services;

// Setting Aliases
using ListResult = Result<TaskList>;
using TaskResult = Result<TaskItem>;

public class TaskServices
{
    private List<TaskList> ListStorage = [];

    public ListResult CreateList(string Name, string Desc = "No Description Added")
    {
        try
        {
            TaskList NewList = new(Name, Desc);
            ListStorage.Add(NewList);

            return ListResult.Ok(NewList, "List Created successfully");
        }
        catch (Exception e)
        {
            return ListResult.Fail(e);
        }
    }

    public TaskResult AddTask(int ListIndex, string Name, string Desc = "No Description Available")
    {
        try
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(ListIndex, ListStorage.Count);

            TaskItem NewTask = new(Name, Desc);
            ListStorage[ListIndex].List.Add(NewTask);

            return TaskResult.Ok(NewTask, "Task added successfully");
        }
        catch (Exception e)
        {
            return TaskResult.Fail(e);
        }
    }

    public TaskResult DeleteTask(int ListIndex, int TaskIndex)
    {
        try
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(ListIndex, ListStorage.Count);
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(TaskIndex, ListStorage[ListIndex].List.Count);

            ListStorage[ListIndex].List.RemoveAt(TaskIndex);
            return TaskResult.Ok("Deleted Task successfully");
        }
        catch (ArgumentOutOfRangeException e)
        {
            return TaskResult.Fail(e);
        }
    }

    public ListResult DeleteList(int ListIndex)
    {
        try
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(ListIndex, ListStorage.Count);

            ListStorage.RemoveAt(ListIndex);
            return ListResult.Ok("Task List deleted successfully");
        }
        catch (ArgumentOutOfRangeException e)
        {
            return ListResult.Fail(e);
        }
    }

    public TaskResult UpdateTask(int ListIndex, int TaskIndex, string? Name, string? Desc)
    {
        try
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(ListIndex, ListStorage.Count);
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(TaskIndex, ListStorage[ListIndex].List.Count);

            if (Name != null) ListStorage[ListIndex].List[TaskIndex].TaskName = Name;
            if (Desc != null) ListStorage[ListIndex].List[TaskIndex].Desc = Desc;

            return TaskResult.Ok("Task Updated Successfully");
        }
        catch (Exception e)
        {
            return TaskResult.Fail(e);
        }
    }

    public ListResult UpdateList(int ListIndex, string? Name, string? Desc)
    {
        try
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(ListIndex, ListStorage.Count);

            if (Name != null) ListStorage[ListIndex].Name = Name;
            if (Desc != null) ListStorage[ListIndex].Desc = Desc;

            return ListResult.Ok("List Updated Successfully");
        }
        catch (Exception e)
        {
            return ListResult.Fail(e);
        }
    }

    // Getters
    public Result<List<TaskList>> GetAllLists() => Result<List<TaskList>>.Ok(ListStorage, "Successfully Retrived all lists");

    public ListResult GetListByIndex(int ListIndex)
    {
        try
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(ListIndex, ListStorage.Count);

            return ListResult.Ok(ListStorage[ListIndex], "Successfully Fetched List");
        }
        catch (Exception e)
        {
            return ListResult.Fail(e);
        }
    }

    public TaskResult GetTaskByIndex(int ListIndex, int TaskIndex)
    {
        try
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(ListIndex, ListStorage.Count);
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(TaskIndex, ListStorage[ListIndex].List.Count);

            return TaskResult.Ok(ListStorage[ListIndex].List[TaskIndex], "Successfully Fetched Task");

        }
        catch (Exception e)
        {
            return TaskResult.Fail(e);
        }
    }

    public Result<bool> CheckAndUpdateListStatus(int ListIndex)
    {
        try
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(ListIndex, ListStorage.Count);

            TaskList targetList = ListStorage[ListIndex];
            int count = 0;

            for (int i = 0; i < targetList.List.Count; i++)
            {
                if (targetList.List[i].IsCompleted) count++;
            }

        bool wasCompleted = targetList.IsCompleted;
        targetList.IsCompleted = count == targetList.List.Count && targetList.List.Count > 0;
        
        return Result<bool>.Ok(targetList.IsCompleted, "Updated list status successfully");
        }
        catch (Exception e)
        {
            return Result<bool>.Fail(e);
        }
    }

    public Result<bool> ToggleTaskStatus(int ListIndex, int TaskIndex)
    {
        try
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(ListIndex, ListStorage.Count);
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(TaskIndex, ListStorage[ListIndex].List.Count);

            ListStorage[ListIndex].List[TaskIndex].IsCompleted = !ListStorage[ListIndex].List[TaskIndex].IsCompleted;

            return Result<bool>.Ok("Toggled task's Status");
        }
        catch (Exception e)
        {
            return Result<bool>.Fail(e);
        }
    }
}
