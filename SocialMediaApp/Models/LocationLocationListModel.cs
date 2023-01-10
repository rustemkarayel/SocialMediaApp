using EntityLayer;

namespace SocialMediaApp.Models
{
    public class LocationLocationListModel
    {
        public Location locationModel { get; set; }

        public IEnumerable<Location> locationsModel { get; set; }
    }
}
