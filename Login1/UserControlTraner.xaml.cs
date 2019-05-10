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
        public BoxWord boxWords;
        int ch=0,min=1,max=6;
        bool English = true;
        

        public UserControlTraner(BoxWord boxWords)
        {
            this.boxWords = boxWords;
            InitializeComponent();
        }
        public void Update()
        {
            if (English)
            {
                Word.Text = boxWords.EnWords[ch];
                tWord.Text = boxWords.Transcription[ch];
            }
            else
            {
                Word.Text = boxWords.RusWords[ch];
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button.Content.ToString() == boxWords.RusWords[ch] || button.Content.ToString() == boxWords.EnWords[ch])
            {

                ch++;
                if (ch > 4)
                {
                    min++;
                    max++;
                }
                if (ch > boxWords.EnWords.Length - 1 && !English)
                {
                    MainWindow.grid.Children.Clear();
                    MainWindow.grid.Children.Add(new UserControlEscolha());
                    MessageBox.Show("Вы успешно прошли тренировку!");
                }
                if (ch > boxWords.EnWords.Length - 1)
                {
                    ch = 0;
                    English = false;
                    min = 1; max = 6;
                    tWord.Text = "";
                }

                Update();
                Load();
            }
            else
            {
                MessageBox.Show("Неправильно");
            }

            
        }
        public void Load()
        {
            Random rnd = new Random();
            int[] mas = new int[5];
            for (int i = 0; i < mas.Length; i++)
            {
                int a = rnd.Next(min, max);
                if (!mas.Contains(a))
                {
                    switch (i)
                    {
                        case 0:
                            {
                                if (English)
                                {
                                    T1.Content = boxWords.RusWords[a - 1];
                                }
                                else
                                {
                                    T1.Content = boxWords.EnWords[a - 1];
                                }
                                break;
                            }
                        case 1:
                            {
                                if (English)
                                {
                                    T2.Content = boxWords.RusWords[a - 1];
                                }
                                else
                                {
                                    T2.Content = boxWords.EnWords[a - 1];
                                }
                                break;
                            }
                        case 2:
                            {
                                if (English)
                                {
                                    T3.Content = boxWords.RusWords[a - 1];
                                }
                                else
                                {
                                    T3.Content = boxWords.EnWords[a - 1];
                                }
                                break;
                            }
                        case 3:
                            {
                                if (English)
                                {
                                    T4.Content = boxWords.RusWords[a - 1];
                                }
                                else
                                {
                                    T4.Content = boxWords.EnWords[a - 1];
                                }
                                break;
                            }
                        case 4:
                            {
                                if (English)
                                {
                                    T5.Content = boxWords.RusWords[a - 1];
                                }
                                else
                                {
                                    T5.Content = boxWords.EnWords[a - 1];
                                }
                                break;
                            }
                    }
                    mas[i] = a;
                }
                else
                {
                    i--;
                }
            }
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
            Update();
            Load();

        }
    }
}
