using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Data;
using UseCases.Infrastructure.Dtos.OfficeDto;
using UseCases.Offices.Commands;
using UseCases.Offices.Queries;

namespace Infrastructure.Presentation.Controllers
{
    [ApiController]
    [Route("api/offices")]
    public class OfficesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OfficesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = UserRoles.All)]
        [HttpGet]
        public async Task<IActionResult> GetOffices(CancellationToken cancellationToken)
        {
            var officesDto = await _mediator.Send(new GetOfficesQuery(), cancellationToken);
            return Ok(officesDto);
        }

        [Authorize(Roles = UserRoles.All)]
        [HttpGet("{officeId:guid}")]
        public async Task<IActionResult> GetOfficeById(Guid officeId, CancellationToken cancellationToken)
        {
            var officeDto = await _mediator.Send(new GetOfficeQuery(officeId), cancellationToken);
            return Ok(officeDto);
        }

        [Authorize(Roles = UserRoles.Receptionist)]
        [HttpPost]
        public async Task<IActionResult> CreateOffice([FromBody] OfficeForCreationDto officeForCreationDto, CancellationToken cancellationToken)
        {
            var officeDto = await _mediator.Send(new CreateOfficeCommand(officeForCreationDto), cancellationToken);
            return CreatedAtAction(nameof(GetOfficeById), new { officeId = officeDto.Id }, officeDto);
        }

        [Authorize(Roles = UserRoles.Receptionist)]
        [HttpPut("{officeId:guid}")]
        public async Task<IActionResult> UpdateOffice(Guid officeId, [FromBody] OfficeForUpdateDto officeForUpdateDto, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateOfficeCommand(officeId, officeForUpdateDto), cancellationToken);
            return NoContent();
        }

        [Authorize(Roles = UserRoles.Receptionist)]
        [HttpPatch("{officeId:guid}")]
        public async Task<IActionResult> ChangeOfficeStatus(Guid officeId, [FromBody] bool isActive, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateOfficeStatusCommand(officeId, isActive), cancellationToken);
            return NoContent();
        }

        [Authorize(Roles = UserRoles.Receptionist)]
        [HttpDelete("{officeId:guid}")]
        public async Task<IActionResult> DeleteOffice(Guid officeId, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteOfficeCommand(officeId), cancellationToken);
            return NoContent();
        }
    }
}
