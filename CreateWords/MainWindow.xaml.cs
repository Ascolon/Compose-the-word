using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CreateWords
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] Word;
        public MainWindow()
        {
            InitializeComponent();
            CreateWord();
            ArrayWord();
        }
        int h = 50;
        int w = 20;
        string[] Char = new string[]
        {
            "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й",
            "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф",
            "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я"
        };
        void CreateWord()
        {
            int k = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    var btn = new Button();
                    btn.Height = 50;
                    btn.Width = 50;
                    btn.Content = Char[k];
                    btn.VerticalAlignment = VerticalAlignment.Top;
                    btn.HorizontalAlignment = HorizontalAlignment.Left;
                    btn.Margin = new Thickness(h,w,0,0);
                    btn.Click += BtnClick;
                    h += 53;
                    letter.Children.Add(btn);
                    k++;

                }
                w += 53;
                h = 50;
            }
        }

        private void BtnClick(object sender, RoutedEventArgs e)
        {
            var item = (Button)sender;
            input.Content += item.Content.ToString();

        }
        void ArrayWord()
        {
            string T = null;
            Word = File.ReadAllLines("word.txt",Encoding.Default);
        }

        private void CheckClick(object sender, RoutedEventArgs e)
        {
            string T = input.Content.ToString();
            if (Word.Contains(T.ToLower()))
            {
                MessageBox.Show("Поздравляю! Такое слово есть");
                input.Content = null;
            }
            else
            {
                MessageBox.Show("Увы но нет.");
                input.Content = null;
            }
        }
    }
}
