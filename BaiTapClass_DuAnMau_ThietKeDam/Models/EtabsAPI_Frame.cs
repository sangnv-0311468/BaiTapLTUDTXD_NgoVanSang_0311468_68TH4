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
        private string _pointName1;
        private string _pointName2;
        private double _point1X;
        private double _point1Y;
        private double _point1Z;
        private double _point2X;
        private double _point2Y;
        private double _point2Z;
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
        public string PointName1
        {
            get { return _pointName1; }
            set { _pointName1 = value; }
        }
        public string PointName2
        {
            get { return _pointName2; }
            set { _pointName2 = value; }
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
        public double Point2X
        {
            get { return _point2X; }
            set { _point2X = value; }
        }
        public double Point2Y
        {
            get { return _point2Y; }
            set { _point2Y = value; }
        }
        public double Point2Z
        {
            get { return _point2Z; }
            set { _point2Z = value; }
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
