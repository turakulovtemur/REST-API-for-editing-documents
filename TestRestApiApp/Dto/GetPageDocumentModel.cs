using System.ComponentModel;

namespace TestRestApiApp.Dto
{
    public class GetPageDocumentModel
    {

        public int PageNumber { get; set; } = 1;


        public int PageSize { get; set; } = 3;
    }
}
