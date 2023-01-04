using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISavedCollectionService
    {
        void SavedCollectionInsert(SavedCollection savedCollection);
        void SavedCollectionDelete(SavedCollection savedCollection);
        void SavedCollectionUpdate(SavedCollection savedCollection);
        List<SavedCollection> SavedCollectionList();
        SavedCollection SavedCollectionGetById(int id);

    }
}
