using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Video : LibraryAsset
    {
        [Required]
        public string Director { get; set; }
    }
}
