namespace EpiShipment.Models
{
    public class Shipment
    {
        public int ShipmentId { get; set; }
        public int CustomerId { get; set; }
        public DateTime ShipmentDate { get; set; }
        public decimal ShipmentWeight { get; set; }
        public string ShipmentDestinationCity { get; set; }
        public decimal ShipmentPrice { get; set; }
        public DateTime ShipmentDateExpected { get; set; }
        public string ShipmentNumber { get; set; }
    }
}
