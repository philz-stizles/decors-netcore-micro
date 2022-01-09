/*using Decors.Application.Services.Photos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Decors.API.Controllers
{
    public class DocumentsController : BaseController
    {
        public DocumentsController(IMediator mediator) : base(mediator) { }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] UploadPhoto.Command command)
        {
            var result = await Mediator.Send(command);
            return Ok(new { Status = true, Data = result, Message = "Photo uploaded successful" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediator.Send(new DeletePhoto.Command { Id = id });
            return Ok(new { Status = true, Message = "Photo deleted successful" });
        }

        [HttpPost("{id}/SetMain")]
        public async Task<IActionResult> Patch(int id)
        {
            var result = await Mediator.Send(new SetMainPhoto.Command { Id = id });
            return Ok(new { Status = true, Data = result, Message = "Main Photo updated successful" });
        }
    }
}
*/