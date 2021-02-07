using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Thibodeau_Ashley_CE02.Models;

namespace Thibodeau_Ashley_CE02
{
    public partial class MainPage : ContentPage
    {
        private StudentData passedStudentData = new StudentData();

        public MainPage()
        {
            InitializeComponent();

            bool fileCheck = passedStudentData.FileCheck();

            if(fileCheck == true)
            {
                saveButton.Margin = new Thickness(0, 0, 20, 0);
                loadButton.IsVisible = true;
            }

            if(loadButton.IsVisible != true)
            {
                saveButton.Margin = new Thickness(0,0,130,0);
            }

            saveButton.Clicked += SaveButton_Clicked;

            clearButton.Clicked += ClearButton_Clicked;

            loadButton.Clicked += LoadButton_Clicked;

            addButton.Clicked += AddButton_Clicked;
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            if (passedStudentData.Name != null)
            {
                passedStudentData.SaveFile(passedStudentData.Name, passedStudentData.Age, passedStudentData.StartDate, passedStudentData.ActiveStudentToggle);

                saveButton.Margin = new Thickness(0, 0, 20, 0);
                loadButton.IsVisible = true;
            }

        }

        private void LoadButton_Clicked(object sender, EventArgs e)
        {
            passedStudentData = passedStudentData.LoadFile();

            InfoDisplay();

        }

        private void ClearButton_Clicked(object sender, EventArgs e)
        {
            passedStudentData = passedStudentData.Clear();

            activeLabel.Text = "Inactive Student Account";
            activeLabel.BackgroundColor = Color.DarkRed;
            activeLabel.TextColor = Color.White;

            nameLabel.Text = "Name:";
            ageLabel.Text = "Age:";
            startDateLabel.Text = "Start Date:";

            addButton.Text = "New";

            saveButton.Margin = new Thickness(0,0,130,0);
            loadButton.IsVisible = false;

        }



        protected override void OnAppearing()
        {
            base.OnAppearing();

            InfoDisplay();
        }

        private void InfoDisplay()
        {
            if (passedStudentData.Name != null)
            {
                if (passedStudentData.ActiveStudentToggle == false)
                {
                    activeLabel.Text = "Inactive Student Account";
                    activeLabel.BackgroundColor = Color.DarkRed;
                    activeLabel.TextColor = Color.White;
                }
                else
                {
                    activeLabel.Text = "Active Student Account";
                    activeLabel.BackgroundColor = Color.GreenYellow;
                    activeLabel.TextColor = Color.Green;
                }

                nameLabel.Text = "Name: " + passedStudentData.Name;
                ageLabel.Text = "Age: " + passedStudentData.Age;
                startDateLabel.Text = "Start Date: " + passedStudentData.StartDate.ToString();

                addButton.Text = "Edit";
            }

        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StudentDataEntryPage
            {
                BindingContext = passedStudentData
              
            });
        }
    }
}
