using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoCoMad.Models;
using MoCoMad.NSoupDataExtract;
using NSoup.Nodes;

namespace MoCoMad.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string _url = "https://www.eltiempo.es/calidad-aire/madrid";
            NsoupHelper _helper = new NsoupHelper();
            HtmlData _data = new HtmlData();

            //INPUT LICENSE PLATE
            string _licPlate = "2265HTT";
            Document _doc = _helper.UrlConnection(_url);
            _data = _helper.FillHtmlData(_doc, _licPlate);

            _data.LicensePlate = null;
            _data.EnvironmentalHallmark = null;

            return View(_data);
        }

        [HttpPost]
        public IActionResult Index(HtmlData model)
        {
            if (ModelState.IsValid)
            {
                string _url = "https://www.eltiempo.es/calidad-aire/madrid";
                NsoupHelper _helper = new NsoupHelper();
                HtmlData _data = new HtmlData();

                string _licPlate = model.LicensePlate;
                Document _doc = _helper.UrlConnection(_url);
                _data = _helper.FillHtmlData(_doc, _licPlate);

                return View(_data);
            }
            else
            {
                return View();
            }
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Map()
        {
            ViewData["Message"] = "Google Maps.";

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
    }
}
