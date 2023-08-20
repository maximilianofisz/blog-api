using api_blog;
using Blog.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DataAccess.Repositories
{
    public class CommentsRepository : EFCRUDRepository<Comments>
    {
        public CommentsRepository(BlogContext context) : base(context) { }

        public override DbSet<Comments> GetDBSet()
        {
            return base.dbContext.Set<Comments>();
        }
    }
}
