﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ShopCet47.Web.Data.Entities;
using ShopCet47.Web.Helpers;

namespace ShopCet47.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private Random _random;


        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            var user = await _userHelper.GetUserByEmailAsync("silvio.ferreira.pinto@formandos.cinel.pt");
            
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Sílvio",
                    Lastname = "Pinto",
                    Email = "silvio.ferreira.pinto@formandos.cinel.pt",
                    UserName = "silvio.ferreira.pinto@formandos.cinel.pt"
                };

                var result = await _userHelper.AddUserAsync(user, "123456");
            
                if (result != IdentityResult.Success) 
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }

            if (!_context.Products.Any())
            {
                this.AddProduct("iPhone X",user);
                this.AddProduct("Rato Mickey",user);
                this.AddProduct("iWatch Series 4",user);
                this.AddProduct("Ipad 2",user);
                await _context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {

            _context.Products.Add(new Product

            {
                Name = name,
                Price = _random.Next(1000),
                IsAvailable = true,
                Stock = _random.Next(100),
                User = user
            });
        }
    }
}
