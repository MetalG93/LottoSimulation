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

namespace LottoSimulation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            resetGui();
            try
            {
                long simulationPcs = long.Parse(txtSimulationPcs.Text);
                var numbers = Task.Factory.StartNew(() => simulateLottery(simulationPcs), TaskCreationOptions.LongRunning);
                MessageBox.Show(numbers.ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void resetGui()
        {
            stackPanel.Children.Clear();
            groupBox.Height = 25;
            groupBox.Visibility = Visibility.Hidden;
            window.Height = 125;
        }

        private void fillLotteryNumbers(LotteryNumber[] lotteryNumbers)
        {
            for (int i = 0; i < lotteryNumbers.Length; i++)
            {
                lotteryNumbers[i] = new LotteryNumber(i + 1);
            }
        }

        private LotteryNumber[] simulateLottery(long numOfLottery)
        {
            LotteryNumber[] returnArray = new LotteryNumber[5];
            LotteryNumber[] lotteryNumbers = new LotteryNumber[90];
            fillLotteryNumbers(lotteryNumbers);
            Random random = new Random();
            for (int i = 0; i < numOfLottery; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    lotteryNumbers[random.Next(0, 90)].Pcs++;
                }
            }
            sortArray(lotteryNumbers);
            MessageBox.Show("Kész");
            return returnArray;
        }

        private void sortArray(LotteryNumber[] lotteryNumbers)
        {
            for (int i = lotteryNumbers.Length-1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (lotteryNumbers[i].Pcs < lotteryNumbers[j].Pcs)
                    {
                        swap(lotteryNumbers, i, j);
                    }
                }
            }
        }

        private void swap(LotteryNumber[] lotteryNumbers, int num1, int num2)
        {
            LotteryNumber temp = lotteryNumbers[num1];
            lotteryNumbers[num1] = lotteryNumbers[num2];
            lotteryNumbers[num2] = temp;
        }

        private void printResult(LotteryNumber[] lotteryNumbers)
        {
            for (int i = 0; i < lotteryNumbers.Length; i++)
            {
                Label label = new Label();
                label.Content = lotteryNumbers[i].ToString();
                stackPanel.Children.Add(label);
                groupBox.Height += 25;
                window.Height += 25;
                if (label.Width > groupBox.Width)
                {
                    groupBox.Width = label.Width;
                }
            }
            groupBox.Visibility = Visibility.Visible;
        }
    }
}
