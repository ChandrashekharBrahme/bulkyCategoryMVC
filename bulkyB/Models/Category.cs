using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace bulkyB.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
       // [Required]
        public required string Name { get; set; }

        [DisplayName("Order")]
        [Range(1,100,ErrorMessage =" You can enter order only 1 to 100")]
        public int DisplayOrder { get; set; }    

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;       // setting deafault value for 
    }
}
