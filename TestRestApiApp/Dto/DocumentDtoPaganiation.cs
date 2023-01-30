using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using TestRestApiApp.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestRestApiApp.Dto
{
    public class DocumentDtoPaganiation
    {
        public List<DocumentDto> documentDtos { get; set; } 

        public int PageCount { get; set; } //кол-во страниц всего
        public int CurrentPage { get; set; } //текущая страница
         

    }
}
