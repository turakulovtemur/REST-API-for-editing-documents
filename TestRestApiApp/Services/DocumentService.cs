using Microsoft.EntityFrameworkCore;
using TestRestApiApp.DataContexts;
using TestRestApiApp.Dto;
using TestRestApiApp.DTO;
using TestRestApiApp.Exceptions;
using Document = TestRestApiApp.Models.Document;

namespace TestRestApiApp.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly DataContext db;
        public DocumentService(DataContext context)
        {
            db = context;
        }

        public async Task<DocumentDto> CreateDraftDocument(DocumentModel model, CancellationToken cancellation)
        {
            if (model is null)
            {
                throw new ArgumentNullException("Document is null");
            }

            var document = new Document
            {
                Status = Enums.Statuses.Draft,
                Data = model.Data,
                CreatedDate = DateTime.Now
            };
            await db.Documents.AddAsync(document, cancellation).ConfigureAwait(false);
            await db.SaveChangesAsync(cancellation).ConfigureAwait(false);

            return new DocumentDto(document);
        }

        public async Task<IEnumerable<DocumentDto>> GetAll(GetPageDocumentModel model, CancellationToken cancellation)
        {
            return await db.Documents
                .AsNoTracking()
                .Skip((model.PageSize - 1) * model.PageNumber)
                .Take(model.PageSize)
                .Select(x => new DocumentDto(x))                   
                .ToListAsync(cancellation)
                .ConfigureAwait(false);
        }

        public async Task<DocumentDto> UpdateDocument(DocumentModel model, CancellationToken cancellation)
        {
            var document = await db.Documents.FirstOrDefaultAsync(x => x.Id == model.Id, cancellation).ConfigureAwait(false);

            if (document is null)
            {
                throw new DocumentNotFoundException();
            }
            if(document.Status!= Enums.Statuses.Draft)
            {
                throw new InvalidDocumentStatusException();
            }
            
            document.Data = model.Data;
            document.ModifiedDate = DateTime.Now;

            await db.SaveChangesAsync(cancellation);

            return new DocumentDto(document);
        }

        public async Task<DocumentDto> GetById(Guid id, CancellationToken cancellation)
        {
            var document = await db.Documents
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellation)
                .ConfigureAwait(false);

            if (document is null)
            {
                throw new DocumentNotFoundException();
            } 

            return new DocumentDto(document);
        }

        public async Task PublishDocument(Guid id, CancellationToken cancellation)
        {
            var document = await db.Documents
               .FirstOrDefaultAsync(x => x.Id == id, cancellation)
               .ConfigureAwait(false);

            if (document is null)
            {
                throw new DocumentNotFoundException();
            }

            document.Status = Enums.Statuses.Published;
            await db.SaveChangesAsync(cancellation);            

        }
    }
}
