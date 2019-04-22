using BrightGlimmer.Data.Domain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrightGlimmer.Data.Repositories
{
    public class MongoStudentRepository
    {
        private const string dbName = "bright_glimmer";
        private const string collectionName = "Students";
        private IMongoDatabase db;

        public MongoStudentRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017"); /* REMOVE LATER */
            db = client.GetDatabase(dbName);
        }

        public List<Student> GetStudents()
        {
            return db.GetCollection<Student>(collectionName).Find(x => true).ToList();
        }

        public Student GetStudent(Guid id)
        {
            return db.GetCollection<Student>(collectionName).Find(student => student.Id == id).SingleOrDefault();
        }

        public Student GetStudentByEmail(string email)
        {
            return db.GetCollection<Student>(collectionName).Find(student => student.Email == email).Single();
        }

        public void Create(Student student)
        {
            db.GetCollection<Student>(collectionName).InsertOne(student);
        }

        public void Update(Student student)
        {
            var filter = Builders<Student>.Filter.Where(x => x.Id == student.Id);
            db.GetCollection<Student>(collectionName).ReplaceOne(filter, student);
        }

        public void Remove(Guid id)
        {
            var filter = Builders<Student>.Filter.Where(x => x.Id == id);
            var operation = db.GetCollection<Student>(collectionName).DeleteOne(filter);
        }
    }
}
