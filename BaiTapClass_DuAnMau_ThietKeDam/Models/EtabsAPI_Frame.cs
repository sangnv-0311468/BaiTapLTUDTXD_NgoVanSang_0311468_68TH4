using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapClass_DuAnMau_ThietKeDam.Models
{
    public class EtabsAPI_Frame
    {
        //fields
        private string _myName;
        private string _propName;
        private double _point1X;
        private double _point1Y;
        private double _point1Z;
        //khai quan hệ 1-n giữa frame và frame force
        private ObservableCollection<EtabsAPI_FrameForce> _frameForces; //danh sách nội lực của dầm
        //properties
        public string MyName
        {
            get { return _myName; }
            set { _myName = value; }
        }
        public string PropName
        {
            get { return _propName; }
            set { _propName = value; }
        }
        public double Point1X
        {
            get { return _point1X; }
            set { _point1X = value; }
        }
        public double Point1Y
        {
            get { return _point1Y; }
            set { _point1Y = value; }
        }
        public double Point1Z
        {
            get { return _point1Z; }
            set { _point1Z = value; }
        }
        public ObservableCollection<EtabsAPI_FrameForce> FrameForces
        {
            get { return _frameForces; }
            set { _frameForces = value; }
        }
        //constructor

        //method
    }
}
