using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    public static class Query
    {
        public static void RunEmployeeQueries(Employee employee, string v)
        {
            throw new NotImplementedException();
        }

        public static Client GetClient(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public static object GetUserAdoptionStatus(Client client)
        {
            throw new NotImplementedException();
        }

        public static object GetAnimalByID(int iD)
        {
            throw new NotImplementedException();
        }

        public static void Adopt(object animal, Client client)
        {
            throw new NotImplementedException();
        }

        public static object RetrieveClients()
        {
            throw new NotImplementedException();
        }

        public static object GetStates()
        {
            throw new NotImplementedException();
        }

        public static void AddNewClient(string firstName, string lastName, string username, string password, string email, string streetAddress, int zipCode, int state)
        {
            throw new NotImplementedException();
        }

        public static void updateClient(Client client)
        {
            throw new NotImplementedException();
        }

        public static void UpdateUsername(Client client)
        {
            throw new NotImplementedException();
        }

        public static void UpdateEmail(Client client)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var clientData = from entry in db.Clients where entry.ID == client.ID select entry;
            clientData.First().email = client.email;
            db.SubmitChanges();
        }

        public static void UpdateAddress(Client client)
        {
            throw new NotImplementedException();
        }

        public static void UpdateFirstName(Client client)
        {
            throw new NotImplementedException();
        }

        public static object GetPendingAdoptions()
        {
            throw new NotImplementedException();
        }

        public static void UpdateLastName(Client client)
        {
            throw new NotImplementedException();
        }

        public static void UpdateAdoption(bool v, ClientAnimalJunction clientAnimalJunction)
        {
            throw new NotImplementedException();
        }

        public static object GetShots(Animal animal)
        {
            throw new NotImplementedException();
        }

        public static void UpdateShot(string v, Animal animal)
        {
            throw new NotImplementedException();
        }

        public static void EnterUpdate(Animal animal, Dictionary<int, string> updates)
        {
            throw new NotImplementedException();
        }

        public static void RemoveAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }

        public static int? GetBreed()
        {
            throw new NotImplementedException();
        }

        public static int? GetLocation()
        {
            throw new NotImplementedException();
        }

        public static int? GetDiet()
        {
            throw new NotImplementedException();
        }

        public static void AddAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }

        public static Employee EmployeeLogin(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public static Employee RetrieveEmployeeUser(string email, int employeeNumber)
        {
            throw new NotImplementedException();
        }

        public static void AddUsernameAndPassword(Employee employee)
        {
            throw new NotImplementedException();
        }

        public static bool CheckEmployeeUserNameExist(string username)
        {
            throw new NotImplementedException();
        }
    }
}
