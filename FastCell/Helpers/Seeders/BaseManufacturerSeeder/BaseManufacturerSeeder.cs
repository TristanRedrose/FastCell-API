using FastCell_BAL.Services.ManufacturerService;
using FastCell_DAL.Models.Entities;
using System.Xml.Linq;

namespace FastCell.Helpers.Seeders.BaseManufacturerSeeder
{
    public class BaseManufacturerSeeder : IBaseManufacturerSeeder
    {
        private readonly string[] manufacturers = ["Sony", "Huawei", "Lg", "Samsung", "Apple", "Xiaomi", "Motorola", "Nokia", "HTC"];
        private protected IManufacturerService _manufacturerService;

        public BaseManufacturerSeeder(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        public async Task SeedBaseManufacturers()
        {
            var currentManufacturers = await _manufacturerService.GetAllAsync();

            if (currentManufacturers.ToList().Count == 0) 
            { 
                foreach (var manufacturer in manufacturers)
                {
                    await _manufacturerService.AddAsync(new Manufacturer() { Name = manufacturer });
                }
            }
        }
    }
}
