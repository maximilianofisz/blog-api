using api_blog;
using Blog.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DataAccess.Repositories
{
    public class UsersRepository : EFCRUDRepository<Users>
    {
        public UsersRepository(BlogContext context) : base(context) { }

        public override DbSet<Users> GetDBSet()
        {
            return base.dbContext.Set<Users>();
        }
    }
}
