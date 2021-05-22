﻿using System;
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
    /// Логика взаимодействия для AddNoteWindow.xaml
    /// </summary>
    public partial class AddNoteWindow : Window
    {
        public AddNoteWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DB.Notes noteAdd = new DB.Notes();

            noteAdd.Topic = txtTopic.Text;
            noteAdd.Message = txtTopic.Text;
            noteAdd.DateAndTime = DateTime.Now;
            noteAdd.IdUser = Classes.AuthData.userData.IdUser;

            DB.AppData.context.Notes.Add(noteAdd);
            MessageBox.Show("Note was added.");
            DB.AppData.context.SaveChanges();

            this.Close();
        }
    }
}
