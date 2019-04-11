using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data.OleDb;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pizzaria1
{
    /// <summary>
    /// Interação lógica para UserControlEscolha.xam
    /// </summary>
    public class BoxWord
    {
        public string Name { get; set; }
        public string Level { get; set; }
        public string[] EnWords { get; set; }
        public string[] RusWords { get; set; }
        public BoxWord(string Name,  string Level, string[] EnWords, string[] RusWords)
        {
            this.Name = Name;
            this.Level = Level;
            this.EnWords = EnWords;
            this.RusWords = RusWords;
        }
    }
    public partial class UserControlEscolha : UserControl
    {
        public OleDbConnection dbase;
        public void DBConnect()
        {
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Users.mdb;";
            dbase = new OleDbConnection(connectionString);
            dbase.Open();
        }
        public UserControlEscolha()
        {
            InitializeComponent();
            BoxWord[] boxWords = new BoxWord[3];
            DBConnect();
            string query = "SELECT w_name, w_level, w_rus, w_en FROM Word";

            OleDbCommand command = new OleDbCommand(query, dbase);

            OleDbDataReader reader = command.ExecuteReader();

            int ch = 0;
            while (reader.Read())
            {
                string[] words1 = reader[2].ToString().Split(new char[] { ' ' });
                string[] words2 = reader[3].ToString().Split(new char[] { ' ' });
                boxWords[ch] = new BoxWord(reader[0].ToString(),reader[1].ToString(),words1,words2);
                ch++;
            }


            BoxName1.Text = boxWords[0].Name;
            BoxLevel.Text = boxWords[0].Level;
            BoxWord1.Text = "Слов "+boxWords[0].RusWords.Length.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ArrowLeftClick(object sender, RoutedEventArgs e)
        {
            TrainsitionigContentSlide.OnApplyTemplate();
        }

        private void ArrowRightClick(object sender, RoutedEventArgs e)
        {
            TrainsitionigContentSlide.OnApplyTemplate();
        }
    }
}
