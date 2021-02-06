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

            addButton.Clicked += AddButton_Clicked;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if(passedStudentData.Name != null)
            {
                if(passedStudentData.Active == false)
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
