﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
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

namespace Game
{
    /// <summary>
    /// Логика взаимодействия для store.xaml
    /// </summary>

    public class grid
    {
        public string Наименование { get; set; }
        public string Описание { get; set; }
        public int Стоимость { get; set; }
        public int Количество { get; set; }
    }

    public partial class store : Window
    {
        SQLiteConnection m_dbConnection;
        // string db_name = "\\res\\store.db";
        //string db_name = @"pack://application:,,,/store.db";
        //string db_name = Game.Properties.Resources.store.ToString();
        string db_name = "res\\store.db";
        Gaming staff = new Gaming();
        //MainWindow mon = new MainWindow();

        public bool armorb = false, weaponb = false, healb = false, goldb = false;
        public int armor = 0, weapon = 0, heal = 0, idk = 0, gold = 0;


        public store()
        {
            InitializeComponent();

            m_dbConnection = new SQLiteConnection("Data Source=" + db_name + ";Version=3;");
            m_dbConnection.Open();

            string sql = "SELECT * FROM Товары ORDER BY Наименование";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var data = new grid
                {
                    Наименование = reader["Наименование"].ToString(),
                    Описание = reader["Описание"].ToString(),
                    Стоимость = int.Parse(reader["Стоимость"].ToString()),
                    Количество = int.Parse(reader["Количество"].ToString())
                };
                things.Items.Add(data);
            }

        }        

        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            armorb = false; weaponb = false; healb = false;
            try
            {
                grid val = (grid)things.SelectedItem;

                int choice = things.SelectedIndex;

                if (choice != -1)
                {
                    int ch = val.Количество - 1;
                    if (ch != 0)
                    {
                        things.Items.RemoveAt(choice);
                        //string sql = "UPDATE Товары SET Количество = " + ch + " WHERE Стоимость = " + val.Стоимость;
                        //SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                        //command.ExecuteNonQuery();

                        var data = new grid { Наименование = val.Наименование, Описание = val.Описание, Количество = ch, Стоимость = val.Стоимость };
                        things.Items.Insert(choice, data);
                        things.Items.Refresh();
                    }
                    else
                    {
                        //string sql = "DELETE FROM Товары WHERE Стоимость = " + val.Стоимость;
                        //SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                        //command.ExecuteNonQuery();
                        things.Items.RemoveAt(choice);
                        things.Items.Refresh();
                    }
                    if (val.Стоимость == 12)
                    {
                        armorb = true;
                        armor = armor + 10;
                        gold += 12;

                    }
                    if (val.Стоимость == 10)
                    {
                        weaponb = true;
                        weapon = weapon + 3;
                        gold += 10;
                    }
                    if (val.Стоимость == 5)
                    {
                        healb = true;
                        heal = heal + 1;
                        gold += 5;
                    }
                    if (val.Стоимость == 100)
                    {
                        idk = 1;
                        gold += 100;
                    }
                }
            }
            catch (FormatException)
            {

            }
            catch (SQLiteException)
            {

            }
            catch (ArgumentOutOfRangeException)
            {

            }
        }

        private void Things_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }
    }
}
