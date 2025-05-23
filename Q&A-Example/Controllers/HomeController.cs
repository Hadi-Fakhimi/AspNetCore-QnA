using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Q_A_Example.Services.Interfaces;

namespace Q_A_Example.Controllers;

public class HomeController : Controller
{
    private readonly IMessageService _messageService;

    public HomeController(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public async Task<IActionResult> Index()
    {
        var tree = await _messageService.GetMessages();
        return View(tree);
    }

    [HttpPost]
    public async Task<IActionResult> Add(string content, int? parentMessageId)
    {
        var userId = HttpContext.Session.GetInt32("UserId");

        if (userId == null)
        {
            return Unauthorized(); 
        }
        await _messageService.AddMessage(content, parentMessageId,userId.Value);
        return RedirectToAction("Index");
    }

}
