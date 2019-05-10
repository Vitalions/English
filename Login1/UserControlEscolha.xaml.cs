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
        public List<BoxWord> boxWords = new List<BoxWord>();
        public int ch;
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

                while (reader.Read())
                {
                    string[] words1 = reader[2].ToString().Split(new char[] { ' ' });
                    string[] words2 = reader[3].ToString().Split(new char[] { ' ' });
                    string[] words3 = reader[4].ToString().Split(new char[] { ' ' });
                    //boxWords[ch] = new BoxWord(reader[0].ToString(),reader[1].ToString(),words1,words2);
                    boxWords.Add(new BoxWord(reader[0].ToString(), reader[1].ToString(), words1, words2,words3));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
            ch = boxWords.Count - 1;
            Update();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.grid.Children.Clear();
            MainWindow.grid.Children.Add(new UserControlLearn(boxWords[ch]));

        }
        private void Update()
        {
            BoxName1.Text = boxWords[ch].Name;
            BoxLevel1.Text = boxWords[ch].Level;
            BoxWord1.Text = "Слов " + boxWords[ch].RusWords.Length.ToString();

            BoxName2.Text = boxWords[ch - 1].Name;
            BoxLevel2.Text = boxWords[ch - 1].Level;
            BoxWord2.Text = "Слов " + boxWords[ch - 1].RusWords.Length.ToString();

            BoxName3.Text = boxWords[ch - 2].Name;
            BoxLevel3.Text = boxWords[ch - 2].Level;
            BoxWord3.Text = "Слов " + boxWords[ch - 2].RusWords.Length.ToString();
        }
        private void ArrowLeftClick(object sender, RoutedEventArgs e)
        {
            if (ch > 2)
            {
                BoxName1.Text = boxWords[ch-1].Name;
                BoxLevel1.Text = boxWords[ch-1].Level;
                BoxWord1.Text = "Слов " + boxWords[ch-1].RusWords.Length.ToString();

                BoxName2.Text = boxWords[ch - 2].Name;
                BoxLevel2.Text = boxWords[ch - 2].Level;
                BoxWord2.Text = "Слов " + boxWords[ch - 2].RusWords.Length.ToString();

                BoxName3.Text = boxWords[ch - 3].Name;
                BoxLevel3.Text = boxWords[ch - 3].Level;
                BoxWord3.Text = "Слов " + boxWords[ch - 3].RusWords.Length.ToString();
                ch--;
                TrainsitionigContentSlide.OnApplyTemplate();
            }
        }

        private void ArrowRightClick(object sender, RoutedEventArgs e)
        {
            if (ch<boxWords.Count-1)
            {
                BoxName1.Text = boxWords[ch + 1].Name;
                BoxLevel1.Text = boxWords[ch + 1].Level;
                BoxWord1.Text = "Слов " + boxWords[ch + 1].RusWords.Length.ToString();
                

                BoxName2.Text = boxWords[ch].Name;
                BoxLevel2.Text = boxWords[ch].Level;
                BoxWord2.Text = "Слов " + boxWords[ch].RusWords.Length.ToString();

                BoxName3.Text = boxWords[ch-1].Name;
                BoxLevel3.Text = boxWords[ch-1].Level;
                BoxWord3.Text = "Слов " + boxWords[ch-1].RusWords.Length.ToString();
                ch++;
                //TrainsitionigContentSlide.OpeningEffect = MaterialDesignThemes.Wpf.Transitions.TransitionEffectBase.
                //MaterialDesignThemes.Wpf.Transitions.TransitionEffectBase transitionEffectBase = new MaterialDesignThemes.Wpf.Transitions.TransitionEffectBase();
                //MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase transitioningContentBase = new MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase();
               TrainsitionigContentSlide.OnApplyTemplate();
            }
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            MainWindow.grid.Children.Clear();
            MainWindow.grid.Children.Add(new UserControlLearn(boxWords[ch-1]));
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            MainWindow.grid.Children.Clear();
            MainWindow.grid.Children.Add(new UserControlLearn(boxWords[ch-2]));
        }
    }
}
