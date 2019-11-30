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
using System.Xml.Serialization;
using System.IO;


namespace DZ1_Цветовая_схема
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<User> users = new List<User>();
        private Color user_color = (Color)ColorConverter.ConvertFromString("#FFFFFFFF");
        public MainWindow()
        {
            InitializeComponent();
            reg.Foreground = Brushes.Blue;
            DeSerializable_User();
        }

        private void reg_MouseEnter(object sender, MouseEventArgs e)
        {
            reg.Foreground = Brushes.LightBlue;
        }

        private void reg_MouseLeave(object sender, MouseEventArgs e)
        {
            reg.Foreground = Brushes.Blue;
        }

        private void DeSerializable_User()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<User>));

            using (FileStream fs = new FileStream("Users.xml", FileMode.OpenOrCreate))
            {
                users = (List<User>)formatter.Deserialize(fs);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
           if(button.Content.ToString() == "Вход")
            {
                Login_User();
            }
            else
            if (button.Content.ToString() == "Выход")
            {
                Exit_User();
            }
            else
            if (button.Content.ToString() == "Зарегистрироватся")
            {
                Save_User();
            }
        }

        private void Login_User()
        {
            if (login.Text != "" && pass.Text != "")
            {
                User user = new User();
                bool have_log = false;
                foreach (var us in users)
                {
                    if (us.login == login.Text && us.pass == pass.Text)
                    {
                        user = us;
                        have_log = true;
                        break;
                    }
                }
                if (have_log == false)
                {
                    MessageBox.Show("Не верный логин или пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    label_log.Visibility = Visibility.Hidden;
                    label_pass.Visibility = Visibility.Hidden;
                    login.Visibility = Visibility.Hidden;
                    pass.Visibility = Visibility.Hidden;
                    reg.Visibility = Visibility.Hidden;
                    button.Content = "Выход";
                    SolidColorBrush brush = new SolidColorBrush(user.color);
                    grid.Background = brush;
                }

            }
            else
            {
                MessageBox.Show("Не все поля заполены", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Exit_User()
        {
            login.Text = "";
            pass.Text = "";
            label_log.Visibility = Visibility.Visible;
            label_pass.Visibility = Visibility.Visible;
            login.Visibility = Visibility.Visible;
            pass.Visibility = Visibility.Visible;
            reg.Visibility = Visibility.Visible;
            button.Content = "Вход";
            Color color = (Color)ColorConverter.ConvertFromString("#FFFFFFFF");
            SolidColorBrush brush = new SolidColorBrush(color);
            grid.Background = brush;
        }

        private void reg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            login.Text = "";
            pass.Text = "";
            if (e.ChangedButton == MouseButton.Left)
            {
                buttonColor.Visibility = Visibility.Visible;
                button.Content = "Зарегистрироватся";
                Cansel.Visibility = Visibility.Visible;
                reg.Visibility = Visibility.Hidden;
            }
        }

        private void Cansel_Click(object sender, RoutedEventArgs e)
        {
            label_log.Visibility = Visibility.Visible;
            label_pass.Visibility = Visibility.Visible;
            login.Visibility = Visibility.Visible;
            pass.Visibility = Visibility.Visible;
            reg.Visibility = Visibility.Visible;
            buttonColor.Visibility = Visibility.Hidden;
            Cansel.Visibility = Visibility.Hidden;
            button.Content = "Вход";
            Color color = (Color)ColorConverter.ConvertFromString("#FFFFFFFF");
            SolidColorBrush brush = new SolidColorBrush(color);
            grid.Background = brush;
            login.Text = "";
            pass.Text = "";
        }

        private void buttonColor_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog cd = new System.Windows.Forms.ColorDialog();
            if(cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.Drawing.Color color = cd.Color;
                int a = color.A;
                int r = color.R;
                int g = color.G;
                int b = color.B;
                user_color = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
            }
        }

        private void Save_User()
        {
            if (login.Text != "" && pass.Text != "")
            {
                bool free_log = true;
                foreach (var us in users)
                {
                    if (us.login == login.Text)
                    {
                        free_log = false;
                        break;
                    }
                }
                if (free_log == true)
                {
                    User user = new User();
                    user.login = login.Text;
                    user.pass = pass.Text;
                    user.color = user_color;
                    users.Add(user);

                    var formatter = new XmlSerializer(typeof(List<User>));

                    using (FileStream fs = new FileStream("Users.xml", FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(fs, users);
                    }
                    MessageBox.Show("Пользователь зарегистрирован", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);

                    label_log.Visibility = Visibility.Visible;
                    label_pass.Visibility = Visibility.Visible;
                    login.Visibility = Visibility.Visible;
                    pass.Visibility = Visibility.Visible;
                    reg.Visibility = Visibility.Visible;
                    buttonColor.Visibility = Visibility.Hidden;
                    Cansel.Visibility = Visibility.Hidden;
                    reg.Visibility = Visibility.Visible;
                    button.Content = "Вход";
                    Color color = (Color)ColorConverter.ConvertFromString("#FFFFFFFF");
                    SolidColorBrush brush = new SolidColorBrush(color);
                    grid.Background = brush;
                    login.Text = "";
                    pass.Text = "";
                }
                else
                {
                    MessageBox.Show("Такой пользователь уже существует", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
