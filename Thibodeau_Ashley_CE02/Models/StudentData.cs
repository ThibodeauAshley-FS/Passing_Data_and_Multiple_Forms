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
        public bool Active { get; set; }

        public void SaveFile(string name, double age, DateTime startDate, bool activeStatus)
        {
            using (var sw = new StreamWriter(filePath))
            {
                sw.WriteLine(name);
                sw.WriteLine(age);
                sw.WriteLine(startDate.ToString());
                sw.WriteLine(activeStatus.ToString());
            }

        }

        public StudentData LoadFile()
        {
            using (var sr = new StreamReader(filePath))
            {

            }

            return this;
        }


    }



}
