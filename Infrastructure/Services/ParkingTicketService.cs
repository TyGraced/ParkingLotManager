using Core.Dtos.Request;
using Core.Dtos.Response;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ParkingTicketService : IParkingTicketService
    {
        private readonly ApplicationDbContext _context;

        public ParkingTicketService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<PackingTickets>> CreateTicketAsync(CreatePackingTicket model)
        {
            var ticket = await _context.PackingTickets.SingleOrDefaultAsync(t => t.Name == model.Name);

            if (ticket != null)
            {
                return new ApiResponse<PackingTickets>
                {
                    Message = "This ticket already exists",
                    Status = false,
                    Data = null
                };
            }

            var newTicket = new PackingTickets
            {
                Name = model.Name,
                EntryTime = model.EntryTime,
                ExitTime = model.ExitTime,
                HoursSpent = model.HoursSpent,
                AmountToPay = model.AmountToPay,
                Date = model.Date
            };

            await _context.PackingTickets.AddAsync(newTicket);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return new ApiResponse<PackingTickets>
                {
                    Message = "Successful",
                    Status = true,
                    Data = newTicket
                };
            }
            return new ApiResponse<PackingTickets>
            {
                Message = "An error has occurred, try again",
                Status = false,
                Data = null
            };
        }

        public async Task<ApiResponse<IReadOnlyList<PackingTickets>>> GetAllTicketsAsync()
        {
            var tickets = await _context.PackingTickets.ToListAsync();

            if (tickets.Count == 0)
            {
                return new ApiResponse<IReadOnlyList<PackingTickets>>
                {
                    Message = "No tickets available",
                    Status = true,
                    Data = tickets
                };
            }

            return new ApiResponse<IReadOnlyList<PackingTickets>>
            {
                Message = "Successful",
                Status = true,
                Data = tickets
            };
        }

        public async Task<ApiResponse<PackingTickets>> GetTicketByDateAsync(string date)
        {
            var ticket = await _context.PackingTickets.SingleOrDefaultAsync(t => t.Date == date);

            if (ticket != null)
            {
                return new ApiResponse<PackingTickets>
                {
                    Message = "Successful",
                    Status = true,
                    Data = ticket
                };
            }
            return new ApiResponse<PackingTickets>
            {
                Message = "Ticket does not exist",
                Status = false,
                Data = null
            };
        }

        public async Task<ApiResponse<PackingTickets>> GetTicketByIdAsync(int id)
        {
            var ticket = await _context.PackingTickets.SingleOrDefaultAsync(t => t.Id == id);

            if (ticket != null)
            {
                return new ApiResponse<PackingTickets>
                {
                    Message = "Successful",
                    Status = true,
                    Data = ticket
                };
            }
            return new ApiResponse<PackingTickets>
            {
                Message = "Ticket does not exist",
                Status = false,
                Data = null
            };
        }

        public async Task<int> GetTicketPrice(string E, string L, PackingRulesResponse model)
        {
            var parkingRule = await _context.PackingRules.FirstOrDefaultAsync(p => p.Id == model.Id);

            var parkingRuleId = parkingRule.Id;
            var parkingRuleAmount = parkingRule.Amount;
            

            int x = Int32.Parse(E);
            int y = Int32.Parse(L);

            if ((y - x <= 1))
            {
                parkingRuleId = 2;
                parkingRuleAmount = 3;
                return 3 + 2;
            }

            else if ((y - x > 1))
            {
                parkingRuleId = 3;
                parkingRuleAmount = 4;
                return ((int)((y - 1)) * 4) + 3 + 2;
            }

            else
            {
                return 0;
            }
        }
    }
}
