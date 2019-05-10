using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.OleDb;
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
    /// Логика взаимодействия для UserControlLearnAdd.xaml
    /// </summary>
    public partial class UserControlLearnAdd : UserControl
    {
        public OleDbConnection dbase;
        public UserControlLearnAdd()
        {

            InitializeComponent();
            DBConnect();
        }
        public void DBConnect()
        {
            try
            {
                string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Users.mdb;";
                dbase = new OleDbConnection(connectionString);
                dbase.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool check = false;
            string[] words;
            if (tName.Text.Length == 0)
            {
                tName.BorderBrush = Brushes.Red;
                check = true;
            }
            if(tEnWord.Text.Length == 0)
            {
                tEnWord.BorderBrush = Brushes.Red;
                check = true;
            }
            else
            {
                words = tEnWord.Text.ToString().Split(new char[] { ' ' });
                if(words.Length < 5)
                {
                    MessageBox.Show("Количество слов не должно быть меньше 5!");
                    check = true;
                }
            }
            if(tTranscriptionWord.Text.Length == 0)
            {
                tTranscriptionWord.BorderBrush = Brushes.Red;
                check = true;
            }
            else
            {
                string[] words2 = tEnWord.Text.ToString().Split(new char[] { ' ' });
                words = tEnWord.Text.ToString().Split(new char[] { ' ' });
                if (words.Length != words2.Length)
                {
                    MessageBox.Show("Количество слов должно совпадать!");
                    check = true;
                }
            }
            if(tRusWord.Text.Length == 0)
            {
                tRusWord.BorderBrush = Brushes.Red;
                check = true;
            }
            else
            {
                string[] words2 = tRusWord.Text.ToString().Split(new char[] { ' ' });
                words = tEnWord.Text.ToString().Split(new char[] { ' ' });
                if (words.Length != words2.Length)
                {
                    MessageBox.Show("Количество слов должно совпадать!");
                    check = true;
                }
            }
            if (tLevel.Text.Length == 0)
            {
                tLevel.BorderBrush = Brushes.Red;
                check = true;
            }
            if(check)
            {
                return;
            }
            else
            {
                string query = "INSERT INTO word (w_name, w_level, w_rus, w_en, w_tr)" + "VALUES('" + tName.Text + "', '" + tLevel.Text + "', '" + tRusWord.Text + "', '" + tEnWord.Text + "', '" + tTranscriptionWord.Text + "')";

                OleDbCommand command = new OleDbCommand(query, dbase);

                command.ExecuteNonQuery();
            }

        }
    }
}
