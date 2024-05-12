using System.ComponentModel.DataAnnotations.Schema;

namespace Photolabs.Models{
  public class UserAccount
  {
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Username { get; set; }
    public string ProfileUrl { get; set; }
    public virtual ICollection<Photo> Photos { get; set; }
  }
}
