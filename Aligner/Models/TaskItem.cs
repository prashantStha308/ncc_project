using System;

namespace Aligner.Models;

public class TaskItem(string Name, string Desc)
{
    public string TaskName { get; set; } = Name;
    public string Desc { get; set; } = Desc;
    public bool IsCompleted { get; private set; } = false;
    public DateTime DateCreated { get; private set; } = DateTime.Now.Date;
}
