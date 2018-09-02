using System;
using System.Linq;

namespace WSVistaWebClientTest.Domain.Entities
{
    public class SimplePlan
    {
        private readonly Plan _plan;
        private Seat[,] _layout;

        public SimplePlan(Plan plan)
        {
            _plan = plan;
        }

        public Seat[,] GetSeatsLayout()
        {
            if (_layout != null)
                return _layout;

            var seatHeight = _plan.SeatLayoutData.Areas.Select(a => new { a.RowCount, a.Height }).Min(a => a.Height / a.RowCount);
            var seatWidth = _plan.SeatLayoutData.Areas.Select(a => new { a.ColumnCount, a.Width }).Min(a => a.Width / a.ColumnCount);

            _layout = new Seat[100 / seatWidth, 100 / seatHeight];

            foreach (var area in _plan.SeatLayoutData.Areas)
            {
                var y = (int)(area.Top / seatHeight) - 1;
                var height = area.RowCount + y - 1;

                foreach (var row in area.Rows)
                {
                    if (y > height)
                        break;

                    var x = (int)(area.Left / seatWidth) - 1;
                    var width = area.ColumnCount + x - 1;

                    for (var i = 0; i < area.ColumnCount; i++)
                    {
                        var seat = i < row.Seats.Length
                            ? row.Seats[i]
                            : new Seat();

                        if (x > width)
                            break;

                        if (_layout[x, y] == null)
                        {
                            _layout[x, y] = seat;
                        }
                        else
                        {
                            throw new Exception($"intersection of data ({nameof(GetSeatsLayout)})");
                        }

                        x++;
                    }

                    //foreach (var seat in row.Seats)
                    //{
                    //    if (x > width)
                    //        break;

                    //    if (_layout[x, y] == null)
                    //    {
                    //        _layout[x, y] = seat;
                    //    }
                    //    else
                    //    {
                    //        throw new Exception($"intersection of data ({nameof(GetSeatsLayout)})");
                    //    }

                    //    x++;
                    //}

                    y++;
                }
            }

            #region Cutting to boundary

            var left = (int)(_plan.SeatLayoutData.BoundaryLeft / seatWidth) - 2;
            var right = (int)(_plan.SeatLayoutData.BoundaryRight / seatWidth) + 2;
            var top = (int)(_plan.SeatLayoutData.BoundaryTop / seatHeight) - 2;
            var bottom = 100 / seatHeight;

            var temp = new Seat[right - left, bottom - top];

            for (var i = 0; i < 50; i++)
                for (var j = 0; j < 50; j++)
                    if (i >= left && i < right && j >= top && j < bottom)
                        temp[i - left, j - top] = _layout[i, j];

            //var count1 = _layout.OfType<Seat>().Count();
            //var count2 = temp.OfType<Seat>().Count();

            _layout = temp;

            #endregion

            return _layout;
        }
    }
}