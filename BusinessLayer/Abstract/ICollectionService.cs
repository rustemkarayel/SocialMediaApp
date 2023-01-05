using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface ICollectionService
    {
        void CollectionInsert(Collection collection);
        void CollectionUpdate(Collection collection);
        void CollectionDelete(Collection collection);
        List<Collection> CollectionList();
        Collection GetCollectionById(int id);
    }
}