using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pipeline_GithubActions.Entity
{
    [Table("tb_person")]
    public class Person
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("age")]
        public int Age { get; set; }
    }
}
