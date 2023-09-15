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
using System.IO;
using Microsoft.Win32;

namespace operatorokokokokokokkok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Muvelet> feladatok;




        public MainWindow()
        {
            InitializeComponent();


        }
        private void btnKiir_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog beolvasas = new OpenFileDialog();
            if (beolvasas.ShowDialog() == true)
            {
                // lblText.Content = File.ReadAllText(beolvasas.FileName);
                FileBeolvasas(beolvasas.FileName);
                lblText.Content = "Kifejezések száma: " + feladatok.Count();
                lblTextMasodik.Content = "Kifejezések maradékos osztásssal: " + feladatok.Count(x => x.Operat == "mod");
                Negyes();
                Otos();
                //Muvelet();
            }
            else
            {
                Console.WriteLine("yXXDDD");
            }
        }



        public void FileBeolvasas(string fajlNev)
        {
            feladatok = new List<Muvelet>();
            foreach (var sor in File.ReadAllLines(fajlNev))
            {
                int a = int.Parse(sor.Split()[0]);
                int b = int.Parse(sor.Split()[2]);
                string o = sor.Split()[1];
                feladatok.Add(new Muvelet(a, b, o));
            }
        }
        public void Negyes()
        {
            if (feladatok.Any(x => x.Operat == "div"))
            {
                lblTextHarmadik.Content = "Van ilyen kifejezés!";
            }
            else
            {
                lblTextHarmadik.Content = "Szeva";
            }
        }

        public void Otos()
        {
            int mod = feladatok.Count(x => x.Operat == "mod");
            int per = feladatok.Count(x => x.Operat == "/");
            int div = feladatok.Count(x => x.Operat == "div");
            int min = feladatok.Count(x => x.Operat == "-");
            int csill = feladatok.Count(x => x.Operat == "*");
            int plus = feladatok.Count(x => x.Operat == "+");
            lblTextNegyedik.Content = "Statisztika" + "\n" + "mod -> " +
                mod + " db\n/ -> " + per + " db\ndiv -> " + div
                + " db\n- -> " + min + " db\n* -> " + csill + " db\n+ -> " + plus;
        }

        public string Muvelet(int operandusA, int operandusB, string muveletiJel)
        {
            double eredmeny = 0;
            try
            {
                switch (muveletiJel)
                {
                    case "mod":
                        eredmeny = operandusA % operandusB;
                        break;
                    case "/":
                        //if (operandusB==0)
                        //{
                        //    return "HIBA! :0-val nem lhet osztani!";
                        //}
                        eredmeny = operandusA / operandusB;
                        break;
                    case "div":
                        eredmeny = (double)operandusA / operandusB;
                        break;
                    case "-":
                        eredmeny = operandusA - operandusB;
                        break;
                    case "*":
                        eredmeny = operandusA * operandusB;
                        break;
                    case "+":
                        eredmeny = operandusA + operandusB;
                        break;
                    default:
                        return "Hibás operátor!";
                }
            }
            catch (DivideByZeroException hiba)
            {
                return "Hiba: 0-val nem lehet osztani!";
            }
            catch (OverflowException hiba)
            {
                return "Hiba: Túlcsordulás!";
            }
            return Convert.ToString(eredmeny);
        }

        public void Hetes()
        {
            string adatBekeres = Console.ReadLine();
            do
            {

            } while (adatBekeres != "vége");
        }

        private void btnErtekel_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show(Muvelet(int.Parse(txtOpA.Text), int.Parse(txtOpB.Text), txtMuv.Text));

        }
    }
}
