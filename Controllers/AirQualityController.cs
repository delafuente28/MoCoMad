using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoCoMad.Models;
using MoCoMad.DataDownload;
using System.Collections.ObjectModel;

namespace MoCoMad.Controllers
{
    public class AirQualityController : Controller
    {
        public IActionResult Map()
        {
            DataDownloadHelper _helper = new DataDownloadHelper();
            ObservableCollection<AirQualityData> _data = new ObservableCollection<AirQualityData>();
            _data = _helper.DownloadAirQualityData();

            return View(_data);
        }

    }
}