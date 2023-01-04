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

        public void savedCollectionDelete(SavedCollection savedCollection)
        {
            savedCollectionDal.delete(savedCollection);
        }

        public SavedCollection savedCollectionGetById(int id)
        {
            return savedCollectionDal.get(x => x.CollectionId == id);
        }

        public void savedCollectionInsert(SavedCollection savedCollection)
        {
            savedCollectionDal.insert(savedCollection);
        }

        public List<SavedCollection> savedCollectionList()
        {
            return savedCollectionDal.list();
        }

        public void savedCollectionUpdate(SavedCollection savedCollection)
        {
            savedCollectionDal.update(savedCollection);
        }
    }
}
