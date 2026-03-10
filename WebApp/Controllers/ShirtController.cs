using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Respozitories;

namespace WebApp.Controllers;

public class ShirtController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View(ShirtRespozitory.GetShirts()); // przekazujemy listę koszulek do widoku!!!! 
    }
}