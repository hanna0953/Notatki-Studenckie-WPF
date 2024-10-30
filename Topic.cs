using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notatki_Studenckie_v3
{
    public class Topic
    {
        public int TopicId { get; set; }
        public string TopicTextDb { get; set; } = string.Empty;

        public int CategoryRefId { get; set; }

        [ForeignKey("CategoryRefId")]
        public Category Category { get; set; }
    }
}
