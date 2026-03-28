using ETABSv1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapClass_DuAnMau_ThietKeDam.Models
{
    public class EtabsAPI_PropFrame
    {
        public int NumberNames { get; set; }
        public string MyName { get; set; }
        public eFramePropType PropType { get; set; } // Kiểu Enum của ETABS

        // Các thông số kích thước tiết diện (tương ứng t3, t2, tf, tw...)
        public double T3 { get; set; }
        public double T2 { get; set; }
        public double Tf { get; set; }
        public double Tw { get; set; }
        public double T2b { get; set; }
        public double Tfb { get; set; }

        // Constructor mặc định
        public EtabsAPI_PropFrame() { }

    }
}
