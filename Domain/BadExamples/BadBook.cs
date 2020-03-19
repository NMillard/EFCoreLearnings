using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.BadExamples {
    
    /// <summary>
    /// Extreme case of a poorly designed class
    /// </summary>
    [Table("Books")]
    public class BadBook {
        public BadBook() {
            // Never have constructors that leave your objects in an invalid state.
            // Especially when it's just to please an external framework...
        }

        public BadBook(string name, DateTime released) {
            Name = name;
            Released = released;
        }

        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Book name is required")]
        [MaxLength(150)]
        public string Name { get; set; }

        [DataType("DateTime2")]
        public DateTime Released { get; set; }
        
        [Required]
        public Author Author { get; set; }
        
        [ForeignKey("Author")]
        public string AuthorId { get; set; }
    }
}