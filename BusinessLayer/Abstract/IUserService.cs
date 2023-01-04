using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserService
    {
        void UserInsert(User user);        
        void UserDelete(User user);
        void UserUpdate(User user);
        List<User> UserList();
        User UserGetById(int id);
        User UserGetByName(string name);           
    }
}
