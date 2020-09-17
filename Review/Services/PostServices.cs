using Review.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Review.Services
{
    public class PostServices
    {
        private const string url = "https://jsonplaceholder.typicode.com/posts/";
        public async Task<List<Post>> GetPostsAsync()
        {
            RestClient<Post> restClient = new RestClient<Post>(url);
            var posts = await restClient.GetAsync();

            return posts;
        }
        public async Task<bool> Post_PostAsync(Post post)
        {
            RestClient<Post> restClient = new RestClient<Post>(url);
            var res = await restClient.PostAsync(post);

            return res;
        }
    }
}
