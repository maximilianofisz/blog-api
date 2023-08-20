using System;
using System.Collections.Generic;

namespace api_blog
{
    public partial class Blogs
    {
        public Blogs()
        {
            Comments = new HashSet<Comments>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public byte[] Version { get; set; }

        public virtual Users CreatedByNavigation { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
    }
}
