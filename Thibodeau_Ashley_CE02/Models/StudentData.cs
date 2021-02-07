/*
    Ashley Thibodeau
    Interface Programming
    C20210201
    Code Exercise 2    
    GitHub Link: https://github.com/InterfaceProgramming/ce2-ThibodeauAshley-FS
 */
using System;
using System.IO;

namespace Thibodeau_Ashley_CE02.Models
{
    public class StudentData
    {
        private string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CE02_Data.txt");


        public string Name { get; set; }
        public Double Age { get; set; }
        public DateTime StartDate { get; set; }
        public bool ActiveStudentToggle { get; set; }

        public void SaveFile(string name, double age, DateTime startDate, bool activeStudentStatus)
        {
            using (var sw = new StreamWriter(filePath))
            {
                sw.WriteLine(name);
                sw.WriteLine(age);
                sw.WriteLine(startDate.ToString());
                sw.WriteLine(activeStudentStatus.ToString());
            }

        }

        public bool FileCheck()
        {
            if(File.Exists(filePath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public StudentData LoadFile()
        {
            if (File.Exists(filePath))
            {
                using (var sr = new StreamReader(filePath))
                {
                    string[] data = new string[4];
                    string line;
                    int numLine = 0;

                    while ((line = sr.ReadLine()) != null)
                    {
                        data[numLine] = line;
                        numLine++;

                    }

                    if (data != null)
                    {
                        Name = data[0];

                        double.TryParse(data[1], out double age);
                        Age = age;

                        DateTime.TryParse(data[2], out DateTime startDate);
                        StartDate = startDate;

                        bool.TryParse(data[3], out bool activeStudentToggle);
                        ActiveStudentToggle = activeStudentToggle;
                    }

                }

            }
            return this;
        }

        public StudentData Clear()
        {
            File.Delete(filePath);

            Name = null;
            Age = 0;
            
            ActiveStudentToggle = false;

            return this;

        }
    }



}
