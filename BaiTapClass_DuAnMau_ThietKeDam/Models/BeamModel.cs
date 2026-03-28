using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapClass_DuAnMau_ThietKeDam.Models
{
    public class BeamModel
    {
        #region Fields
        private string _id;
        private string _mark; //mã hiệu
        private string _story; //tầng
        private double _length; //chiều dài
        private double _volume; //thể tích
        private double _asSelected; // Diện tích cốt thép chọn (mm2)
        public double AsSelected
        {
            get => _asSelected;
            set => _asSelected = value;
        }

        // Khai báo quan hệ của beam và các class Etabs API
        private EtabsAPI_Frame _frame;
        private EtabsAPI_FrameForce _frameForces;


        #endregion

        //properties
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Mark
        {
            get { return _mark; }
            set { _mark = value; }
        }
        public string Story
        {
            get { return _story; }
            set { _story = value; }
        }
        public double Length
        {
            get { return _length; }
            set { _length = value; }
        }
        public double Volume
        {
            get { return _volume; }
            set { _volume = value; }
        }
        public EtabsAPI_Frame Frame
        {
            get { return _frame; }
            set { _frame = value; }
        }

        //constructor - hàm khởi tạo
        BeamModel(string id, string mark, string story)
        {
            _id = id;
            _mark = mark;
            _story = story;
        }


        public bool CheckTTGH1()
        {
            // 1. Lấy mô-men lớn nhất (M3) từ danh sách nội lực ETABS
            if (Frame == null || Frame.FrameForces == null || Frame.FrameForces.Count == 0) return false;

            // Lấy giá trị tuyệt đối Max của M3 trong danh sách các Station
            double mMax = Frame.FrameForces.Max(f => Math.Abs(f.M3));

            // 2. Giả định các thông số vật liệu (Nên lấy từ class Vật liệu của ông)
            double Rb = 14.5; // Bê tông B25 (MPa)
            double Rs = 280;  // Thép CB300-V (MPa)
            double b = 220;   // Chiều rộng dầm (mm) 
            double h = 400;   // Chiều cao dầm (mm)
            double a = 25;    // Lớp bảo vệ (mm) 

            // 3. Tính toán khả năng chịu uốn Mu
            double h0 = h - a;
            // Tính chiều cao vùng nén x = (Rs * As) / (Rb * b)
            double x = (Rs * _asSelected) / (Rb * b);

            // Công thức Mu = Rb * b * x * (h0 - 0.5 * x)
            double mu = Rb * b * x * (h0 - 0.5 * x) * Math.Pow(10, -6); // Đổi đơn vị sang kN.m

            // 4. So sánh: Nếu Mu >= Mmax thì đạt (true)
            return mu >= mMax;
        }
    }
}
