using Review.Models;
using Review.ViewModels;
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
    public partial class AddPost : ContentPage
    {
        private Post post = new Post();
        public AddPost()
        {
            InitializeComponent();
            BindingContext = post;
        }

        private async void AddPostClicked(object sender, EventArgs e)
        {
            var VModel = new PostViewModel();
            BindingContext = VModel;
            VModel.AddCommand.Execute(post);
            await Navigation.PopModalAsync();
        }
    }
}