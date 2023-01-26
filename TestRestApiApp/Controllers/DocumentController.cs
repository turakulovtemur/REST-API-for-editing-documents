using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Swashbuckle.AspNetCore.Annotations;
using TestRestApiApp.Dto;
using TestRestApiApp.DTO;
using TestRestApiApp.Exceptions;
using TestRestApiApp.Models;
using TestRestApiApp.Services;

namespace TestRestApiApp.Controllers
{
    [Route("api/document")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _service;
        public DocumentController(IDocumentService service)
        {
            _service = service;
        }

         
        [SwaggerOperation("Получить документ по id")]
        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentDto>> GetById( Guid id, CancellationToken token)
        {
            try
            {
                var document = await _service.GetById(id, token);
                return Ok(document);
            }
            catch (DocumentNotFoundException)
            {
                return NotFound();
            }
        }

         
        [SwaggerOperation("Создать черновик документа")]
        [HttpPost]
        public async Task<ActionResult<DocumentDto>> CreateDraftDocument([FromBody] DocumentRequestModel document, CancellationToken token)
        {
            var doc = await _service.CreateDraftDocument(new DocumentModel { Data = document.Data }, token);

            return Ok(doc);
        }


        [SwaggerOperation("Редактировать документ")]
        [HttpPatch("{id}")]
        public async Task<ActionResult<DocumentDto>> EditDocument(Guid id, [FromBody] EditDocumentRequestModel model, CancellationToken token)
        {
            try
            {
                var doc = await _service.UpdateDocument(new DocumentModel
                {
                    Data = model.Data,
                    Id = id
                }, token);
                return Ok(doc);
            }
            catch (DocumentNotFoundException)
            {
                return NotFound();
            }
            catch (InvalidDocumentStatusException)
            {
                return BadRequest();
            }
        }


        [SwaggerOperation("Опубликовать документ")]
        [HttpPost("{id}/publish")]
        public async Task<ActionResult<DocumentDto>> PublishDocument(Guid id, CancellationToken token)
        {
            try
            {
                await _service.PublishDocument(id, token);
                return Ok();
            }
            catch (DocumentNotFoundException)
            {
                return NotFound();
            }
        }
                         
        [SwaggerOperation("Получить список документов с пагинацией, сортировка в последние созданные сверху")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentDto>>> GetAll([FromQuery] int page, [FromQuery] int pageSize, CancellationToken token)
        {
            var result = await _service.GetAll(new GetPageDocumentModel { PageNumber = page, PageSize = pageSize }, token);
            return Ok(result);
        }

    }
}
