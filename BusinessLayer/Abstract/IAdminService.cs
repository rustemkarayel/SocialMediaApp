using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        void AdminInsert(Admin admin);
        void AdminDelete(Admin admin);
        void AdminUpdate(Admin admin);
        List<Admin> AdminList();
        Admin AdminGetById(int id);
        Admin AdminGetByEMail(string email);
    }
}
