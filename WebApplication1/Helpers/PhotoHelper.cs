using Microsoft.EntityFrameworkCore;
using Photolabs.Models;
using Photolabs.DAL;

namespace PhotolabsCSharp.Helpers {
  public class PhotoHelper {
    private PhotolabContext _context = null;

    public PhotoHelper(PhotolabContext context) {
      _context = context;
    }

    public List<PhotoExtended> getPhotos(string serverUrl, int topidId = -1) {
      string[] enptyString = { };
      return getPhotos(serverUrl, enptyString, topidId);
    }

    public List<PhotoExtended> getPhotos(string serverUrl, string[] searchTerms, int topicId = -1) {


      var query = _context.Photos
        .Join(
          _context.UserAccounts,
          p => p.UserAccountId,
          ua => ua.Id,
          (p, ua) => new {
            Id = p.Id,
            FullUrl = p.FullUrl,
            RegularUrl = p.RegularUrl,
            City = p.City,
            Country = p.Country,
            Username = ua.Username,
            FullName = ua.FullName,
            ProfileUrl = ua.ProfileUrl,
            TopicId = p.TopicId
          }
        )
        .Join(
          _context.Topics,
          p => p.TopicId,
          t => t.Id,
          (p, t) => new {
            Id = p.Id,
            FullUrl = p.FullUrl,
            RegularUrl = p.RegularUrl,
            City = p.City,
            Country = p.Country,
            Username = p.Username,
            FullName = p.FullName,
            ProfileUrl = p.ProfileUrl,
            TopicTitle = t.Title,
            TopicId = t.Id
          }
        );

      if (searchTerms != null) {
        foreach (string searchTerm in searchTerms) {
          query = query.Where(photo =>
            photo.City.ToLower().Contains(searchTerm) ||
            photo.Country.ToLower().Contains(searchTerm) ||
            photo.Username.ToLower().Contains(searchTerm) ||
            photo.FullName.ToLower().Contains(searchTerm) ||
            photo.TopicTitle.ToLower().Contains(searchTerm)
          );
        }
      }

      if (topicId >= 0) {
        query = query.Where(photo =>
          photo.TopicId.Equals(topicId)
        );
      }

      return query.Select(photo => new PhotoExtended
      {
        Id = photo.Id,
        Urls = new Dictionary<string, string> {
            {"full", $"{serverUrl}{photo.FullUrl}"},
            {"regular",$"{serverUrl}{photo.RegularUrl}"}
          },
        User = new Dictionary<string, string> {
            {"username", photo.Username},
            {"name", photo.FullName},
            {"profile", $"{serverUrl}{photo.ProfileUrl}"}
          },
        Location = new Dictionary<string, string> {
            {"city", photo.City},
            {"country", photo.Country}
          },
        TopicTitle = photo.TopicTitle,
        SimilarPhotos = (
            from simPhoto in _context.Photos
            join simUserAccount in _context.UserAccounts
            on simPhoto.UserAccountId equals simUserAccount.Id
            where simPhoto.Id != photo.Id && simPhoto.TopicId == photo.TopicId
            select new PhotoExtended
            {
              Id = simPhoto.Id,
              Urls = new Dictionary<string, string> {
                {"full",  $"{serverUrl}{simPhoto.FullUrl}"},
                {"regular",$"{serverUrl}{simPhoto.RegularUrl}"}
              },
              User = new Dictionary<string, string> {
                {"username", simUserAccount.Username},
                {"name", simUserAccount.FullName},
                {"profile", $"{serverUrl}{simUserAccount.ProfileUrl}"}
              },
              Location = new Dictionary<string, string> {
                {"city", simPhoto.City},
                {"country", simPhoto.Country}
              },
            }
          ).Take(4).ToList()
      }).ToList();
    }

  }


}
