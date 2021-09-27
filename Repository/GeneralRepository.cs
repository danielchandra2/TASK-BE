﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TASK_BE.Context;
using TASK_BE.Repository.Interfaces;

namespace TASK_BE.Repository
{
    public class GeneralRepository<Entity, TId> : IGenericRepository<Entity, TId> where Entity : class
    {
        private readonly MyContext context;

        public GeneralRepository(MyContext context)
        {
            this.context = context;
        }
        public IEnumerable<Entity> GetAll()
        {
            var get = context.Set<Entity>().ToList();
            return get;
        }

        public Entity GetById(TId Id)
        {
            var GetById = context.Set<Entity>().Find(Id);
            return GetById;
        }

        public int Post(Entity obj)
        {
            context.Set<Entity>().Add(obj);
            var result = context.SaveChanges();
            return result;
        }

        public int Put(Entity obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            var result = context.SaveChanges();
            return result;
        }
        public int Delete(TId Id)
        {
            var deleted = GetById(Id);
            context.Set<Entity>().Remove(deleted);
            var result = context.SaveChanges();
            return result;
        }

    }
}
