using BaiTapClass_DuAnMau_ThietKeDam.Views.View;
using System;
using ETABSv1;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BaiTapClass_DuAnMau_ThietKeDam.Views.UserControls
{
    /// <summary>
    /// Interaction logic for UserMenu.xaml
    /// </summary>
    public partial class UserMenu : UserControl
    {
        public UserMenu()
        {
            InitializeComponent();
        }

        private void rbt_Dam_Click(object sender, RoutedEventArgs e)
        {
            EtabsAPI_FramesView framesView = new EtabsAPI_FramesView();
            framesView.Show();
        }
        private cOAPI _etabsObject;
        private cSapModel _sapModel;

        private void rbt_Etabs_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cHelper helper = new Helper();

                _etabsObject = helper.GetObject("CSI.ETABS.API.ETABSObject");

                if (_etabsObject == null)
                {
                    MessageBox.Show("Không tìm thấy ETABS đang mở!");
                    return;
                }

                _sapModel = _etabsObject.SapModel;

                MessageBox.Show("Kết nối ETABS thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }
    }
}
