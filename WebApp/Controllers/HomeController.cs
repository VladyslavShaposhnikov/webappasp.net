using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    public IActionResult About()
    {
        return View();
    }

    public IActionResult Calculator(Operator? op, double? x, double? y)
    {
        if (x is null || y is null)
        {
            ViewBag.errorMessage = "Niepoprawny format liczby w parametrze x lub x";
            return View("ErrorMessage");
        }
        if (op is not Operator)
        {
            ViewBag.errorMessage = "Nieznany operator";
            return View("ErrorMessage");
        }

        ViewBag.x = x;
        ViewBag.y = y;
        
        switch(op)
        {
            case Operator.add:
                ViewBag.Result = x + y;
                ViewBag.op = "+";
                break;
            case Operator.sub:
                ViewBag.Result = x - y;
                ViewBag.op = "-";
                break;
            case Operator.mul:
                ViewBag.Result = x * y;
                ViewBag.op = "*";
                break;
            case Operator.div:
                if (y == 0)
                {
                    ViewBag.errorMessage = "Nie mozna dzielic na 0";
                    return View("ErrorMessage");
                }
                ViewBag.Result = x / y;
                ViewBag.op = "/";
                break;
        }
        return View();
    }

    public enum Operator
    {
        add, sub, mul, div
    }

}
