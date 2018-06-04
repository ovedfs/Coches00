using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coches00.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        [Unique]
        public string Email { get; set; }

        public string Password { get; set; }

        /*[OneToMany(CascadeOperations = CascadeOperation.All)]      // One to many relationship with Car
        public List<Car> Valuations { get; set; }*/
    }
}
