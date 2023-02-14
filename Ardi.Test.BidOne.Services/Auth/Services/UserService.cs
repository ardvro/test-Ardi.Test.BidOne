using Ardi.Test.BidOne.Interfaces;
using Ardi.Test.BidOne.Interfaces.Auth.Domain;
using Ardi.Test.BidOne.Interfaces.Auth.Interfaces;
using Ardi.Test.BidOne.Services.Auth.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ardi.Test.BidOne.Services.Auth.Services
{
    public class UserService : IUserService
    {
        const string JsonFile = "users.json";

        private readonly ILogger _logger;
        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }

        public UserRegisterCode Register(UserRegistration userRegistration)
        {
            var users = getUsers();
            var user = users.FirstOrDefault(x=>x.Username.Trim().ToLower() == userRegistration.Username.Trim().ToLower());
            if (user != null)
            {
                user.Email = userRegistration.Email;
                user.Password = userRegistration.Password;
            }
            else
            {
                user = new UserEntity
                {
                    Username = userRegistration.Username,
                    Email = userRegistration.Email,
                    Password = userRegistration.Password
                };
                users.Add(user);
            }

            var json = JsonSerializer.Serialize(users);
            File.WriteAllText(JsonFile, json);
            
            return UserRegisterCode.Succeed;
        }

        public List<User> GetUsers()
        {
            if (!File.Exists(JsonFile))
            {
                return new List<User>();
            }

            var users = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(JsonFile));
            return users;
        }

        private List<UserEntity> getUsers()
        {
            if (!File.Exists(JsonFile))
            {
                return new List<UserEntity>();
            }

            var users = JsonSerializer.Deserialize<List<UserEntity>>(File.ReadAllText(JsonFile));
            return users;
        }


    }
}
