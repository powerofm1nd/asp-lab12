using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp_lab12.Models
{
    [Table("company")]
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

        [Column("founded_year")]
        public int? FoundedYear { get; set; }

        [MaxLength(100)]
        public string Industry { get; set; }

        public Company(string name, string address, int? foundedYear, string industry)
        {
            Name = name;
            Address = address;
            FoundedYear = foundedYear;
            Industry = industry;
        }
    }
}