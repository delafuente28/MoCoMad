using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MoCoMad.Controllers
{
    public class ChargersController : Controller
    {
        public IActionResult ChargersMap()
        {
            return View();
        }
    }
}
