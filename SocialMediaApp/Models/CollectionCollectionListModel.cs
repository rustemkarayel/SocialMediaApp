using EntityLayer;

namespace SocialMediaApp.Models
{
    public class CollectionCollectionListModel
    {
        public Collection CollectionModel { get; set; }

        public IEnumerable<Collection> CollectionListModel { get; set; }
    }
}
