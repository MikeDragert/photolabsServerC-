using Photolabs.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Photolabs.Models {
  [NotMapped]
  public class PhotoExtended {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public Dictionary<string, string>? Urls { get; set; }
    public Dictionary<string, string>? User { get; set; }
    public Dictionary<string, string>? Location { get; set; }
    public string? TopicTitle { get; set; }
    public List<PhotoExtended>? similar_photos { set; get; }
  }
}
