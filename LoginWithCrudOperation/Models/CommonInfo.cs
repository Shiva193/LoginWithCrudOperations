using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace LoginWithCrudOperation.Models
{
    public class CommonInfo
    {
        public string InfoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string VideoUrl { get; set; }
        public string Status { get; set; }
        public int Sequence { get; set; }
        public string UpdatedBy { get; set; }
        public string DeletedBy { get; set; }
    }
}
