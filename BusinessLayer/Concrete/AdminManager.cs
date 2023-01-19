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
    public class AdminManager : IAdminService
    {
        IAdminDal adminDal;
        public AdminManager(IAdminDal adminDal)
        {
            this.adminDal= adminDal;
        }

        public void AdminDelete(Admin admin)
        {
            adminDal.delete(admin);          
        }

        public Admin AdminGetByEMail(string email)
        {
            return adminDal.get(x => x.AdminMail == email);
        }

        public Admin AdminGetById(int id)
        {
            return adminDal.get(x=>x.AdminId==id);
        }

        public void AdminInsert(Admin admin)
        {
            adminDal.insert(admin);
        }

        public List<Admin> AdminList()
        {
            return adminDal.list();
        }

        public void AdminUpdate(Admin admin)
        {
            adminDal.update(admin);
        }
    }
}
