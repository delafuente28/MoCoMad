using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoCoMad.Models
{
    public class HtmlData
    {
        #region PROPERTIES

        public string Url { get; set; }

        public string RawHtml { get; set; }

        public string Title { get; set; }

        public string EnvironmentalHallmark { get; set; }

        [Required]
        public string LicensePlate { get; set; }

        public ObservableCollection<string> CityList { get; set; }

        public ObservableCollection<KeyValuePair<string, string>> ICAByCityList { get; set; }

        public ObservableCollection<string> MetadataList { get; set; }

        public ObservableCollection<string> AnchorList { get; set; }

        public ObservableCollection<string> ImageList { get; set; }

        public ObservableCollection<string> CssClassList { get; set; }

        public ObservableCollection<string> CssRuleList { get; set; }

        #endregion PROPERTIES

        #region CONSTRUCTOR

        public HtmlData()
        {
            MetadataList = new ObservableCollection<string>();
            AnchorList = new ObservableCollection<string>();
            ImageList = new ObservableCollection<string>();
            CssClassList = new ObservableCollection<string>();
            CssRuleList = new ObservableCollection<string>();
            CityList = new ObservableCollection<string>();
            ICAByCityList = new ObservableCollection<KeyValuePair<string, string>>();
        }

        #endregion CONSTRUCTOR

        #region PUBLIC METHODS

        public void Clear()
        {
            Url = null;
            RawHtml = null;
            Title = null;
            EnvironmentalHallmark = null;
            MetadataList.Clear();
            AnchorList.Clear();
            ImageList.Clear();
            CssClassList.Clear();
            CssRuleList.Clear();
            CityList.Clear();
            ICAByCityList.Clear();
        }

        #endregion PUBLIC METHODS
    }
}
