using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public static class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public static class ParkingTickets
        {
            public const string GetAll = Base + "/allparkingtickets";

            public const string GetById = Base + "/parkingtickets/get/{id}";

            public const string GetByDate = Base + "/parkingtickets/{date}";

            public const string Create = Base + "/parkingtickets";

            public const string GetTicket = Base + "/ticketprice";
        }

    }
}
