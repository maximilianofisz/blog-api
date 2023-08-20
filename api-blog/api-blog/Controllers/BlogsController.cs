using api_blog;
using api_blog.Models;
using Blog.DataAccess.Repositories;
using Blog.Model.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace Messaging.Api.Controllers
{
    [Route("api/blogs")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private BlogRepository repository;

        public BlogsController(BlogRepository repository)
        {
            this.repository = repository;
        }


        [HttpHead]
        [HttpGet]
        public ActionResult<IEnumerable<BlogDTO>> GetBlogs()
        {
            IEnumerable<Blogs> blogs = this.repository.FindAll();
            IEnumerable<BlogDTO> result = new List<BlogDTO>();
            foreach(Blogs blog in blogs)
            {
                BlogDTO blogdto = new BlogDTO();
                blogdto.Id = blog.Id;
                blogdto.Title = blog.Title;
                blogdto.Body = blog.Body;
                blogdto.CreatedBy = blog.CreatedBy;
            }

            return Ok(result);
        }


        [HttpGet("{id}")]
        public ActionResult<BlogDTO> GetBlogById([FromRoute] int id)
        {
            Blogs blog = repository.FindById(id);
            if (blog == null)
            {
                return NotFound();
            }

            BlogDTO response = new BlogDTO();
            response.Id = blog.Id;
            response.Title = blog.Title;
            response.Body = blog.Body;
            response.CreatedBy = blog.CreatedBy;

            return Ok(response);
        }

        [HttpPost]
        public ActionResult AddBlog([FromBody][Required] BlogForCreationDTO blogToCreate)
        {
            Blogs blog = new Blogs();
            blog.Title = blogToCreate.Title;
            blog.Body = blogToCreate.Body;
            blog.CreatedBy = blogToCreate.CreatedBy;
            blog.CreatedDate = DateTime.Now;

            this.repository.Save(blog);
            this.repository.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBlog([FromRoute] int id, [FromBody] BlogForUpdateDTO blogForUpdate)
        {
            Blogs currentBlog = this.repository.FindById(id);

            if (currentBlog == null)
            {
                return NotFound();
            }

            // Check if messaging is being logically deleted (One could use these deletedBy and deletedDates fields to filter the dbSets for GET requests)
            if (blogForUpdate.DeletedBy != null)
            {
                currentBlog.DeletedBy = blogForUpdate.DeletedBy;
                currentBlog.DeletedDate = DateTime.Now;
            }

            currentBlog.Title = (blogForUpdate.Title == null ? currentBlog.Title : blogForUpdate.Title);
            currentBlog.Body = (blogForUpdate.Body == null ? currentBlog.Body : blogForUpdate.Body);
            currentBlog.LastModifiedDate = DateTime.Now;

            this.repository.Update(currentBlog);

            this.repository.SaveChanges();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBlog([FromRoute] int id)
        {
            Blogs blog = this.repository.FindById(id);

            if (blog == null)
            {
                return NotFound();
            }

            this.repository.Delete(blog);
            this.repository.SaveChanges();
            return NoContent();
        }
    }
}
