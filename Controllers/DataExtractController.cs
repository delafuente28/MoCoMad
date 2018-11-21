using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoCoMad.Models;
using MoCoMad.NSoupDataExtract;
using NSoup;
using NSoup.Nodes;

namespace MoCoMad.Controllers
{
    public class DataExtractController : Controller
    {
        // GET: DataExtract
        public ActionResult Index()
        {
            //string _url = "https://www.google.es";
            //NsoupHelper _helper = new NsoupHelper();
            //HtmlData _data = new HtmlData();

            //Document _doc = _helper.UrlConnection(_url);
            //_data = _helper.FillHtmlData(_doc, _licPlate);

            return View();
        }

        //// GET: DataExtract/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: DataExtract/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: DataExtract/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: DataExtract/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: DataExtract/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: DataExtract/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: DataExtract/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}




    }
}