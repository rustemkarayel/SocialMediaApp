using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISavedService
    {
        void SavedInsert(Saved saved);
        void SavedDelete(Saved saved);
        void SavedUpdate(Saved saved);  
        List<Saved> SavedList();
        Saved SavedGetById(int id); 
    }
}
