using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tweetbook.Contracts.V1;
using Tweetbook.Controllers.V1.Requests;
using Tweetbook.Controllers.V1.Response;
using Tweetbook.Domain;

namespace Tweetbook.Controllers
{

    public class PostsController : Controller
    {

        private readonly List<Post> _posts;

        public PostsController()
        {
            _posts = new List<Post>();
            for (var i = 0; i < 5; i++)
            {
                _posts.Add(new Post {
                    Id = Guid.NewGuid(),
                    Name = $" Post name{i}" 
                });

            }
        }

        [HttpGet(ApiRoutes.Posts.Get)]
        public IActionResult Get([FromRoute] Guid postId)
        {
            var post = _posts.SingleOrDefault(x => x.Id == postId);



            if (post == null)
            {
                return NotFound();
            }

            return Ok(_posts);
        }

        [HttpGet(ApiRoutes.Posts.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_posts);
        }

        [HttpPost(ApiRoutes.Posts.Create)]
        public IActionResult Create([FromBody] CreatePostRequest postRequest)
        {

            var post = new Post { Id = postRequest.Id };
            if (post.Id == Guid.Empty)
                post.Id = Guid.NewGuid();
            //return Ok(_posts[1].Id);
            _posts.Add(post);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Posts.Get.Replace("{postId}", post.Id.ToString());

            var response = new PostResponse { Id = post.Id };
            return Created(locationUri, post);
        }
    }
}