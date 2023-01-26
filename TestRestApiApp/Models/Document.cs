using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestRestApiApp.Enums;

namespace TestRestApiApp.Models
{
    [Table("Document")]
    public class Document
    {
        [Key]
        public Guid Id { get; set; }
      
        public Statuses Status { get; set; }

        public string Data { get; set; }

        public DateTime CreatedDate { get; set; }

       
        public DateTime? ModifiedDate { get; set; }
    }
}
