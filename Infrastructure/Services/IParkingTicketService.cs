using Core.Dtos.Request;
using Core.Dtos.Response;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IParkingTicketService
    {
        Task<ApiResponse<PackingTickets>> CreateTicketAsync(CreatePackingTicket model);
        Task<ApiResponse<PackingTickets>> GetTicketByIdAsync(int id);
        Task<ApiResponse<PackingTickets>> GetTicketByDateAsync(string date);
        Task<ApiResponse<IReadOnlyList<PackingTickets>>> GetAllTicketsAsync();
        Task<int> GetTicketPrice(string E, string L, PackingRulesResponse model);
    }
}
