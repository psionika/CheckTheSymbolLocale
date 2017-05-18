using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace CheckTheSymbolLocale
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            tb.Text = "р371A2C3xN\nS5УУ05O86Р\n6Омк75btZм";
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(rtb != null)
            {
                TextRange rEmpty = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
                Paragraph p = rtb.Document.Blocks.FirstBlock as Paragraph;
                p.LineHeight = 1;


                foreach (var x in tb.Text)
                {
                    TextRange tr = new TextRange(rtb.Document.ContentEnd, rtb.Document.ContentEnd);
                    tr.Text = x.ToString();

                    if (Char.IsNumber(x))
                    {
                        tr.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Black);
                    }
                    else if (Char.IsPunctuation(x) || Char.IsSymbol(x))
                    {
                        tr.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Blue);
                    }
                    else if (Regex.IsMatch(x.ToString(), @"\p{IsCyrillic}"))
                    {
                        tr.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Red);
                    }
                    else if (Regex.IsMatch(x.ToString(), @"\p{IsBasicLatin}"))
                    {
                        tr.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Green);
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tb.Text = "";
            tb.Text = Clipboard.GetText();
        }
    }
}
