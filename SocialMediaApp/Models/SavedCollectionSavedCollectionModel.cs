using EntityLayer;

namespace SocialMediaApp.Models
{
    public class SavedCollectionSavedCollectionModel
    {
        public SavedCollection SavedCollectionModel { get; set; }
        public IEnumerable<Saved> SavedModel { get; set; }
        public IEnumerable<Collection> CollectionModel { get; set; }
    }
}
