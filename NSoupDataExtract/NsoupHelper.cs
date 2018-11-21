using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MoCoMad.Models;
using NSoup;
using NSoup.Select;
using NSoup.Nodes;

namespace MoCoMad.NSoupDataExtract
{
    public class NsoupHelper
    {
        public Document UrlConnection(string url)
        {
            IConnection connection = NSoupClient.Connect(url);
            connection.Timeout(30000);
            Document document = connection.Get();

            return document;
        }

        public string CheckLicensePlate(string licPlate)
        {
            string _licensePlate = licPlate;
            Document doc = UrlConnection("http://www.dgt.es/es/seguridad-vial/distintivo-ambiental/index.shtml?accion=1&matriculahd=&matricula="+ _licensePlate + "&submit=Comprobar");
            string result = doc.Select("div.mensajeResultadoConImagen p").Text;
            string[] splitList = result.Split('.');
            string environmentHallmark = splitList[0];

            return environmentHallmark;
        }

        public HtmlData FillHtmlData(Document doc, string _licPlate)
        {
            HtmlData data = new HtmlData();

            data.Title = doc.Title;
            data.Url = doc.BaseUri;
            data.LicensePlate = _licPlate;
            data.EnvironmentalHallmark = CheckLicensePlate(_licPlate);

            #region CITY NAMES

            Elements citys = doc.Select("div#pollution_table th");

            for (int i = 0; i < citys.Count(); i++)
            {
                data.CityList.Add(citys[i].Text());
                i = i + 7;
            }

            #endregion CITY NAMES

            #region ICA BY CITY

            Elements _ica = doc.Select("div#pollution_table td");

            for (int i = 0; i < _ica.Count(); i++)
            {
                string _icacity = _ica[i].ChildNodes[0].ToString();
                string icacode = _ica[i + 1].ChildNodes[0].ToString();
                string[] icaos = icacode.Split('>', '<');
                string _icaoValue = icaos[2];

                data.ICAByCityList.Add(new KeyValuePair<string, string>(_icacity, _icaoValue));

                i = i + 7;
            }

            #endregion ICA BY CITY

            #region META

            foreach (Element meta in doc.Select("meta"))
            {
                data.MetadataList.Add(meta.OuterHtml());
            }

            #endregion META

            #region IMAGES

            foreach (Element image in doc.Select("figure"))
                data.ImageList.Add(image.Attr("src"));

            #endregion IMAGES

            #region ANCHOR

            foreach (Element anchor in doc.Select("a"))
                data.AnchorList.Add(anchor.Attr("href"));

            #endregion ANCHOR

            return data;
        }

    }
}
