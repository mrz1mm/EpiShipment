using EpiShipment.Services;
using Microsoft.AspNetCore.Mvc;

namespace EpiShipment.Controllers
{
    public class ShipmentsController : Controller
    {
        private readonly ShipmentService _shipmentSvc;
        public ShipmentsController(ShipmentService shipmentSvc)
        {
            _shipmentSvc = shipmentSvc;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BackOffice()
        {
            return View();
        }
    }
}
