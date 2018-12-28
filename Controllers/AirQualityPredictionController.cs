using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoCoMad.Models;
using MoCoMad.MongoCosmosDB;
using Newtonsoft.Json;

namespace MoCoMad.Controllers
{
    public class AirQualityPredictionController : Controller
    {
        DBConnection _dbConnection = new DBConnection();

        public IActionResult AirQualityPrediction()
        {
            var data = _dbConnection.GetAirQualityDataFiltered();
            ObservableCollection<ChartData> _chartData = new ObservableCollection<ChartData>();
            int i = 1;

            foreach (var item in data)
            {
                if (int.Parse(item.Day) == (DateTime.Today.Day + 1) && int.Parse(item.Year) == 2017)
                {
                    foreach (var measure in item.HourMeasure)
                    {
                        ChartData _char = new ChartData();

                        int result;
                        int.TryParse(measure, out result);
                        _char.Measure = result;
                        _char.Hour = i;

                        i = i + 1;
                        _chartData.Add(_char);
                    }
                    i = 1;
                }

                if (int.Parse(item.Day) == (DateTime.Today.Day + 1) && int.Parse(item.Year) == 2018)
                {
                    for (int j = 0; j < item.HourMeasure.Count; j++)
                    {
                        _chartData[j].Measure2 = int.Parse(item.HourMeasure[j]);
                    }
                }
            }

            return View(_chartData);
        }

    }
}