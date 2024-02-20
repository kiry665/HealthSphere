﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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

namespace HealthSphere.Pages
{
    /// <summary>
    /// Логика взаимодействия для UniversalTablePage.xaml
    /// </summary>
    public partial class UniversalTablePage : Page
    {
        //private ApplicationContext dbContext;
        private List<Patient> CheckList = new List<Patient> { }; //ЗАМЕНА
        private List<Patient> patients_list;
        public UniversalTablePage()
        {
            InitializeComponent();
            CreateTable();


            BitmapImage image = new BitmapImage();
            using (MemoryStream stream = new MemoryStream(Properties.Resources.search))
            {
                image.BeginInit();
                image.StreamSource = stream;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.EndInit();
            }
            ImageControl.Source = image;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            PatientAddWindow window = new PatientAddWindow();
            window.Closed += HandleSecondWindowClosed;
            window.Show();
        }
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                db.patients.RemoveRange(CheckList);
                db.SaveChanges();
                CreateTable();
            }
        }
        private void CreateTable()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Table.ItemsSource = null;
                ObservableCollection<Patient> patients = new ObservableCollection<Patient>(db.patients);
                Table.ItemsSource = patients.ToList();
                patients_list = patients.ToList();
            }
        }
        private void Table_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var prop = e.PropertyDescriptor as PropertyDescriptor;
            if (prop != null)
            {
                e.Column.Header = prop.DisplayName;

                if (prop.PropertyType == typeof(DateOnly))
                {
                    DataGridTextColumn textColumn = e.Column as DataGridTextColumn;
                    if (textColumn != null)
                    {
                        textColumn.Binding.StringFormat = "dd.MM.yyyy"; // Формат "день.месяц.год"
                    }
                }
            }
        }
        public void HandleSecondWindowClosed(object sender, EventArgs e)
        {
            CreateTable();
        }

        private void Table_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Table.SelectedItems.Clear();
            //Table.SelectedCells.Clear();
        }

        private void Table_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridCellInfo cellInfo = Table.CurrentCell;
            if (cellInfo != null && cellInfo.IsValid)
            {
                object dataObject = cellInfo.Item;
                int columnIndex = cellInfo.Column.DisplayIndex;
                if (dataObject is Patient patient && columnIndex == 0)
                {
                    patient.isSelect = !patient.isSelect;
                    Table.Items.Refresh();
                    if (patient.isSelect == true)
                    {
                        CheckList.Add(patient);
                    }
                    else
                    {
                        CheckList.Remove(patient);
                    }
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                string text = textBox.Text;
                UpdateDataGrid(text);
            }
        }
        private void UpdateDataGrid(string searchTerm)
        {
            string[] substrings = searchTerm.Split(' ');
            string Last_name = substrings[0];
            string First_name = (substrings.Length >= 2) ? substrings[1] : "";
            string Patronymic = (substrings.Length >= 3) ? substrings[2] : "";

            if (patients_list is List<Patient> patients)
            {
                var filteredData = patients
                    .Where(item => item.last_name.Contains(Last_name) && item.first_name.Contains(First_name) && item.patronymic.Contains(Patronymic))
                    .ToList();

                Table.ItemsSource = filteredData;
            }
            //using (ApplicationContext context = new ApplicationContext())
            //{
            //    var filteredData = context.patients
            //        .Where(item => item.last_name.Contains(Last_name) && item.first_name.Contains(First_name) && item.patronymic.Contains(Patronymic))
            //        .ToList();
            //    Table.ItemsSource = filteredData;

        }



    }
}