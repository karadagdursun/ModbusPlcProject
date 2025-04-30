using ModbusPlcProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ModbusPlcProject.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}

        //public IndexModel(ModbusService modbus)
        //{
        //    _modbus = modbus;
        //}

        //public void OnGet()
        //{

        //}
        private readonly ModbusService _modbusService;

        public List<int> RegisterValues { get; set; } = new();

        public IndexModel(ModbusService modbusService)
        {
            _modbusService = modbusService;
        }

        public void OnGet()
        {
            // Örneðin: 0. adresten 10 register oku
            // bu plc su arýtma cihazý yönetiyor, burada tankýn ph derecesine göre 3 farklý pano var onlarý yönetmek istiyorlar
            //1 asit, 2 kostik, 3 su...
            RegisterValues = _modbusService.ReadHoldingRegisters(0, 10).ToList();
        }
    }
}
