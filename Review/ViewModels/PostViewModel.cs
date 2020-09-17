using Review.Data;
using Review.Models;
using Review.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Review.ViewModels
{
    public class PostViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private DataAccess<Post> dataAccess;

        private bool _IsBusy;
        public bool IsBusy
        {
            get
            {
                return _IsBusy;
            }
            set
            {
                _IsBusy = value;
                OnPropertyChanged();
            }
        }

        private string _keyword;
        public string Keyword
        {
            get
            {
                return _keyword;
            }
            set
            {
                _keyword = value;
                OnPropertyChanged();
            }
        }
        private List<Post> _posts;
        public List<Post> posts
        {
            get
            {
                return _posts;
            }
            set
            {
                _posts = value;
                OnPropertyChanged();
            }
        }

        private List<Post> TempPosts;
      
        public PostViewModel()
        {
           dataAccess = new DataAccess<Post>();

            _ = InitializeDataAsync();
        }

        private async Task InitializeDataAsync()
        {
            IsBusy = true;
            var postService = new PostServices();
            posts = await postService.GetPostsAsync();
            TempPosts = posts;

            await Task.Delay(1000);
            IsBusy = false;
        }
        public Command SearchCommand => new Command(Search);

        private void Search()
        {
            if (!string.IsNullOrWhiteSpace(_keyword))
            {
                posts = TempPosts.FindAll(p => p.body.ToLower().Contains(_keyword));
            }
            else
            {
                posts = TempPosts;
            }
        }

        public Command AddCommand => new Command<Post>(async (post) =>  await AddPostAsync(post));

        private async Task AddPostAsync(Post post)
        {
            IsBusy = true;
            var postService = new PostServices();
            await postService.Post_PostAsync(post);
            dataAccess.AddPost(post);

            await Task.Delay(1000);
            IsBusy = false;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
