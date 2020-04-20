using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Dtos;
using WebApi.Repository;

namespace WebApi.Services
{
    public class UserService : IUserRepository
    {
        private DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public User Authenticate(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.User.SingleOrDefault(x => x.userName == userName);

            // check if userName exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.passwordHash, user.passwordSalt))
                return null;

            // authentication successful
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            List<User> users = _context.User.ToList();
            List<User> users2 = _context.User.ToList();
            foreach (User user in users)
            {
                if (user.state == false)
                {
                    users2.Remove(user);
                }
            }
            return users2;
        }

        public User GetById(int id)
        {
            return _context.User.Find(id);
        }

        public User Create(User user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Clave es requerida");

            if (_context.User.Any(x => x.userName == user.userName))
                throw new AppException("El usurio \"" + user.userName + "\" ya existe.");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.passwordHash = passwordHash;
            user.passwordSalt = passwordSalt;
            _context.User.Add(user);
            _context.SaveChanges();

            return user;
        }

        //public User Update(User userParam, string password = null)
        public User Update(UserDto userParam)
        {
            var user = _context.User.Find(userParam.idUser);

            if (user == null)
                throw new AppException("Usuario no existe.");

            if (userParam.userName != user.userName)
            {
                // userName has changed so check if the new userName is already taken
                if (_context.User.Any(x => x.userName == userParam.userName))
                    throw new AppException("El usuario " + userParam.userName + " ya existe");
            }

            // update user properties
            user.update(userParam);

            // update password if it was entered
            // if (!string.IsNullOrWhiteSpace(userParam.password))
            // {
            //     byte[] passwordHash, passwordSalt;
            //     CreatePasswordHash(userParam.password, out passwordHash, out passwordSalt);

            //     user.passwordHash = passwordHash;
            //     user.passwordSalt = passwordSalt;
            // }

            _context.User.Update(user);
            _context.SaveChanges();
            return user;
        }

        public User Delete(int id)
        {
            var user = _context.User.Find(id);
            if (user == null || user.state == false)
            {
                throw new AppException("Usuario no existe.");
            }
            _context.User.Remove(user);
            _context.SaveChanges();
            return user;
        }

        // private helper methods

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

        public User Insert(User user)
        {
            throw new NotImplementedException();
        }
    }
}