namespace CoreAracKiralama.Areas.AdminPaneli.Models
{
    public class Statistics
    {
        public int BrandCount { get; set; }
        public int VehicleCount { get; set; }
        public int AvailableVehicleCount { get; set; }
        public int CompanyCount { get; set; }
        public string LatestBrand { get; set; }
        public string LatestVehicle { get; set; }
        public string LatestCompany { get; set; }
        public int NeedtoServices { get; set; }
        public string MinPriceVehicle { get; set; }
        public string MaxPriceVehicle { get; set; }
        public string AveragePriceVehicle { get; set; }
        public string TotalPriceVehicle { get; set; }
        public int AutoGearVehicle { get; set; }
        public int ManuelGearVehicle { get; set; }
        public int GasolineVehicle { get; set; }
        public int DieselVehicle { get; set; }
    }
}
