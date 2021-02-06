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

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StudentDataEntryPage
            {
                BindingContext = passedStudentData

            });
        }
    }
}
