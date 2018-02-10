using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinSqlite
{
    public partial class TodoListPage : ContentPage
    {
        public TodoListPage()
        {
            InitializeComponent();

            ToolBarItem.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new TodoItemPage
                {
                    BindingContext = new TodoItem()
                });
            };

            listView.ItemSelected += async (sender, args) =>
            {
                ((App)App.Current).ResumeAtTodoId = (args.SelectedItem as TodoItem).ID;
                Debug.WriteLine("setting ResumeAtTodoId = " + (args.SelectedItem as TodoItem).ID);

                await Navigation.PushAsync(new TodoItemPage
                {
                    BindingContext = args.SelectedItem as TodoItem
                });
            };

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtTodoId = -1;
            listView.ItemsSource = await App.Database.GetItemsAsync();
        }
    }
}