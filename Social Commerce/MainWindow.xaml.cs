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

namespace Social_Commerce
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            String content = "테스트입니다 ㅋㅋㅋㅋ\n잘 되나 모르겠다.";
            String Thumb_URL = "https://t1.daumcdn.net/cfile/tistory/9972DD355BF0416F33";
            Custom_List_Item custom_List_Item1 = new Custom_List_Item(Thumb_URL, content);
            CustomListBox1.Items.Add(custom_List_Item1);
            CustomListBox1.Items.Add(custom_List_Item1);
            CustomListBox1.Items.Add(custom_List_Item1);
            CustomListBox1.Items.Add(custom_List_Item1);
            CustomListBox1.Items.Add(custom_List_Item1);



        }
    }
}
