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
using System.Windows.Shapes;

namespace Bai2_TaoMenuRibbon_Usercontrol_Pages.Views
{
    /// <summary>
    /// Interaction logic for KetnoiEtabs.xaml
    /// </summary>
    public partial class KetnoiEtabs : Window
    {
        public KetnoiEtabs()
        {
            InitializeComponent();

            // Đợi Window load xong rồi mới bắt đầu chạy thanh tiến trình
            this.Loaded += KetnoiEtabs_Loaded;
        }

        private async void KetnoiEtabs_Loaded(object sender, RoutedEventArgs e)
        {
            await RunFakeConnection();
        }

        private async Task RunFakeConnection()
        {
            for (int i = 0; i <= 100; i++)
            {
                // Cập nhật giá trị thanh ProgressBar
                pgBar.Value = i;

                // Tăng tốc độ hoặc giảm tùy ý (50ms mỗi 1%)
                await Task.Delay(1);

                // Khi chạy xong thì đóng hoặc làm gì đó
                if (i == 100)
                {
                    lblStatus.Text = "Kết nối thành công!";
                    await Task.Delay(500); // Đợi xíu cho người dùng kịp nhìn
                    this.Close();
                }
            }
        }
    }
    
}
