using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class CheckoutHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public LibraryAsset LibraryAsset { get; set; }

        [Required]
        public LibraryCard LibraryCard { get; set; }

        [Required]
        public DateTime CheckedOut { get; set; }

        public DateTime? CheckedIn { get; set; }

    }
}
