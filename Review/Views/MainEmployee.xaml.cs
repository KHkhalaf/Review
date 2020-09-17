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
    public partial class MainEmployee : ContentPage
    {
        private int angular = 0;
        public MainEmployee()
        {
            InitializeComponent();


            //Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
            //{
            //    Device.BeginInvokeOnMainThread(async () => {
            //        _ = await pvCircle.RotateTo(angular, 300, Easing.Linear);
            //    });
            //    angular += 30;
            //    return true;
            //});
        }

        private void PostTapped(object sender, ItemTappedEventArgs e)
        {
            listPosts.SelectedItem = null;
            Post post = e.Item as Post;
            Navigation.PushModalAsync(new PostDetail(post));
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var vm = BindingContext as PostViewModel;
            vm.SearchCommand.Execute(null);
        }

        private void GoToAddPostPage(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AddPost());
        }
    }
}