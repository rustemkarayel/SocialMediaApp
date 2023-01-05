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
    public class UserManager : IUserService
    {
        IUserDal userDal;
        public UserManager(IUserDal userDal)
        {
            this.userDal = userDal;
        }

        public void UserDelete(User user)
        {
            userDal.delete(user);
        }

        public User UserGetById(int id)
        {
            return userDal.get(x => x.UserId == id);
        }

        public User UserGetByName(string name)
        {
            return userDal.get(x => x.NickName == name);
        }

        public void UserInsert(User user)
        {
            userDal.insert(user);
        }

        public List<User> UserList()
        {
            return userDal.list();
        }

        public void UserUpdate(User user)
        {
            userDal.update(user);
        }
    }
}
