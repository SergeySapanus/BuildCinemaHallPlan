namespace WSVistaWebClientTest.Domain.Entities
{
    public class Ticket
    {
        public long TicketId { get; set; }

        public int AreaNumber { get; set; }

        public int ColumnIndex { get; set; }

        public int RowIndex { get; set; }

        public long OrderId { get; set; }

        public Order Order { get; set; }
    }
}