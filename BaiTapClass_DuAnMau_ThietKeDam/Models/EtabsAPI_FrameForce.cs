using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapClass_DuAnMau_ThietKeDam.Models
{
    public class EtabsAPI_FrameForce
    {
        public double P { get; set; }  // Lực dọc
        public double V2 { get; set; } // Lực cắt 2-2
        public double V3 { get; set; } // Lực cắt 3-3
        public double T { get; set; }  // Momen xoắn
        public double M2 { get; set; } // Momen uốn 2-2
        public double M3 { get; set; } // Momen uốn 3-3 
        public string Station { get; set; } // Vị trí mặt cắt
    }
}
