using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CaptainsLog.Core;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace _07_CaptainsLog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // need to create a storage mechanism for the LogEntries i.e. an array
        private ObservableCollection<LogEntry> logEntries;

        // public = so everyone can see it
        // static = which is a setting that makes it set, like a reference point?
        // no idea about the Routed class, naming it DeletedCommand and having it be able to receive input
        public static RoutedUICommand DeleteCommand { get; }


        public MainWindow()
        {
            InitializeComponent();

            logEntries = new ObservableCollection<LogEntry>();

            gridLogEntries.ItemsSource = logEntries;
        }

        private void buttonAddEntry_Click(object sender, RoutedEventArgs e)
        {
            // collect the input from the user

            // validate the input (did the user enter enough text)

            // add to the grid

            // Cameron skipped the above and created a new object below

            string title = "Whatever title";
            string text = "Whatever text";
            DateTime date = DateTime.Now;

            LogEntry log = new LogEntry();

            log.Id = logEntries.Count + 1;
            log.Title = title;
            log.Text = text;
            log.EntryDate = date;

            logEntries.Add(log); 
        }

        private void buttonRemoveLastEntry_Click(object sender, RoutedEventArgs e)
        {
            // an entry has to be selected first in order to be deleted
            if (SelectedLogEntry != null)
            {
                // now the reference to the selected entry in the grid gets deleted
                logEntries.Remove(SelectedLogEntry);
                // now the reference itself needs to be nullified
                SelectedLogEntry = null;
            }

        }

        // this will enable selecting an entry (or row)
        private void gridLogEntries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // create a reference to the selected (naming it)
            SelectedLogEntry = (LogEntry)gridLogEntries.SelectedItem;
        }

        private void buttonSaveEntries_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
