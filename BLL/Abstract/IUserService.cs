using ENT.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IUserService
    {
        List<User> GetUsers();

        User GetUser(string userName,string password);

        Dictionary<bool,string> AddUser(User user);

        User GetById(int id);
    }
}
