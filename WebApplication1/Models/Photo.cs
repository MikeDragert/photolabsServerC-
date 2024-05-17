using System.ComponentModel.DataAnnotations.Schema;

namespace Photolabs.Models {
  public class Photo {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string FullUrl { get; set; }
    public string RegularUrl{ get; set; }
    public string City{ get; set; }
    public string Country{ get; set; }
    public int? UserAccountId { get; set; }
    public int? TopicId { get; set; }
  }
}
