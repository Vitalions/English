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

namespace English
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
        public string[] Transcription { get; set; }
        public BoxWord(string Name,  string Level, string[] RusWords,string[] EnWords, string[] Transcription)
        {
            this.Name = Name;
            this.Level = Level;
            this.EnWords = EnWords;
            this.RusWords = RusWords;
            this.Transcription = Transcription;
        }
    }
    public partial class UserControlEscolha : UserControl
    {
        public OleDbConnection dbase;
        //public static BoxWord[] boxWords = new BoxWord[3];
        public static List<BoxWord> boxWords = new List<BoxWord>();
        
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
        public UserControlEscolha()
        {
            InitializeComponent();

            DBConnect();
            
            try
            {
                string query = "SELECT w_name, w_level, w_rus, w_en, w_tr FROM Word";
                OleDbCommand command = new OleDbCommand(query, dbase);

                OleDbDataReader reader = command.ExecuteReader();

                int ch = 0;
                while (reader.Read())
                {
                    string[] words1 = reader[2].ToString().Split(new char[] { ' ' });
                    string[] words2 = reader[3].ToString().Split(new char[] { ' ' });
                    string[] words3 = reader[4].ToString().Split(new char[] { ' ' });
                    //boxWords[ch] = new BoxWord(reader[0].ToString(),reader[1].ToString(),words1,words2);
                    boxWords.Add(new BoxWord(reader[0].ToString(), reader[1].ToString(), words1, words2,words3));
                    ch++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
            //BOX 1
            BoxName1.Text = boxWords[0].Name;
            BoxLevel.Text = boxWords[0].Level;
            BoxWord1.Text = "Слов "+boxWords[0].RusWords.Length.ToString();
            //BOX 2

            //BOX 3
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Grid1.Children.Clear();
            this.Height = 400;
            Grid1.Children.Add(new UserControlLearn(0));

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
