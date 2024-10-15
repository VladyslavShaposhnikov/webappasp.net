using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class CalculatorController : Controller
{
    // GET
    public IActionResult Form()
    {
        return View();
    }
    
    public IActionResult Result(string op, double x, double y)
    {
        ViewBag.result_x = x;
        ViewBag.result_y = y;
        
        ViewBag.result_op = op;
        
        switch(op)
        {
            case "add":
                ViewBag.Result = x + y;
                break;
            case "sub":
                ViewBag.Result = x - y;
                break;
            case "mul":
                ViewBag.Result = x * y;
                break;
            case "div":
                ViewBag.Result = x / y;
                break;
        }
        return View();
    }
}