using BLL.Abstract;
using DAL.Abstract;
using ENT.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal= userDal;
        }

        public List<User> GetUsers()
        {
            
            return _userDal.GetAll();
        }

        public User GetUser(string userName,string password)
        {
            var user = _userDal.Get(a => a.UserName == userName && a.Password == password);

            return user;
        }

        public Dictionary<bool,string> AddUser(User user)
        {
            var IsThereAUser = _userDal.Get(a => a.UserName == user.UserName);
            var result = new Dictionary<bool, string>();
            if(IsThereAUser == null)
            {
                user.CreationDate = DateTime.Now;
                user.QuestionOrderCount = 1;
                _userDal.Add(user);
                result.Add(true, "Üye başarılı bir şekilde eklendi. Giriş yapabilirsiniz.");

                return result;
            }
            else
            {
                result.Add(false, "Bu kullanıcı adında bir üye var!");
                return result;
            }
        }

        public User GetById(int id)
        {
            return _userDal.Get(a => a.Id== id);
        }
    }
}
