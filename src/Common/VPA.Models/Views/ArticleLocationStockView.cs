namespace VPA.Models
{
    public class ReservationLocationStockView : EntityView
    {
        public string ReservationName { get; set; }
        public string LocationName { get; set; }
        public int Amount { get; set; }
    }
}
