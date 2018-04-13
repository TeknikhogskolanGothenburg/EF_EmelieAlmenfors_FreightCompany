using FreightCompany.Data;
using FreightCompany.Domain;
using FreightCompany.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FreightCompany.Repository
{
    public class ShipperRepository : IShipperRepository
    {
        public void CreateShipper(Shipper shipper)
        {
            var context = new DataBaseContext();
            context.Shippers.Add(shipper);
            context.SaveChanges();
        }

        public void CreateShippers(List<Shipper> shippers)
        {
            var context = new DataBaseContext();
            context.Shippers.AddRange(shippers);
            context.SaveChanges();
        }

        public void DeleteShipper(Shipper shipper)
        {
            var context = new DataBaseContext();
            context.Shippers.RemoveRange(shipper);
            context.SaveChanges();
        }

        public void UpdateShipper(Shipper shipper)
        {

            var context = new DataBaseContext();
            context.Shippers.Update(shipper);
            context.SaveChanges();
        }

        public List<Shipper> GetAllShippers()
        {
            var context = new DataBaseContext();
            return context.Shippers.ToList(); 
        }

        public Shipper GetShipperById(int id)
        {
            var context = new DataBaseContext();
            return context.Shippers.FirstOrDefault(s => s.Id == id);
        }

        public void DeleteShipperById(int Id)
        {
            var context = new DataBaseContext();
            var shipper = context.Customers.Where(s => s.Id == Id);
            context.RemoveRange(shipper);
            context.SaveChanges();
        }

        public int DropShipperTable()
        {
            var context = new DataBaseContext();
            using (var connection = context.Database.GetDbConnection())
            {
                 connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM SHIPPERS DBCC CHECKIDENT (Shippers, RESEED, 0)";
                    var result =  command.ExecuteNonQuery();
                }
            }
            return 0;
        }
    }
}
