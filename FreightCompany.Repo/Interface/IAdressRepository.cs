using FreightCompany.Domain;
using System.Collections.Generic;


namespace FreightCompany.Interface
{
    public interface IAdressRepository
    {
        void CreateAdress(Adress adress);
        void CreateAdresses(List<Adress> adresses);
        void DeleteAdress(Adress adress);
        void DeleteAdressById(int adressId);
        void UpdateAdress(Adress adress);
        int DropAdressTable();
        Adress GetAdressById(int id);
        List<Adress> GetAdressesById(List<int> adressIds);
        List<Adress> GetAllAdresses();
        List<Adress> GetAdressesByZipCode(string zipcode);
    }
}

