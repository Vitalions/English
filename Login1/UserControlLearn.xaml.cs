using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.CognitiveServices.Speech;
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
    /// Логика взаимодействия для UserControlLearn.xaml
    /// </summary>
    public partial class UserControlLearn : UserControl
    {
        public BoxWord boxWords;
        int ch = 0;
        
        
        public UserControlLearn(BoxWord boxWords)
        {

            InitializeComponent();
            this.boxWords = boxWords;
        }
        public async void SynthesisToSpeakerAsync()
        {
            var config = SpeechConfig.FromSubscription("5f9d33519fd345b3b7b5b0d43f09d0c9", "westus");
            using (var synthesizer = new SpeechSynthesizer(config))
            {
                //MessageBox.Show(UserControlEscolha.boxWords[boxNumber].RusWords[ch]);
              await synthesizer.SpeakTextAsync(boxWords.EnWords[ch]);
            }
        }
        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            SynthesisToSpeakerAsync();
        }
        public void Update()
        {
            Word.Text = boxWords.EnWords[ch];
            RusWord.Text = boxWords.RusWords[ch];
            tWord.Text = boxWords.Transcription[ch];
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ch < boxWords.EnWords.Length-1)
            {
                ch++;
                Update();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ch > 0)
            {
                ch--;
                Update();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Grid1.Children.Clear();
            //Grid1.Children.Add(new UserControlTraner());

            //this.Height = 900;
            //this.Width = 700
            MainWindow.grid.Children.Clear();
            MainWindow.grid.Children.Add(new UserControlTraner(boxWords));
        }
    }
}
