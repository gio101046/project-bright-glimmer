using BrightGlimmer.Data.Domain;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrightGlimmer.Data.Repositories
{
    public class StudentRepository
    {
        private readonly SqliteContext context;


        public StudentRepository(SqliteContext context)
        {
            this.context = context;
        }

        public Student Create(Student student)
        {
            EntityEntry<Student> entry = context.Students.Add(student);
            context.SaveChanges();
            return entry.Entity;
        }

        public void Update(Student student)
        {
            context.SaveChanges();
        }

        public void Remove(Guid id)
        {
            context.Students.Remove(GetById(id));
            context.SaveChanges();
        }

        public IQueryable<Student> GetAll()
        {
            return context.Students;
        }

        public Student GetById(Guid id)
        {
            return context.Students.Find(id);
        }
    }
}
