using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinSqlite
{
    public partial class TodoItemPage : ContentPage
    {
        public TodoItemPage()
        {
            InitializeComponent();


            SaveButton.Clicked += async (sender, args) =>
            {
                var todoItem = (TodoItem)BindingContext;
                await App.Database.SaveItemAsync(todoItem);
                await Navigation.PopAsync();
            };


            DeleteButton.Clicked += async (sender, args) =>
            {
                var todoItem = (TodoItem)BindingContext;
                await App.Database.DeleteItemAsync(todoItem);
                await Navigation.PopAsync();
            };


            CancelButton.Clicked += async (sender, args) =>
            {
                await Navigation.PopAsync();
            };
        }
    }
}