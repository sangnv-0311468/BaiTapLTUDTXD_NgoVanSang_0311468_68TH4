using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapClass_DuAnMau_ThietKeDam.Models
{
    public class BeamModel
    {
        public string Id { get; set; }
        public string Mark { get; set; } //mã hiệu
        public string Story { get; set; } //tầng
        public double Length { get; set; } //chiều dài
        public double Volume { get; set; } //thể tích
                                           //khai báo quan hệ 1-1 của beam và frameEtabs
        public EtabsAPI_Frame Frame { get; set; }
        //khai báo quan hệ 1-n giữa beam và frame force
        public ObservableCollection<EtabsAPI_FrameForce> FrameForces { get; set; } //danh sách nội lực của dầm

    }

}
