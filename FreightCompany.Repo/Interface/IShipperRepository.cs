using FreightCompany.Domain;
using System.Collections.Generic;

namespace FreightCompany.Repository.Interface
{
    public interface IShipperRepository
    {
        void CreateShipper(Shipper shipper);
        void CreateShippers(List<Shipper> shippers);
        void DeleteShipper(Shipper shipper);
        void DeleteShipperById(int Id);
        void UpdateShipper(Shipper shipper);
        int DropShipperTable();
        Shipper GetShipperById(int id);
        List<Shipper> GetAllShippers();

    }
}
