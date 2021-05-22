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
    /// Логика взаимодействия для EditNoteWindow.xaml
    /// </summary>
    public partial class EditNoteWindow : Window
    {
        DB.Notes noteEdit = new DB.Notes();
        public EditNoteWindow()
        {
            InitializeComponent();
        }

        public EditNoteWindow(DB.Notes notes)
        {
            InitializeComponent();
            txtTopic.Text = notes.Topic;
            txtMessage.Text = notes.Message;

            noteEdit = notes;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            noteEdit.Topic = txtTopic.Text;
            noteEdit.Message = txtMessage.Text;
            noteEdit.DateAndTime = DateTime.Now;

            DB.AppData.context.SaveChanges();
            MessageBox.Show("Note was edited.");
            this.Close();
        }
    }
}
