using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coches00.Models
{
    public class Car
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        //[ForeignKey(typeof(User))]     // Specify the foreign key
        [Indexed]
        public int UserId { get; set; }

        [Unique]
        public string Placas { get; set; }
        public string Marca { get; set; }
        public int Modelo { get; set; }
        public string Color { get; set; }
        public string Foto { get; set; }
        public string Estado { get; set; }
        public string Alias { get; set; }

        /*[ManyToOne]      // Many to one relationship with User
        public User User { get; set; }*/
    }
}
