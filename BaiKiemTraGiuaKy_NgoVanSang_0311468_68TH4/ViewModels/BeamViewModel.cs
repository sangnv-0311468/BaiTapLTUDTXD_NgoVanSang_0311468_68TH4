using BaiKiemTraGiuaKy_NgoVanSang_0311468_68TH4.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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
            //đây chỉ code test ví dụ thôi
            double As = (beam.M * 1e6) / (beam.RebarMaterial.Rs * beam.h0);
            beam.As = As;
            beam.BaiToan = "Cốt đơn";
        }
        #endregion
    }
}
