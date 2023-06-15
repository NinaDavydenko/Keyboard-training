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
using System.Windows.Threading;

namespace Keyboard_training
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool CapsLockOn = false;
        bool BackspaceOn = false;
        int countTimer = 0;
        int countFails = 0;
        bool finish = false;
        DispatcherTimer timer = null;
        string BaseNotCase = "1234567890[],./\\`-=;'qwertyuiopasdfghjklzxcvbnm";
        string BaseWithCase = "1234567890[],./\\`-=;'qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM~!@#$%^&*()_+{}|:\"<>?";
        string finalTestLetters;
        Random r = new Random();
        public MainWindow()
        {
            InitializeComponent();
            Difficulty.Content = 10;
            Start.IsEnabled = true;
            Stop.IsEnabled = false;
            TextUser.IsReadOnly = true;
            TextUser.IsEnabled = false;
            TextTask.IsReadOnly = true;
            TextTask.IsEnabled = false;

            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
        }
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int difficulty = 0;
            Slider s = sender as Slider;
            difficulty = (int)s.Value;
            Difficulty.Content = difficulty.ToString();
        }
        private void BigLetters()
        {
            this.Q.Content = "Q";
            this.W.Content = "W";
            this.E.Content = "E";
            this.R.Content = "R";
            this.T.Content = "T";
            this.Y.Content = "Y";
            this.U.Content = "U";
            this.I.Content = "I";
            this.O.Content = "O";
            this.P.Content = "P";
            this.A.Content = "A";
            this.S.Content = "S";
            this.D.Content = "D";
            this.F.Content = "F";
            this.G.Content = "G";
            this.H.Content = "H";
            this.J.Content = "J";
            this.K.Content = "K";
            this.L.Content = "L";
            this.Z.Content = "Z";
            this.X.Content = "X";
            this.C.Content = "C";
            this.V.Content = "V";
            this.B.Content = "B";
            this.N.Content = "N";
            this.M.Content = "M";

            this.Oem3.Content = "~";
            this.D1.Content = "!";
            this.D2.Content = "@";
            this.D3.Content = "#";
            this.D4.Content = "$";
            this.D5.Content = "%";
            this.D6.Content = "^";
            this.D7.Content = "&";
            this.D8.Content = "*";
            this.D9.Content = "(";
            this.D0.Content = ")";
            this.OemMinus.Content = "_";
            this.OemPlus.Content = "+";
            this.OemOpenBrackets.Content = "{";
            this.Oem6.Content = "}";
            this.Oem5.Content = "|";
            this.Oem1.Content = ":";
            this.OemQuotes.Content = "\"";
            this.OemComma.Content = "<";
            this.OemPeriod.Content = ">";
            this.OemQuestion.Content = "?";
        }
        private void SmallLetters()
        {
            this.Q.Content = "q";
            this.W.Content = "w";
            this.E.Content = "e";
            this.R.Content = "r";
            this.T.Content = "t";
            this.Y.Content = "y";
            this.U.Content = "u";
            this.I.Content = "i";
            this.O.Content = "o";
            this.P.Content = "p";
            this.A.Content = "a";
            this.S.Content = "s";
            this.D.Content = "d";
            this.F.Content = "f";
            this.G.Content = "g";
            this.H.Content = "h";
            this.J.Content = "j";
            this.K.Content = "k";
            this.L.Content = "l";
            this.Z.Content = "z";
            this.X.Content = "x";
            this.C.Content = "c";
            this.V.Content = "v";
            this.B.Content = "b";
            this.N.Content = "n";
            this.M.Content = "m";

            this.Oem3.Content = "`";
            this.D1.Content = "1";
            this.D2.Content = "2";
            this.D3.Content = "3";
            this.D4.Content = "4";
            this.D5.Content = "5";
            this.D6.Content = "6";
            this.D7.Content = "7";
            this.D8.Content = "8";
            this.D9.Content = "9";
            this.D0.Content = "0";
            this.OemMinus.Content = "-";
            this.OemPlus.Content = "=";
            this.OemOpenBrackets.Content = "[";
            this.Oem6.Content = "]";
            this.Oem5.Content = "\\";
            this.Oem1.Content = ";";
            this.OemQuotes.Content = "'";
            this.OemComma.Content = ",";
            this.OemPeriod.Content = ".";
            this.OemQuestion.Content = "/";
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (UIElement it in (this.Content as Grid).Children)
            {
                if (it is Grid)
                {
                    foreach (var item in (it as Grid).Children)
                    {
                        if (item is Border)
                        {
                            if (((item as Border).Child as Label).Name == e.Key.ToString())
                            {
                                (item as Border).Opacity = 0.5;
                                if (e.Key.ToString() == "Capital")
                                {
                                    if (!CapsLockOn)
                                    {
                                        CapsLockOn = true;
                                        BigLetters();
                                    }
                                    else
                                    {
                                        CapsLockOn = false;
                                        SmallLetters();
                                    }
                                }
                                else if (e.Key.ToString() == "LeftShift" || e.Key.ToString() == "RightShift")
                                {
                                    if (CapsLockOn)
                                    {
                                        SmallLetters();
                                    }
                                    else
                                    {
                                        BigLetters();
                                    }
                                }
                                else if (e.Key.ToString() == "Back")
                                {
                                    BackspaceOn = false;
                                }
                                else
                                {
                                    BackspaceOn = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            foreach (UIElement it in (this.Content as Grid).Children)
            {
                if (it is Grid)
                {
                    foreach (var item in (it as Grid).Children)
                    {
                        if (item is Border)
                        {
                            if (((item as Border).Child as Label).Name == e.Key.ToString())
                            {
                                (item as Border).Opacity = 1;
                                if (e.Key.ToString() == "LeftShift" || e.Key.ToString() == "RightShift")
                                {
                                    if (CapsLockOn)
                                    {
                                        BigLetters();
                                    }
                                    else
                                    {
                                        SmallLetters();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (finish)
            {
                MessageBoxResult result = MessageBox.Show($"Вітаємо!\nКількість помилок: {Fails.Content}", "", MessageBoxButton.OK);
                if(result == MessageBoxResult.OK)
                {
                    Start.IsEnabled = true;
                    Stop.IsEnabled = false;
                    SliderDifficulty.IsEnabled = true;
                    CaseSensitive.IsEnabled = true;
                    TextUser.IsReadOnly = true;
                    TextUser.IsEnabled = false;
                    TextUser.Text = "";
                    TextTask.Text = "";
                    Fails.Content = 0;
                    SpeedAmount.Content = 0;
                    timer.Stop();
                    countTimer = 0;
                    countFails = 0;
                    Difficulty.Content = 0;
                    finish = false;
                    CaseSensitive.IsChecked = false;
                }
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Start.IsEnabled = false;
            Stop.IsEnabled = true;
            SliderDifficulty.IsEnabled = false;
            CaseSensitive.IsEnabled = false;
            TextUser.IsReadOnly = false;
            TextUser.IsEnabled = true;
            countTimer = 0;
            timer.Start();
            if(CaseSensitive.IsChecked == true)
                finalTestLetters = BaseWithCase;
            else
                finalTestLetters = BaseNotCase;
            GenerateTextTest(Convert.ToInt32(Difficulty.Content), finalTestLetters);
            TextUser.Focus();
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            Start.IsEnabled = true;
            Stop.IsEnabled = false;
            SliderDifficulty.IsEnabled = true;
            CaseSensitive.IsEnabled = true;
            TextUser.IsReadOnly = true;
            TextUser.IsEnabled = false;
            TextUser.Text = "";
            TextTask.Text = "";
            Fails.Content = 0;
            SpeedAmount.Content = 0;
            timer.Stop();
            countTimer = 0;
            countFails = 0;
            Difficulty.Content = 0;
            finish = false;
            CaseSensitive.IsChecked = false;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            countTimer++;
            Speed();
        }
        void Speed()
        {
            SpeedAmount.Content = Math.Round(((double)TextUser.Text.Length / countTimer) * 60).ToString();
        }
        private void GenerateTextTest(int diff, string takeLetters)
        {
            int numberFromTakeLetters = -1;
            string final_final_letters = "";
            int[] seeLetters = new int[diff];
            for (int i = 0; i < diff; i++)
            {
                numberFromTakeLetters = r.Next(0, takeLetters.Length);
                if (!seeLetters.Contains(numberFromTakeLetters))
                {
                    seeLetters[i] = numberFromTakeLetters;
                    final_final_letters += takeLetters[numberFromTakeLetters];
                }
                else
                {
                    numberFromTakeLetters = r.Next(0, takeLetters.Length);
                }
            }

            int spaces = r.Next(10, 30);
            int words = (100 / spaces)+1;
            int t = 0;
            int numberLetter = -1;
            string finalText = "";
            for(int i = 0; i < words; i++)
            {
                if(t < spaces)
                {
                    for (int j = 0; j < (100 - spaces) / words; j++)
                    {
                        numberLetter = r.Next(1, final_final_letters.Length);
                        finalText += final_final_letters[numberLetter];
                    }
                }
                finalText += " ";
                t++;
            }
            TextTask.Text = finalText;
        }
        private void TextUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            string str = TextTask.Text.Substring(0, TextUser.Text.Length);
            if (TextUser.Text.Equals(str))
            {
                if (BackspaceOn)
                {
                    Speed();
                }
                TextUser.Foreground = new SolidColorBrush(Colors.Black);
            }
            else
            {
                if (BackspaceOn)
                {
                    countFails++;
                }
                TextUser.Foreground = new SolidColorBrush(Colors.Red);
                Fails.Content = countFails;
            }
            if (TextUser.Text.Length == TextTask.Text.Length)
            {
                timer.Stop();
                Speed();
                TextUser.IsReadOnly = true;
                finish = true;
            }
        }
    }
}
