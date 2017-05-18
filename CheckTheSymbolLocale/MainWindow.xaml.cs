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

            //Sample data
            tb.Text = "р371A2C3xN\r\nS5УУ05O86Р\r\n6Омк75btZм";
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(rtb != null)
            {
                var paragraph = new Paragraph();
                rtb.Document = new FlowDocument(paragraph);

                paragraph.LineHeight = 15;
                paragraph.LineStackingStrategy = LineStackingStrategy.BlockLineHeight;

                foreach (var x in tb.Text)
                {
                    var color = Brushes.Black;

                    if (x == '\r') {
                        continue;
                    }
                    else if (Char.IsNumber(x)) {
                        color = Brushes.Black; }

                    else if (Regex.IsMatch(x.ToString(), @"\p{IsCyrillic}")) {
                        color = Brushes.Red; }

                    else if (Regex.IsMatch(x.ToString(), @"\p{IsBasicLatin}")) {
                        color = Brushes.Green; }

                    else if (Char.IsPunctuation(x) || Char.IsSymbol(x)) {
                        color = Brushes.Blue; }

                    else { color = Brushes.Purple; }

                    paragraph.Inlines.Add(new Run(x.ToString())
                    {
                        Foreground = color
                    });
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tb.Text = Clipboard.GetText();
        }
    }
}
