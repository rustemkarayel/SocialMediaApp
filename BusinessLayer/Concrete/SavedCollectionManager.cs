using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SavedCollectionManager : ISavedCollectionService
    {
        ISavedCollectionDal savedCollectionDal;
        public SavedCollectionManager(ISavedCollectionDal savedCollectionDal)
        {
            this.savedCollectionDal = savedCollectionDal;
        }

        public void SavedCollectionDelete(SavedCollection savedCollection)
        {
            savedCollectionDal.delete(savedCollection);
        }

        public SavedCollection SavedCollectionGetById(int id)
        {
            return savedCollectionDal.get(x => x.CollectionId == id);
        }

        public void SavedCollectionInsert(SavedCollection savedCollection)
        {
            savedCollectionDal.insert(savedCollection);
        }

        public List<SavedCollection> SavedCollectionList()
        {
            return savedCollectionDal.list();
        }

        public void SavedCollectionUpdate(SavedCollection savedCollection)
        {
            savedCollectionDal.update(savedCollection);
        }
    }
}
