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
        void savedCollectionInsert(SavedCollection savedCollection);
        void savedCollectionDelete(SavedCollection savedCollection);
        void savedCollectionUpdate(SavedCollection savedCollection);
        List<SavedCollection> savedCollectionList();
        SavedCollection savedCollectionGetById(int id);

    }
}
