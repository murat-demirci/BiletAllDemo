using Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers;
public class HomeController(IBusService busService) : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public async Task<JsonResult> ListKaraNokta()
    {
        var result = await busService.ListKaraNoktaAsync();
        return Json(result);
    }
}
