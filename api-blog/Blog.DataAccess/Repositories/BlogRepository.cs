using api_blog;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Model.Repositories
{
    public class BlogRepository : EFCRUDRepository<Blogs>
    {
        public BlogRepository(BlogContext context) : base(context) { }

        public override DbSet<Blogs> GetDBSet()
        {
            return base.dbContext.Set<Blogs>();
        }
    }
}
