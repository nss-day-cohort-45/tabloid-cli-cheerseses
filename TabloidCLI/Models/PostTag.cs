using System;
using System.Collections.Generic;
using System.Text;

namespace TabloidCLI.Models
{
    public class PostTag
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int TagId { get; set; }
    }
}
