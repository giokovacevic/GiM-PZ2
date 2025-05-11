using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkService.Model
{
    public class MeterType
    {
        public static MeterType INTERVAL = new MeterType("Interval", "interval.png");
        public static MeterType SMART = new MeterType("Smart", "smart.png");

        private string stringValue;
        private string imageUrl;

        public MeterType(string stringValue, string imageUrl)
        {
            this.StringValue = stringValue;
            this.ImageUrl = imageUrl;
        }

        public static MeterType generateTypeOfMeter(string type)
        {
            if(type.Equals(INTERVAL.StringValue))
            {
                return MeterType.INTERVAL;
            }else if(type.Equals(SMART.StringValue))
            {
                return MeterType.SMART;
            }
            else
            {
                return null;
            }
        }

        public string StringValue { get => stringValue; set => stringValue = value; }
        public string ImageUrl { get => imageUrl; set => imageUrl = value; }
    }
}
