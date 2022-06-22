using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.API.Entities
{
    public class BaseEntity
    {
        [Key]
        public long ID { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }
        
    }
}
