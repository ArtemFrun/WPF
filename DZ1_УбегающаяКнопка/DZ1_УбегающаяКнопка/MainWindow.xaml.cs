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

namespace DZ1_УбегающаяКнопка
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
        /*
        private void this_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.GetPosition(this).X >= (RunButton.Margin.Left - 20))
                RunButton.Margin = new Thickness(RunButton.Margin.Left + 20, RunButton.Margin.Top, 0, 0);
            double left = RunButton.Margin.Left;
            
        }
        */

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.GetPosition(this).X > (RunButton.Margin.Left - 20) && e.GetPosition(this).X < (RunButton.Margin.Left + RunButton.Width + 20)) && (e.GetPosition(this).Y > (RunButton.Margin.Top - 20) && e.GetPosition(this).Y < (RunButton.Margin.Top + RunButton.Height + 20)))
            {
                if ((e.GetPosition(this).X >= (RunButton.Margin.Left - 20) && (e.GetPosition(this).X <= RunButton.Margin.Left)))
                {
                    RunButton.Margin = new Thickness(RunButton.Margin.Left + 20, RunButton.Margin.Top, 0, 0);
                }
                else if ((e.GetPosition(this).X <= (RunButton.Margin.Left + RunButton.Width + 20) && (e.GetPosition(this).X >= (RunButton.Margin.Left + RunButton.Width))))
                {
                    RunButton.Margin = new Thickness(RunButton.Margin.Left - 20, RunButton.Margin.Top, 0, 0);
                }
                else if ((e.GetPosition(this).Y >= (RunButton.Margin.Top - 20) && (e.GetPosition(this).Y <= RunButton.Margin.Top)))
                {
                    RunButton.Margin = new Thickness(RunButton.Margin.Left, RunButton.Margin.Top + 20, 0, 0);
                }
                else if (e.GetPosition(this).Y <= (RunButton.Margin.Top + RunButton.Height + 20) && e.GetPosition(this).Y >= (RunButton.Margin.Top + RunButton.Height))
                {
                    RunButton.Margin = new Thickness(RunButton.Margin.Left, RunButton.Margin.Top - 20, 0, 0);
                }
            }
        }
    }
}
