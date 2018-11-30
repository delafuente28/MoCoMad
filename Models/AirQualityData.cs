using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MoCoMad.Models
{
    public class AirQualityData
    {
        #region PROPERTIES

        public string Station { get; set; }

        public string Magnitude { get; set; }

        public string Technique { get; set; }

        public string HourData { get; set; }

        public string Year { get; set; }

        public string Month { get; set; }

        public string Day { get; set; }

        public ObservableCollection<string> HourMeasure { get; set; }
        
        #endregion PROPERTIES
    }
}
