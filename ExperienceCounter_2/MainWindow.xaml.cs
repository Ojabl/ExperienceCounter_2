using System;
using System.Windows;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ExperienceCounter_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<int> Data = new List<int>() { 0,0,0,0,0,0,0,0,0,0 }; // exp: 0, tasks: 1,2,3,4,5,6 projects: 7,8,9
        static readonly string folderPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}{Path.DirectorySeparatorChar}ExperienceCounterData";
        static readonly string filePath = $"{folderPath}{Path.DirectorySeparatorChar}ExperienceCounterData.txt";

        public MainWindow()
        {
            Data = LoadExp();

            Properties.Settings.Default.ColorMode = "Light";
            Properties.Settings.Default.Save();

            InitializeComponent();
            DataUpdate();
        }


        // DATA

        /// <summary>
        /// Loads data gathered in previous sessions from file
        /// </summary>
        /// <returns>List<int> data gathered in previous sessions</returns>
        public List<int> LoadExp()
        {
            var info = new FileInfo(filePath);
            if (!File.Exists(filePath) || info.Length < 6) // if file does not exist or file is empty, create a new folder and file with default, empty data
            {
                Directory.CreateDirectory(folderPath);
                using (StreamWriter sw = File.CreateText(filePath))

                Data.Clear();
                for(int i=0; i < Data.Count; i++)
                {
                        Data[i] = 0;
                }
            }
            //else if(info.Length < 25) // file is from previous version, without data about projects 
            else // if file exists, reads the file and returns data from it
            {
                Data.Clear();
                string[] stringArray = File.ReadAllLines(filePath);
                foreach (string str in stringArray)
                {
                    Data.Add(Convert.ToInt32(str.Trim()));
                }
                while(Data.Count != 10) // if Data is incomplete, fill it with 0's
                    Data.Add(0);
            }
            return Data;
        }

        /// <summary>
        /// Updates data in .txt file
        /// </summary>
        public static void TxtUpdate()
        {
            List<string> strData = new List<string>();

            foreach (var item in Data)
            {
                strData.Add(item.ToString());
            }

            File.WriteAllLines(filePath, strData);
        }

        /// <summary>
        /// Update data shown in window and in txt file
        /// </summary>
        public void DataUpdate()
        {
            // update data shown in window
            // update tasks 
            experienceText.Text = Convert.ToString(Data[0]);
            veryEasyTextBox.Text = Convert.ToString(Data[1]);
            easyTextBox.Text = Convert.ToString(Data[2]);
            mediumTextBox.Text = Convert.ToString(Data[3]);
            hardTextBox.Text = Convert.ToString(Data[4]);
            veryHardTextBox.Text = Convert.ToString(Data[5]);
            expertTextBox.Text = Convert.ToString(Data[6]);

            //update projects
            shortProjectTextBox.Text = Convert.ToString(Data[7]);
            mediumProjectTextBox.Text = Convert.ToString(Data[8]);
            longProjectTextBox.Text = Convert.ToString(Data[9]);

            // update data in txt file
            TxtUpdate();
        }

        
        //BUTTONS

        /// <summary>
        /// Actions happening after clicking "very easy" button
        /// User acquires 1 exp and 1 solved very easy task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void veryEasyButton_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(filePath, String.Empty);
            Data[0] += 1; // + exp
            Data[1] += 1; // + task

            DataUpdate();
        }

        /// <summary>
        /// Actions happening after clicking "easy" button
        /// User acquires 3 exp and 1 solved very easy task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void easyButton_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(filePath, String.Empty);
            Data[0] += 3; // + exp
            Data[2] += 1; // + task

            DataUpdate();
        }

        /// <summary>
        /// Actions happening after clicking "medium" button
        /// User acquires 5 exp and 1 solved very easy task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mediumButton_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(filePath, String.Empty);
            Data[0] += 5; // + exp
            Data[3] += 1; // + task

            DataUpdate();
        }

        /// <summary>
        /// Actions happening after clicking "hard" button
        /// User acquires 10 exp and 1 solved very easy task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hardButton_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(filePath, String.Empty);
            Data[0] += 10; // + exp
            Data[4] += 1;  // + task

            DataUpdate();
        }

        /// <summary>
        /// Actions happening after clicking "very hard" button
        /// User acquires 20 exp and 1 solved very easy task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void veryHardButton_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(filePath, String.Empty);
            Data[0] += 20; // + exp
            Data[5] += 1;  // + task

            DataUpdate();
        }

        /// <summary>
        /// Actions happening after clicking "expert" button
        /// User acquires 40 exp and 1 solved very easy task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void expertButton_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(filePath, String.Empty);
            Data[0] += 40; // + exp
            Data[6] += 1;  // + task

            DataUpdate();
        }

        /// <summary>
        /// Actions happening after clicking "short" project button
        /// User acquires 100 exp and 1 done short project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shortProjectButton_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(filePath, String.Empty);
            Data[0] += 100; // + exp
            Data[7] += 1;   // + project

            DataUpdate();
        }

        /// <summary>
        /// Actions happening after clicking "medium" project button
        /// User acquires 250 exp and 1 done medium project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mediumProjectButton_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(filePath, String.Empty);
            Data[0] += 250; // + exp
            Data[8] += 1;   // + project

            DataUpdate();
        }

        /// <summary>
        /// Actions happening after clicking "long" project button
        /// User acquires 500 exp and 1 done long project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void longProjectButton_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(filePath, String.Empty);
            Data[0] += 500; // + exp
            Data[9] += 1;   // + project

            DataUpdate();
        }


        // MENU
        
        private void reset_Click(object sender, RoutedEventArgs e)
        {
            for(int i=0; i < Data.Count(); i++) { Data[i] = 0; } // reset data

            DataUpdate();
        }

        private void colorModeCheckbox_Checked(object sender, RoutedEventArgs e) // dark mode
        {
            Properties.Settings.Default.ColorMode = "Dark";
            Properties.Settings.Default.Save();
        }

        private void colorModeCheckbox_Unchecked(object sender, RoutedEventArgs e) // light mode
        {
            Properties.Settings.Default.ColorMode = "Light";
            Properties.Settings.Default.Save();
        }
    }
}
