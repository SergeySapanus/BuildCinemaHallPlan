using System.Linq;
using WSVistaWebClientTest.Domain.Entities;

namespace WSVistaWebClientTest.WebUI.Models
{
    public class PlanIndexViewModel
    {
        public SimplePlan Plan { get; set; }
        public Order Order { get; set; }
        public Seat[,] Seats => Plan.GetSeatsLayout();

        public int SeatColumnsCount => Seats.GetUpperBound(0) + 1;
        public int SeatRowsCount => Seats.Length / SeatColumnsCount;

        public bool IsEmpty(int x, int y) => Seats[x, y] == null;

        public bool IsFree(int x, int y) => Seats[x, y].Status == 0;

        public bool IsGhost(int x, int y) => Seats[x, y].Position == null;

        public bool IsOrdered(int x, int y) => Order.Tickets.FirstOrDefault(t => t.Seat.CompositeId == GetSeatCompositeId(x, y)) != null;

        public int GetSeatCompositeId(int x, int y) => Seats[x, y].CompositeId;
    }
}