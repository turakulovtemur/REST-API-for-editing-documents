using TestRestApiApp.Enums;
using TestRestApiApp.Models;

namespace TestRestApiApp.DTO
{
    public class DocumentDto
    {
        public DocumentDto() { }

        public DocumentDto(Document document)
        {
            Id = document.Id;
            Status = document.Status.ToString();
            Data = document.Data;
            CreatedDate = document.CreatedDate;
            ModifiedDate = document.ModifiedDate;
        }

        public Guid Id { get; set; }

        public string Status { get; set; }

        public string Data { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
