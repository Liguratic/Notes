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

namespace Notes
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            //Авторизация
            var userAuth = DB.AppData.context.UserData.ToList().Where(i => i.Login == txtLogin.Text && i.Password == txtPassword.Password).FirstOrDefault();

            if (userAuth != null)
            {
                Classes.AuthData.userData = userAuth;
                //Переход на страницу заметок
                Windows.NotesWindow notesWindow = new Windows.NotesWindow();
                this.Hide();
                notesWindow.ShowDialog();
                //this.Show();
            }
            else
            {
                MessageBox.Show("Incorrect username or password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnGuest_Click(object sender, RoutedEventArgs e)
        {
            //Переход на страницу заметок
            Windows.NotesWindow notesWindow = new Windows.NotesWindow();
            this.Hide();
            notesWindow.ShowDialog();
            this.Show();
        }
    }
}
