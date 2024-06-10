using Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Models;

namespace UI.Controllers;
public class HomeController(IBusService busService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var result = await busService.ListKaraNoktaAsync();
        return View("Index",result);
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
}
