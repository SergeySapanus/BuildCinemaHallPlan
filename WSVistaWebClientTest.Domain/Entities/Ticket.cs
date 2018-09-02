using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSVistaWebClientTest.Domain.Entities
{
    public class Ticket
    {
        private Seat _seat;

        [Key]
        public long TicketId { get; set; }

        public int AreaNumber { get; set; }

        public int ColumnIndex { get; set; }

        public int RowIndex { get; set; }

        public long OrderId { get; set; }
        public Order Order { get; set; }

        [NotMapped]
        public Seat Seat
        {
            get => _seat;
            set
            {
                if (value != null)
                {
                    AreaNumber = value.Position.AreaNumber;
                    RowIndex = value.Position.RowIndex;
                    ColumnIndex = value.Position.ColumnIndex;
                }
                else
                {
                    AreaNumber = 0;
                    RowIndex = 0;
                    ColumnIndex = 0;
                }

                _seat = value;
            }
        }
    }
}