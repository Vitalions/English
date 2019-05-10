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
using System.Data.OleDb;

namespace English
{
    public class User
    {
        public User(string Login)
        {
            this.Login = Login;
            try
            {
                OleDbConnection dbase;
                string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Users.mdb;";
                dbase = new OleDbConnection(connectionString);
                dbase.Open();
                string query = "SELECT u_topic, u_words FROM users WHERE u_login = '" + Login + "'";
                OleDbCommand command = new OleDbCommand(query, dbase);

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TopicsLearn = Convert.ToInt32(reader[0]);
                    TopicsLearn = Convert.ToInt32(reader[1]);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public int TopicsLearn;
        public int WordsLearn;
        public int WordsLearnToday;
        public string Login;
    }
    public partial class MainWindow : Window
    {
        public static Grid grid;
        public static User user;
        public MainWindow(string Login)
        {
            user = new User(Login);
            InitializeComponent();
            ListViewAdmin.Visibility = Visibility.Collapsed;
        }

        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);
            
            grid = GridPrincipal;
            switch (index)
            {
                case 0:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new UserControlInicio());
                    break;
                case 1:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new UserControlEscolha());
                    break;
                case 2:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new UserControlLearnAdd());
                    break;
                case 4:
                    Login1.MainWindow login = new Login1.MainWindow();
                    login.Show();
                    this.Close();
                    break;
                default:
                    break;
            }
        }

        private void MoveCursorMenu(int index)
        {
            TrainsitionigContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (100 + (60 * index)), 0, 0);
        }
    }
}
