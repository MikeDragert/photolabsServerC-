using System.ComponentModel.DataAnnotations.Schema;

namespace Photolabs.Models
{
    public class Topic {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title{ get; set; }
        public string Slug{ get; set; }
        public Photo Photo { get; set; }
    }
}
