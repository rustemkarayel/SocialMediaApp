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
    public class SavedManager : ISavedService
    {
        ISavedDal savedDal;
        public SavedManager(ISavedDal savedDal)
        {
            this.savedDal = savedDal;
        }

        public void savedDelete(Saved saved)
        {
            savedDal.delete(saved);
        }

        public Saved savedGetById(int id)
        {
            return savedDal.get(x=>x.SavedId==id);
        }

        public void savedInsert(Saved saved)
        {
            savedDal.insert(saved);
        }

        public List<Saved> savedList()
        {
            return savedDal.list();
        }

        public void savedUpdate(Saved saved)
        {
            savedDal.update(saved); 
        }
    }
}
