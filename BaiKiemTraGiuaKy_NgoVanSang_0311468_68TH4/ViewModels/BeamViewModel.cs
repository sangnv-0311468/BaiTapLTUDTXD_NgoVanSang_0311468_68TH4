using BaiKiemTraGiuaKy_NgoVanSang_0311468_68TH4.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace BaiKiemTraGiuaKy_NgoVanSang_0311468_68TH4.ViewModels
{
    public class BeamViewModel : INotifyPropertyChanged
    {
        //Bước 1
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        //Bước 2. khai báo các biến để binding với view
        //1. khai danh sách dầm BeamList
        public ObservableCollection<BeamModel> BeamList { get; set; } = new ObservableCollection<BeamModel>();
        //2. khai báo dầm hiện tại CurrentBeam
        public BeamModel CurrentBeam { get; set; } = new BeamModel();
        //3. khai báo các danh sách vật liệu để binding với combobox trong view
        public ObservableCollection<ConcreteMaterialModel> ConcreteMaterialList { get; set; } = new ObservableCollection<ConcreteMaterialModel>();
        public ObservableCollection<RebarMaterialModel> RebarMaterialList { get; set; } = new ObservableCollection<RebarMaterialModel>();
        //Bước 3. Khai báo các thành phần (fields, properties, methods) để xử lý logic cho view

        #region Khai báo fields 
        private int _id;
        private string _mark;
        private string _note;
        private double _b;
        private double _h;
        private double _a;
        private double _h0;
        private double _m;
        private ConcreteMaterialModel _concreteMaterial;
        private RebarMaterialModel _rebarMaterial;
        private double _alphaM;
        private double _alphaR;
        private double _xi;
        private double _xiR;
        private double _as;
        private double _mu;
        private string _baitoan;
        #endregion
        #region Khai báo properties
        public int Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }
        public string Mark
        {
            get => _mark;
            set { _mark = value; OnPropertyChanged(); }
        }
        public string Note
        {
            get => _note;
            set { _note = value; OnPropertyChanged(); }
        }
        public double b
        {
            get => _b;
            set { _b = value; OnPropertyChanged(); }
        }
        public double h
        {
            get => _h;
            set { _h = value; OnPropertyChanged(); }
        }
        public double a
        {
            get => _a;
            set { _a = value; OnPropertyChanged(); }
        }
        public double h0
        {
            get => _h0;
            set { _h0 = value; OnPropertyChanged(); }
        }
        public double Xi
        {
            get => _xi;
            set { _xi = value; OnPropertyChanged(); }
        }
        public double XiR
        {
            get => _xiR;
            set { _xiR = value; OnPropertyChanged(); }
        }
        public double M
        {
            get => _m;
            set { _m = value; OnPropertyChanged(); }
        }
        public ConcreteMaterialModel ConcreteMaterial
        {
            get => _concreteMaterial;
            set { _concreteMaterial = value; OnPropertyChanged(); }
        }
        public RebarMaterialModel RebarMaterial
        {
            get => _rebarMaterial;
            set { _rebarMaterial = value; OnPropertyChanged(); }
        }
        public double AlphaM
        {
            get => _alphaM;
            set { _alphaM = value; OnPropertyChanged(); }
        }
        public double AlphaR
        {
            get => _alphaR;
            set { _alphaR = value; OnPropertyChanged(); }
        }
        public double As
        {
            get => _as;
            set { _as = value; OnPropertyChanged(); }
        }
        public double Mu
        {
            get => _mu;
            set { _mu = value; OnPropertyChanged(); }
        }
        public string BaiToan
        {
            get => _baitoan;
            set { _baitoan = value; OnPropertyChanged(); }
        }
        #endregion

        //Khai báo Command
        public ICommand AddBeamCommand { get; }
        public ICommand CalBeamCommand { get; }

        public ICommand RemoveBeamCommand { get; }

        //constructor-hàm khởi tạo
        public BeamViewModel()
        {
            //Khởi tạo danh sách vật liệu bê tông
            ConcreteMaterialList.Add(new ConcreteMaterialModel { Name = "B20", Rb = 11.5, Rbt = 0.9, Eb = 27500 });
            ConcreteMaterialList.Add(new ConcreteMaterialModel { Name = "B25", Rb = 14.5, Rbt = 1.05, Eb = 30000 });
            ConcreteMaterialList.Add(new ConcreteMaterialModel { Name = "B30", Rb = 17, Rbt = 1.15, Eb = 32500 });
            //khởi tạo danh sách vật liệu cốt thép
            RebarMaterialList.Add(new RebarMaterialModel { Name = "CB300-V", Rs = 260, Rsc = 260 });
            RebarMaterialList.Add(new RebarMaterialModel { Name = "CB400-V", Rs = 350, Rsc = 350 });
            //Khởi tạo Command
            AddBeamCommand = new RelayCommand(AddBeamMethod);
            CalBeamCommand = new RelayCommand(CalBeamMethod);
            RemoveBeamCommand = new RelayCommand(RemoveBeamMethod);
        }

        #region khai báo các  phương thức thực thi command
        private void AddBeamMethod()
        {
            BeamModel _newbeam = new BeamModel(); //khởi tạo 1 đối tượng dầm mới
                                                  //lấy thông tin  từ viewmodel gán vào _beam
            _newbeam.Mark = Mark;
            _newbeam.b = b;
            _newbeam.h = h;
            _newbeam.a = a;
            _newbeam.M = M;
            _newbeam.ConcreteMaterial = ConcreteMaterial;
            _newbeam.RebarMaterial = RebarMaterial;
            _newbeam.Id = BeamList.Count + 1;
            _newbeam.h0 = _newbeam.h - _newbeam.a;
            _newbeam.AlphaR = 0.371;
            _newbeam.XiR = 0.493;

            //thêm dầm hiện tại vào danh sách dầm BeamList
            if (BeamList.Any(b => b.Mark == _newbeam.Mark))
            {
                //hiển thị thông báo lỗi nếu mã hiệu trùng
                System.Windows.MessageBox.Show("Mã hiệu dầm đã tồn tại. Vui lòng nhập mã hiệu khác.", "Lỗi", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return;
            }
            else
            {
                //thêm dầm hiện tại vào danh sách dầm BeamList
                BeamList.Add(_newbeam);
            }
           
        }
        private void CalBeamMethod()
        {
            if (BeamList.Count > 0)
            {
                foreach (var beam in BeamList)
                {
                    //gọi hàm tính toán As dầm
                    TinhToanAs(beam);
                }
            }
        }

        private void TinhToanAs(BeamModel beam)  //xem sơ đồ khối rồi mình code theo thuật toán
        {
            //Đơn vị KN-m
            //1.Input - đầu vào
            double b = beam.b;
            double a = beam.a;
            double h = beam.h;
            double M = beam.M;
            double Rb = beam.ConcreteMaterial.Rb;
            double Rs = beam.RebarMaterial.Rs;
            double Rsc = beam.RebarMaterial.Rsc;

            double mu_min = 0.1;//%
            //2.Output đầu ra
            double As = 0;
            double a1 = a; // Giả sử a' = a
            double As1 = 0;  // As' tính toán cốt kép
            double Mu = 0; 
            string Note = "";
            string BaiToan = "";

            //3. Process - xử lýmpa to kn/m
            double AlphaR = 0.371;
            double XiR = 0.493;
            double h0 = h - a;

            //tính alphaM  KNm / MPa * m*m*m
            //quy đổi từ đơn vị 1 MPa =  1000 KN/ m2 
            // KN*m /(KN/m2 * m * m * m) = KN*m / (KN*m) = 1
            double AlphaM = M / (1000 * Rb * b * h0 * h0);
            // kiểm tra alphaM có nhỏ hơn alphaR không? 
            if (AlphaM <= AlphaR) //cốt đơn
            {
                //tính xi
                double Xi = 0.5 * (1 + Math.Sqrt(1 - 2 * AlphaM));
                //tính As 
                As = M / (1000 * Rs * Xi * h0);
                Mu = 100 * As / (b * h0); //%
                //kiểm hàm lượng cốt thép tối thiểu
                if (Mu <= mu_min)
                {
                    beam.Note = "Mu <= Mu_min";
                    beam.AlphaM = AlphaM;
                    beam.As = As * 1e4; //m2 = 10000 cm2
                    beam.Mu = Mu;
                    beam.BaiToan = "Cốt đơn";
                }
                else
                {
                    //lưu dữ liệu tính toán
                    beam.AlphaM = AlphaM;
                    beam.As = As * 1e4; //m2 = 10000 cm2
                    beam.Mu = Mu;
                    beam.BaiToan = "Cốt đơn";
                    beam.Note = "Mu > Mu_min";
                }
            }
            else
            {
                As1 = (M - AlphaR * Rb * b * h0 * h0) / Rsc * (h0 - a1); //tính As' cốt kép
                As = ((XiR * Rb) / (Rs * h0)) + (Rsc * As1) / (Rs);
                Mu = 100 * As / (b * h0); //%
                if (AlphaM <= 0.5) //bài toán = cốt kép
                {
                    
                    if (Mu <= mu_min)
                    {
                        beam.AlphaM = AlphaM;
                        beam.As = As * 1e4; //m2 = 10000 cm2
                        beam.Mu = Mu;
                        beam.BaiToan = "Cốt kép";
                        beam.Note = "Mu <= Mu_min";
                    }
                    else
                    {
                        beam.AlphaM = AlphaM;
                        beam.As = As * 1e4; //m2 = 10000 cm2
                        beam.Mu = Mu;
                        beam.BaiToan = "Cốt kép";
                        
                    }
                }
                else  //bài toán = không thảo mãn 
                {
                    beam.BaiToan = "Không thảo mãn";
                }

            }
        }
        private void RemoveBeamMethod()
        {
            //dầm đang chọn select trong datagrid là CurrentBeam, nên ta sẽ xóa CurrentBeam khỏi BeamList
            if (CurrentBeam != null && BeamList.Contains(CurrentBeam))
            {
                var result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa dầm {CurrentBeam.Mark}?",
                    "Xác nhận",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    BeamList.Remove(CurrentBeam);
                }

            }
            else
            {
                MessageBox.Show("Vui lòng chọn dầm cần xóa trong danh sách.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
