using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private Random random = new Random();
        int dice1Sides;
        int dice2Sides;
        int dice1Result;
        int dice2Result;
        
        public void CalculateProbability(object sender, RoutedEventArgs e)
        {
            
           
           
            {
                decimal Total = 0m;
                dice1Result = random.Next(1, dice1Sides + 1);
                dice2Result = random.Next(1, dice2Sides + 1);
                int totalResult = dice1Result + dice2Result;

                dice1ResultLabel.Content = $"Граней = {dice1Sides}";
                dice2ResultLabel.Content = $"Граней = {dice2Sides}";
                totalResultLabel.Text = $"Сумма выпавших чисел: {totalResult}";

                rollButt.Visibility = Visibility.Hidden;
                ResButt.Visibility = Visibility.Visible;

                Dice1.Source = new Uri($".\\Resources\\числа_{dice1Result}.png", UriKind.Relative);
                Dice2.Source = new Uri($".\\Resources\\числа_{dice2Result}.png", UriKind.Relative);
                int i = 1;
                int j = 1;
                string StSt = Convert.ToString($"{i} : {j}");

               

                for (i = 1; i <= dice1Sides; i++)
                {

                    for (j = 1; j <= dice2Sides; j++)
                    {
                        if (j + i == totalResult)
                        {
                            Total++;
                            VarText.AppendText(Convert.ToString($"{i} + {j} \n"));
                            
                          
                            
                        }
                        
                    }
                    
                }
               
                int guessedNumber = Convert.ToInt32(ZagadannoeChislo.Value);
                decimal veroyatnost = Total / (dice1Sides * dice2Sides);
                if (guessedNumber != totalResult)
                {
                    MessageBox.Show("Вы не угадали число");
                    veroyatnostLabel.Text = $@"Вероятность угадать сумму: {veroyatnost:P}";
                    KolvoBlaga.Text = $" Количество благоприятных исходов = {Total}";
                }
                else
                {
                    MessageBox.Show($@"Вы угадали загаданное число! Гратс!");
                    veroyatnostLabel.Text = $@"Вероятность угадать сумму: {veroyatnost:P}";
                    KolvoBlaga.Text = $" Количество благоприятных исходов = {Total}";



                }
               
            }
        }
    

            
           
            
        
       

        

        private void ResButtANLoad(object sender, RoutedEventArgs e)
        {
            dice1Sides = random.Next(2, 33);
            dice1ResultLabel.Content = $"Граней = {dice1Sides}";
            dice2Sides = random.Next(2, 33);
            dice2ResultLabel.Content = $"Граней = {dice2Sides}";
            totalResultLabel.Text = $"Максимальная сумма граней = {dice1Sides + dice2Sides}";
            veroyatnostLabel.Text = null;
            ResButt.Visibility= Visibility.Hidden;
            rollButt.Visibility = Visibility.Visible;
            ZagadannoeChislo.Value = 2;
            ZagadannoeChislo.Maximum = dice1Sides + dice2Sides;
            Dice1.Source = new Uri($".\\Resources\\Spinning.mp4", UriKind.Relative);
            Dice2.Source = new Uri($".\\Resources\\Spinning.mp4", UriKind.Relative);
            KolvoBlaga.Text = null;
            VarText.Text = null;
        }

        private void Dice_Loaded(object sender, RoutedEventArgs e)
        {
            Dice1.SpeedRatio = 3; Dice2.SpeedRatio=3;
        }

       

        private void ZagadannoeChislo_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TXB.Text = $"Угадайте сумму кубиков: {ZagadannoeChislo.Value}";
        }

        private void Dice1_MediaEnded(object sender, RoutedEventArgs e)
        {
            Dice1.Position = TimeSpan.FromMilliseconds(1);
        }

        private void Dice2_MediaEnded(object sender, RoutedEventArgs e)
        {
            Dice2.Position = TimeSpan.FromMilliseconds(1);
        }
    }
   
 }


    