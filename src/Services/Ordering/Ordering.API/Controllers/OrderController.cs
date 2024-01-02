using Microsoft.AspNetCore.Mvc;

namespace Ordering.API.Controllers;

public class OrderController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}