namespace WSVistaWebClientTest.Domain.Entities
{
    public class Plan
    {
        public int ResponseCode { get; set; }
        public SeatLayoutData SeatLayoutData { get; set; }
    }

    public class SeatLayoutData
    {
        //public AreaCategory[] AreaCategories { get; set; }
        public Area[] Areas { get; set; }
        //public float BoundaryLeft { get; set; }
        //public int BoundaryRight { get; set; }
        //public int BoundaryTop { get; set; }
        //public float ScreenStart { get; set; }
        //public int ScreenWidth { get; set; }
    }

    //public class AreaCategory
    //{
    //    public string AreaCategoryCode { get; set; }
    //    public bool IsInSeatDeliveryEnabled { get; set; }
    //    public int SeatsAllocatedCount { get; set; }
    //    public int SeatsNotAllocatedCount { get; set; }
    //    public int SeatsToAllocate { get; set; }
    //    public object[] SelectedSeats { get; set; }
    //}

    public class Area
    {
        public string AreaCategoryCode { get; set; }
        //public string Description { get; set; }
        //public string DescriptionAlt { get; set; }
        //public bool HasSofaSeatingEnabled { get; set; }
        //public bool IsAllocatedSeating { get; set; }
        //public int Number { get; set; }
        //public int NumberOfSeats { get; set; }
        public int ColumnCount { get; set; }
        public int RowCount { get; set; }
        public Row[] Rows { get; set; }

        public float Left { get; set; }
        public float Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

    }

    public class Row
    {
        public string PhysicalName { get; set; }
        public Seat[] Seats { get; set; }
    }

    public class Seat
    {
        public string Id { get; set; }
        public int OriginalStatus { get; set; }
        public Position Position { get; set; }
        public int Priority { get; set; }
        public int SeatStyle { get; set; }
        public object SeatsInGroup { get; set; }
        public int Status { get; set; }
    }

    public class Position
    {
        public int AreaNumber { get; set; }
        public int ColumnIndex { get; set; }
        public int RowIndex { get; set; }
    }
}