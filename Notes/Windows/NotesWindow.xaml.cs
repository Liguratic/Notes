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
using System.Windows.Shapes;

namespace Notes.Windows
{
    /// <summary>
    /// Логика взаимодействия для NotesWindow.xaml
    /// </summary>
    public partial class NotesWindow : Window
    {
        public NotesWindow()
        {
            InitializeComponent();

            if(Classes.AuthData.userData == null)
            {
                btnAdd.Visibility = Visibility.Collapsed;
                btnEdit.Visibility = Visibility.Collapsed;
                btnDel.Visibility = Visibility.Collapsed;
            }


            lvNote.ItemsSource = DB.AppData.context.Notes.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddNoteWindow addNoteWindow = new AddNoteWindow();
            this.Hide();
            addNoteWindow.ShowDialog();
            lvNote.ItemsSource = DB.AppData.context.Notes.ToList();
            this.Show();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lvNote.SelectedItem is DB.Notes noteEdit) 
            {
                Windows.EditNoteWindow editNoteWindow = new EditNoteWindow(noteEdit);
                this.Hide();
                editNoteWindow.ShowDialog();
                lvNote.ItemsSource = DB.AppData.context.Notes.ToList();
                this.Show();

            }
            else
            {
                MessageBox.Show("Note was not selected.");
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (lvNote.SelectedItem is DB.Notes noteDel)
            {
                var resultMess = MessageBox.Show("Are you sure?", "Delete request!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resultMess == MessageBoxResult.Yes)
                {
                    DB.AppData.context.Notes.Remove(noteDel);

                    DB.AppData.context.SaveChanges();

                    MessageBox.Show("Note was deleted.");

                    lvNote.ItemsSource = DB.AppData.context.Notes.ToList();
                }

                
            }
            else
            {
                MessageBox.Show("Note was not selected.");
            }
        }
    }
}
