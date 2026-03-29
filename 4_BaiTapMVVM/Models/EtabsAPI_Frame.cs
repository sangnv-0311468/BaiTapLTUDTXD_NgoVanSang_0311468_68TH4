using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_BaiTapMVVM.Models
{
    public class EtabsAPI_Frame
    {
        public int NumberNames { get; set; }
        public string Label { get; set; }
        public string MyName { get; set; }
        public string PropName { get; set; }
        public string StoryName { get; set; }
        public string PointName1 { get; set; }
        public string PointName2 { get; set; }
        public double Point1X { get; set; }
        public double Point1Y { get; set; }
        public double Point1Z { get; set; }
        public double Point2X { get; set; }
        public double Point2Y { get; set; }
        public double Point2Z { get; set; }
        public double Angle { get; set; }
        public double Offset1X { get; set; }
        public double Offset2X { get; set; }
        public double Offset1Y { get; set; }
        public double Offset2Y { get; set; }
        public double Offset1Z { get; set; }
        public double Offset2Z { get; set; }
        public int CardinalPoint { get; set; }
        public double Length { get; set; }
    }
}
