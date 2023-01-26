using TestRestApiApp.Dto;
using TestRestApiApp.DTO;
using TestRestApiApp.Models;

namespace TestRestApiApp.Services
{
    public interface IDocumentService
    {
        public Task<DocumentDto> CreateDraftDocument(DocumentModel model, CancellationToken cancellation);

        public Task<DocumentDto> GetById(Guid id, CancellationToken cancellation);

        public Task<DocumentDto> UpdateDocument(DocumentModel model, CancellationToken cancellation);

        public Task PublishDocument(Guid id, CancellationToken cancellation);

        public Task<IEnumerable<DocumentDto>> GetAll(GetPageDocumentModel model,CancellationToken cancellation);

    }
}
