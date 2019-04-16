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

namespace English
{
    /// <summary>
    /// Логика взаимодействия для UserControlTraner.xaml
    /// </summary>
    public partial class UserControlTraner : UserControl
    {
        public UserControlTraner()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int[] mas = new int[5];
            for (int i = 0; i < mas.Length; i++)
            {
                int a = rnd.Next(0, 5);
                if (!mas.Contains(a))
                {
                    T1 = 
                }
                else
                    i--;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
