using ETABSv1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapClass_DuAnMau_ThietKeDam.Models
{
    public class EtabsAPI_FrameForce
    {
        // Thông tin định danh
        public string Name { get; set; }
        public eItemTypeElm ItemTypeElm { get; set; }
        public int NumberResults { get; set; }

        // Thông tin vị trí phần tử
        public string Obj { get; set; }
        public double ObjSta { get; set; } // Vị trí trên đối tượng (Station)
        public string Elm { get; set; }
        public double ElmSta { get; set; }

        // Thông tin trường hợp tải trọng
        public string LoadCase { get; set; }
        public string StepType { get; set; }
        public double StepNum { get; set; }

        // Giá trị nội lực (Quan trọng nhất để tính thép)
        public double P { get; set; }  // Lực dọc
        public double V2 { get; set; } // Lực cắt phương 2
        public double V3 { get; set; } // Lực cắt phương 3
        public double T { get; set; }  // Momen xoắn
        public double M2 { get; set; } // Momen uốn phương 2
        public double M3 { get; set; } // Momen uốn phương 3 (Momen chính của dầm)

        public EtabsAPI_FrameForce() { }
    }
}
