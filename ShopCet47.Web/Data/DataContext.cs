﻿
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopCet47.Web.Data.Entities;



public class DataContext : IdentityDbContext<User>
{
    public DbSet<Product> Products { get; set; }


    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
}

