using Core.Dtos;
using Core.Dtos.Request;
using Core.Dtos.Response;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ParkingLotManager.API.Controllers
{
    [ApiController]
    public class ParkingTicketController : ControllerBase
    {
        private readonly IParkingTicketService _repo;

        public ParkingTicketController(IParkingTicketService repo)
        {
            _repo = repo;
        }

        [HttpPost(ApiRoutes.ParkingTickets.Create)]
        public async Task<ActionResult<ApiResponse<PackingTicketResponse>>> CreateTicketAsync([FromBody] CreatePackingTicket model)
        {
            var ticket = await _repo.CreateTicketAsync(model);
            if (ticket.Status)
            {
                return Ok(ticket);
            }
            return BadRequest(ticket);
        }

        [HttpGet(ApiRoutes.ParkingTickets.GetAll)]
        public async Task<ActionResult<ApiResponse<PackingTicketResponse>>> GetAllTicketsAsync()
        {
            var tickets = await _repo.GetAllTicketsAsync();
            return Ok(tickets);
        }

        [HttpGet(ApiRoutes.ParkingTickets.GetByDate)]
        public async Task<ActionResult<ApiResponse<PackingTicketResponse>>> GetTicketByDateAsync([FromRoute] string date)
        {
            var ticket = await _repo.GetTicketByDateAsync(date);
            if (ticket.Status)
            {
                return Ok(ticket);
            }
            return BadRequest(ticket);
        }
        
        [HttpGet(ApiRoutes.ParkingTickets.GetById)]
        public async Task<ActionResult<ApiResponse<PackingTicketResponse>>> GetTicketByIdAsync([FromRoute] int id)
        {
            var ticket = await _repo.GetTicketByIdAsync(id);
            if (ticket.Status)
            {
                return Ok(ticket);
            }
            return BadRequest(ticket);
        }

        [HttpPost(ApiRoutes.ParkingTickets.GetTicket)]
        public async Task<ActionResult<int>> GetTicketPrice( string E, string L, PackingRulesResponse model)
        {
            var ticket = await _repo.GetTicketPrice(E, L, model);

            if (ticket >= 0)
            {
                return Ok(ticket);
            }

            return BadRequest(ticket);
        }

    }
}
