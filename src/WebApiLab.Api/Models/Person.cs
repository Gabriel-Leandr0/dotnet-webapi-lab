using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiLab.Api.Models
{
    [Table("persons")]
    public class Person
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column("first_name", TypeName = "varchar(80)")]
        [MaxLength(80, ErrorMessage = "First name cannot exceed 80 characters.")]
        public string FirstName { get; set; }

        [Required]
        [Column("last_name", TypeName = "varchar(80)")]
        [MaxLength(80, ErrorMessage = "Last name cannot exceed 80 characters.")]
        public string LastName { get; set; }
        
        [Required]
        [Column("address", TypeName = "varchar(100)")]
        [MaxLength(100, ErrorMessage = "Address cannot exceed 100 characters.")]
        public string Address { get; set; }

        [Required]
        [Column("gender", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessage = "Gender cannot exceed 1 character.")]
        public string Gender { get; set; }
    }
}
