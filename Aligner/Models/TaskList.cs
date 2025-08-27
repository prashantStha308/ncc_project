using System;

namespace Aligner.Models;

public class TaskList(string Name, string Desc)
{
    public string Name { get; set; } = Name;
    public string Desc { get; set; } = Desc;
    public bool IsCompleted { get; set; } = false;
    public DateTime DateCreated { get; } = DateTime.UtcNow;
    public List<TaskItem> List = [];
    public string OwnerId { get; } = "";
}
