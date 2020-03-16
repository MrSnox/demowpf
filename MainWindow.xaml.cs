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

namespace demowpf
{
  
    public partial class MainWindow : Window
    {
        private Player p1;
        private Player p2;
        private Player active;
        public MainWindow()
        {
            InitializeComponent();

            this.p1 = new Player("p1", "P1Score");
            this.p2 = new Player("p2", "P2Score");
            this.active = p1;

        }
        public class Player
        {
            private int score;
            private string name;
            private string labelScore;

            public Player(string nom, string label)
            {
                Name = name;
                Score = 0;
                LabelScore = label;
            }

            public int Score
            {
                get { return score; }
                set { score = value; }
            }
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public string LabelScore
            {
                get { return labelScore; }
                set { labelScore = value; }
            }

            public void addToScore(int add)
            {
                Score += add;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            button.Style = (Style)FindResource("BoutonRouge");
            button.IsEnabled = false;
            // merci jo !
            active.addToScore(int.Parse($"{button.Content}"));

            if ("player2" == active.Name)
            {
                P2Score.Content = active.Score;
                Check_Score();
                this.active = p1;
            }
            else
            {
                P1Score.Content = active.Score;
                Check_Score();
                this.active = p2;
            }

        }

        private void Check_Score()
        {
            int score = active.Score;
            if (15 == score)
            {
                MessageBox.Show($"{active.Name} remporte la manche");
                Stop();
            }
            else if (15 < score)
            {
                MessageBox.Show($"{active.Name} perd la manche, score : {active.Score}");
                Stop();
            }
        }

        private void Stop()
        {
            Application app = Application.Current;
            app.Shutdown();
        }


    }

    
}
    

