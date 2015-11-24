using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoDBSample
{
    class Program
    {
        static void Main(string[] args)
        {            
            //连接信息        
            string conn = "mongodb://localhost";
            string database = "demoBase";
            string collection = "demoCollection";
            MongoServer mongodb = MongoServer.Create(conn);
            //连接数据库        
            MongoDatabase mongoDataBase = mongodb.GetDatabase(database);
            //选择数据库名         
            MongoCollection mongoCollection = mongoDataBase.GetCollection(collection);
            //选择集合，相当于表           
            mongodb.Connect();
            //普通插入          
            var o = new { Uid = 123, Name = "xixiNormal", PassWord = "111111" };
            mongoCollection.Insert(o);
            //对象插入        
            Person p = new Person { Uid = 124, Name = "xixiObject", PassWord = "222222" };
            mongoCollection.Insert(p);
            //BsonDocument 插入          
            BsonDocument b = new BsonDocument();
            b.Add("Uid", 125);
            b.Add("Name", "xixiBson");
            b.Add("PassWord", "333333");
            mongoCollection.Insert(b);

            Console.WriteLine(mongoCollection.FullName);

            QueryDocument query = new QueryDocument();
            query.Add("Uid", 125);
            MongoCursor<Person> pers = mongoCollection.FindAs<Person>(query);
            //Console.WriteLine(pe.Name);
            Console.ReadLine();
        }
    }
    class Person
    {
        public int Uid;
        public string Name;
        public string PassWord;
    }
}
