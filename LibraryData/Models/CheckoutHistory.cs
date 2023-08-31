using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class CheckoutHistory
    {

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
