using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Xml;
using System.IO;
using MoCoMad.Models;
using System.Collections.ObjectModel;

namespace MoCoMad.DataDownload
{
    public class DataDownloadHelper
    {
        public ObservableCollection<AirQualityData> DownloadAirQualityData()
        {
            string url = "http://www.mambiente.munimadrid.es/opendata/horario.txt";

            WebClient client = new WebClient();
            using (var stream = client.OpenRead(url))
            using (var reader = new StreamReader(stream))
            {
                string line;
                StreamWriter sw = new StreamWriter(@"horario.txt", false);
                while ((line = reader.ReadLine()) != null)
                {
                    sw.WriteLine(line);
                }
                sw.Close();
            }
            return ReadAirQualityData();
        }

        public ObservableCollection<AirQualityData> ReadAirQualityData2017(string month)
        {
            ObservableCollection<AirQualityData> _airQualityDataCollection = new ObservableCollection<AirQualityData>();

            var lines = File.ReadAllLines(month + ".txt").Select(a => a.Split(','));
            var csv = from line in lines
                      select (from piece in line
                              select piece).ToArray();

            var arrayLines = csv.ToArray();

            for (int i = 0; i < arrayLines.Count(); i++)
            {
                var line = arrayLines[i];

                AirQualityData _data = new AirQualityData();
                _data.Station = line[0] + line[1] + line[2];
                _data.Magnitude = line[3];
                _data.Technique = line[4];
                _data.HourData = line[5];
                _data.Year = line[6];
                _data.Month = line[7];
                _data.Day = line[8];
                _data.HourMeasure = new ObservableCollection<string>();

                int j = 9;
                while (j < line.Length)
                {
                    int c = j + 1;
                    if (line[c] == "V")
                        _data.HourMeasure.Add(line[j]);
                    else
                        _data.HourMeasure.Add("N");

                    j = j + 2;
                }

                _airQualityDataCollection.Add(_data);
            }

            return _airQualityDataCollection;
        }

        private ObservableCollection<AirQualityData> ReadAirQualityData()
        {
            ObservableCollection<AirQualityData> _airQualityDataCollection = new ObservableCollection<AirQualityData>();

            var lines = File.ReadAllLines(@"horario.txt").Select(a => a.Split(','));
            var csv = from line in lines
                      select (from piece in line
                              select piece).ToArray();

            var arrayLines = csv.ToArray();

            for (int i = 0; i < arrayLines.Count(); i++)
            {
                var line = arrayLines[i];

                AirQualityData _data = new AirQualityData();
                _data.Station = line[0] + line[1] + line[2];
                _data.Magnitude = line[3];
                _data.Technique = line[4];
                _data.HourData = line[5];
                _data.Year = line[6];
                _data.Month = line[7];
                _data.Day = line[8];
                _data.HourMeasure = new ObservableCollection<string>();

                int j = 9;
                while (j < line.Length)
                {
                    int c = j + 1;
                    if (line[c] == "V")
                        _data.HourMeasure.Add(line[j]);
                    else
                        _data.HourMeasure.Add("N");

                    j = j + 2;
                }

                _airQualityDataCollection.Add(_data);
            }

            return _airQualityDataCollection;
        }


    }
}
