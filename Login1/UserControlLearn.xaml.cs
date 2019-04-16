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
        int boxNumber;
        int ch = 0;

        
        public UserControlLearn(int s)
        {
            InitializeComponent();
            boxNumber = s;
        }
        public async void SynthesisToSpeakerAsync()
        {
            var config = SpeechConfig.FromSubscription("5f9d33519fd345b3b7b5b0d43f09d0c9", "westus");
            using (var synthesizer = new SpeechSynthesizer(config))
            {
                MessageBox.Show(UserControlEscolha.boxWords[boxNumber].RusWords[ch]);
              await synthesizer.SpeakTextAsync(UserControlEscolha.boxWords[boxNumber].RusWords[ch]);
            }
        }
        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            SynthesisToSpeakerAsync();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
            Word.Text = UserControlEscolha.boxWords[boxNumber].EnWords[ch];
            pWord.Text = UserControlEscolha.boxWords[boxNumber].RusWords[ch];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ch < UserControlEscolha.boxWords[boxNumber].EnWords.Length-1)
            {
                ch++;
                Word.Text = UserControlEscolha.boxWords[boxNumber].EnWords[ch];
                pWord.Text = UserControlEscolha.boxWords[boxNumber].RusWords[ch];
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ch > 0)
            {
                ch--;
                Word.Text = UserControlEscolha.boxWords[boxNumber].EnWords[ch];
                pWord.Text = UserControlEscolha.boxWords[boxNumber].RusWords[ch];
            }
        }
    }
}
