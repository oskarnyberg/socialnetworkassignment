using SocialNetworkAPI.Dtos;
using SocialNetworkAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkAPI.Repositories.Posts
{
    public interface IPostRepository
    {
        List<Post> GetPosts();
        Post GetPost(int id);
        void CreatePost(PostDto postDto);
        Post UpdatePost(int postId, PostDto postDto);
        void DeletePost(int userId, int postId);
        Post LikeUnlikePost(int userId, int postId);
    }
}
