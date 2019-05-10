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
    public partial class UserControlInicio : UserControl
    {
        public UserControlInicio()
        {
            InitializeComponent();
            tTopics.Text = MainWindow.user.TopicsLearn.ToString();
            tWords.Text = MainWindow.user.WordsLearn.ToString();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.grid.Children.Clear();
            MainWindow.grid.Children.Add(new UserControlEscolha());

        }
    }
}
