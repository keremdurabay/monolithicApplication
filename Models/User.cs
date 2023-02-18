using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [StringLength(150)]
        [Required]
        public string firstName { get; set; }

        [StringLength(150)]
        [Required]
        public string lastName { get; set; }

        [NotMapped]
        public string fullName
        {
            get { return firstName + " " + lastName; }
            private set { }  
        }


    }
}
