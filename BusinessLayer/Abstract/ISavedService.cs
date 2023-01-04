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
        void savedInsert(Saved saved);
        void savedDelete(Saved saved);
        void savedUpdate(Saved saved);  
        List<Saved> savedList();
        Saved savedGetById(int id); 
    }
}
