using System;
using System.Collections.Generic;

namespace api_blog
{
    public partial class Comments
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string Body { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public byte[] Version { get; set; }

        public virtual Blogs Blog { get; set; }
    }
}
