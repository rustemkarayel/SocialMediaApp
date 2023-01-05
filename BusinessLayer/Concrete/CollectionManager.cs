using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;

namespace BusinessLayer.Concrete
{
    public class CollectionManager : ICollectionService
    {
        ICollectionDal collectionDal;
        public CollectionManager(ICollectionDal collectionDal)
        {
            this.collectionDal= collectionDal;
        }

        public void CollectionDelete(Collection collection)
        {
            collectionDal.delete(collection);
        }

        public void CollectionInsert(Collection collection)
        {
            collectionDal.insert(collection);
        }

        public List<Collection> CollectionList()
        {
            return collectionDal.list();
        }

        public void CollectionUpdate(Collection collection)
        {
            collectionDal.update(collection);
        }

        public Collection GetCollectionById(int id)
        {
            return collectionDal.get(collection=>collection.CollectionId==id);
        }
    }
}
