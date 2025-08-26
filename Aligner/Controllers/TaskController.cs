using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Aligner.Controllers;

public class TaskController
{
    public IActionResult Index()
    {
        return View();
    }
}
