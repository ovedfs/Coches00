using SQLite;

namespace Coches00.Models
{
    public class File
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public int CarId { get; set; }

        [Unique]
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Archivo { get; set; }
        public string Nota { get; set; }
    }
}
