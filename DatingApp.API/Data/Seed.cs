using System;
using System.Collections.Generic;
using System.Linq;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DatingApp.API.Data
{
    public class Seed
    {
        public static void SeedUsers(DataContext _dataContext)
        {
            if(!_dataContext.Users.Any())
            {
                var userData =  System.IO.File.ReadAllText("Data/UserSeedData.json");
                var users = JsonConvert.DeserializeObject<List<User>>(userData);
                
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash("password", out passwordHash, out passwordSalt);

                foreach(var user in users)
                {
                   
                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                    _dataContext.Users.Add(user);
                
                }
            }
            _dataContext.SaveChanges();
        }

        private static void CreatePasswordHash(string v, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac= new System.Security.Cryptography.HMACSHA512())
            {
                    passwordSalt = hmac.Key;
                    passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(v));
            }
        }
    }
}