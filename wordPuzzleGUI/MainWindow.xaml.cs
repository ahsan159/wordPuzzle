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
using wordPuzzle;
namespace wordPuzzleGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private wordPuzzleEngine engine;
        TextBox[] letterBox;
        public MainWindow()
        {
            engine = new wordPuzzleEngine();
            InitializeComponent();
            //MessageBox.Show("Ahsan");
        }

        private void getPuzzle_Click(object sender, RoutedEventArgs e)
        {
            //string[] str = engine.getPuzzle();
            //wordText.Text = str[0];
            // puzzleText.Text = str[1];
            // MessageBox.Show("Ahsan");
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {            
            string[] str = engine.getPuzzle();
            wordText2.Text = str[0];
            //puzzleText2.Text = str[1];
            double totalLetters = (double)str[0].Length;
            letterBox = new TextBox[(int)totalLetters];            
            double boxWidth = (puzzlePanel.Width - 2*5*totalLetters)/totalLetters;
            puzzlePanel.Children.Clear();
            for(int i = 0; i < letterBox.Length; i++)
            {
                letterBox[i] = new TextBox();
                letterBox[i].Width = (int)boxWidth;
                letterBox[i].Margin = new Thickness(5,0,5,0);
                letterBox[i].CharacterCasing = CharacterCasing.Upper;
                 if(str[1].ElementAt(i)!='_')
                 {
                    letterBox[i].Text = str[1].ElementAt(i).ToString();
                 }
                 letterBox[i].TextChanged += textChangeFunction;
                puzzlePanel.Children.Add(letterBox[i]);
            }
            //MessageBox.Show(str[0]);
        }
        private void textChangeFunction(object sender, RoutedEventArgs args)
        {
            string str = string.Empty;
            foreach(TextBox tb in letterBox)
            {
                //tb.Text = tb.Text.ToUpper();
                if (tb.Text.Equals(string.Empty) || tb.Text.Equals(" "))
                {
                    str = str + "_";
                }
                else 
                {
                    str = str + tb.Text.ToUpper();
                }
            }
            //MessageBox.Show(str);
            engine.checkPuzzle(str);
            puzzleStatus status = engine.getStatus();
            if (status == puzzleStatus.Success)
            {
                MessageBox.Show("WOW!!");
            }
            else if (status == puzzleStatus.BetterLuckNextTime)
            {
                MessageBox.Show("Better Luck Next Time");
            }
        }
    }    
}
