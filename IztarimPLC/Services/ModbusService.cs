namespace ModbusPlcProject.Services
{
    // Services/ModbusService.cs
    using EasyModbus;
    using ModbusPlcProject.Models;
    using Microsoft.Extensions.Options;

    public class ModbusService
    {
        private readonly ModbusClient _client;

        public ModbusService(IOptions<ModbusConfig> config)
        {
            var settings = config.Value;
            _client = new ModbusClient(settings.IpAddress, settings.Port);
        }

        public int[] ReadHoldingRegisters(int start, int count)
        {
            try
            {
                _client.Connect();
                var values = _client.ReadHoldingRegisters(start, count);
                _client.Disconnect();
                return values;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Modbus Hatası: {ex.Message}");
                return Array.Empty<int>();
            }
        }
    }

}
