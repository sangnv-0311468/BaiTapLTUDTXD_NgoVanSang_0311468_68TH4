using Bai2_TaoMenuRibbon_Usercontrol_Pages.Views;
using System;
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

namespace Bai2_TaoMenuRibbon_Usercontrol_Pages.UserControls
{
    /// <summary>
    /// Interaction logic for Usermenu.xaml
    /// </summary>
    public partial class Usermenu : UserControl
    {
        public Usermenu()
        {
            InitializeComponent();
        }

        private void btn_KNEtabs_Click(object sender, RoutedEventArgs e)
        {
            KetnoiEtabs ketnoiEtabs = new KetnoiEtabs();
            ketnoiEtabs.Show();
        }

        private void btn_chisodat_Click(object sender, RoutedEventArgs e)
        {
            Khaibaodiachat khaibaodiachat = new Khaibaodiachat();
            khaibaodiachat.Show();
        }

        private void btn_VLDaiCoc_Click(object sender, RoutedEventArgs e)
        {
            Vatlieudaicoc vatlieudaicoc = new Vatlieudaicoc();
            vatlieudaicoc.Show();
        }
        private void btn_VLCoc_Click(object sender, RoutedEventArgs e)
        {
            Vatlieucoc thepcoc = new Vatlieucoc();
            thepcoc.Show();

        }
    }
}
