﻿using Microsoft.EntityFrameworkCore;
using ShopOnline.DataAccess.Data;
using ShopOnline.DataAccess.Repository.IRepository;
using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public ICategoryRepository Category{ get; private set; }
        public UnitOfWork(ApplicationDbContext db) 
        {
            _db = db;
            Category= new CategoryRepository(_db);
        }
       

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}