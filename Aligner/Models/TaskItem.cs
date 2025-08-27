using System;

namespace Aligner.Models;

public class TaskItem(string Name, string Desc)
{
    public string TaskName { get; set; } = Name;
    public string Desc { get; set; } = Desc;
    public bool IsCompleted { get; set; } = false;
    public DateTime DateCreated { get; } = DateTime.UtcNow;
    public string OwnerId { get; } = "";
}
