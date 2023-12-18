using SQLite;

namespace SQLiteMaui.Models
{
    public class PersonContact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Gender { get; set; }
    }
}
