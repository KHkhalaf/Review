using Review.Data;
using Review.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Review.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostsSQL : ContentPage
    {
        public PostsSQL()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            DataAccess<Post> dataAccess = new DataAccess<Post>();
            listOfPosts.ItemsSource = dataAccess.GetPosts();
            base.OnAppearing();
        }
    }
}