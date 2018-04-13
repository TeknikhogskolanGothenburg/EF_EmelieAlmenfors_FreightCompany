using FreightCompany.Data;
using FreightCompany.Domain;
using FreightCompany.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FreightCompany.Repository
{
    public class AdressRepository : IAdressRepository
    {
        public void CreateAdress(Adress adress)
        {
            var context = new DataBaseContext();
            context.Adresses.Add(adress);
            context.SaveChanges();
        }

        public void CreateAdresses(List<Adress> adresses)
        {
            var context = new DataBaseContext();
            context.Adresses.AddRange(adresses);
            context.SaveChanges();
        }

        public Adress GetAdressById(int id)
        {
            var context = new DataBaseContext();
            return context.Adresses.FirstOrDefault(a => a.Id == id);
            
        }

        public List<Adress> GetAdressesByZipCode(string zipcode)
        {
            var context = new DataBaseContext();
            return context.Adresses.Where(a => a.ZipCode.StartsWith(zipcode)).ToList();
            
        }

        public List<Adress> GetAllAdresses()
        {
            var context = new DataBaseContext();
            return context.Adresses.ToList();
            
        }

        public void UpdateAdress(Adress adress)
        {
            var context = new DataBaseContext();
            context.Adresses.Update(adress);
            context.SaveChanges();
        }

        public void DeleteAdress(Adress adress)
        {
            var context = new DataBaseContext();
            context.Adresses.RemoveRange(adress);
            context.SaveChanges();
        }

        public List<Adress> GetAdressesById(List<int> adressIds)
        {
            var context = new DataBaseContext();
            return context.Adresses.Where(a => adressIds.Contains(a.Id)).ToList();
        }

        public void DeleteAdressById(int adressId)
        {
            var context = new DataBaseContext();
            var adress = context.Adresses.Where(a => a.Id == adressId);
            context.Adresses.RemoveRange(adress);
            context.SaveChanges();
        }

        public int DropAdressTable()
        {
            var context = new DataBaseContext();
            using (var connection = context.Database.GetDbConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM ADRESSES DBCC CHECKIDENT (Adresses, RESEED, 0)";
                    var result = command.ExecuteNonQuery();
                }
            }
            return 0;
        }

    }
}
