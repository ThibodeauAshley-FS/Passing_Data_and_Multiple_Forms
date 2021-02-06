/*
    Ashley Thibodeau
    Interface Programming
    C20210201
    Code Exercise 2
    GitHub Link: https://github.com/InterfaceProgramming/ce2-ThibodeauAshley-FS 
 */
using System;
using System.Collections.Generic;
using Thibodeau_Ashley_CE02.Models;

using Xamarin.Forms;

namespace Thibodeau_Ashley_CE02
{
    public partial class StudentDataEntryPage : ContentPage
    {
        public StudentDataEntryPage()
        {
            InitializeComponent();

            ageStepper.ValueChanged += AgeStepper_ValueChanged;
            cancelButton.Clicked += CancelButton_Clicked;

            saveButton.Clicked += SaveButton_Clicked;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var bindingObject = BindingContext as StudentData;
            if(bindingObject.Name != null)
            {
                nameEntry.Text = bindingObject.Name;
                ageLabel.Text = bindingObject.Age.ToString();
                ageStepper.Value = bindingObject.Age;
                startDatePicker.Date = bindingObject.StartDate;

            }
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            var bindingObject = BindingContext as StudentData;
            bindingObject.Name = nameEntry.Text;
            bindingObject.Age = ageStepper.Value;
            bindingObject.StartDate = startDatePicker.Date;

            Navigation.PopAsync();
        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        private void AgeStepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            ageLabel.Text = "Age: " + ageStepper.Value.ToString();
        }
    }
}
