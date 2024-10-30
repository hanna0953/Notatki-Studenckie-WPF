using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notatki_Studenckie_v3
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryNameDb { get; set; }// = string.Empty;

        public ICollection<Topic> Topic { get; set; }
    }
}
