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
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
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
            //var clientData = from entry in db.Clients where entry.ID == client.ID select entry;
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var animalData = from entry in db.Animals where entry.ID == iD select entry;
            return animalData;

            
        }

        public static void Adopt(object animal, Client client)
        {
            
        }

        public static object RetrieveClients()
        {
            throw new NotImplementedException();
        }

        public static object GetStates()
        {
            //Chris 



        }

        public static void AddNewClient(string firstName, string lastName, string username, string password, string email, string streetAddress, int zipCode, int state)
        {
            throw new NotImplementedException();
        }

        public static void UpdateClient(Client client)
        {
            throw new NotImplementedException();
        }

        public static void UpdateUsername(Client client)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var clientData = from entry in db.Clients where entry.userName == client.userName select entry;
            clientData.First().userName = client.userName;
            db.SubmitChanges();
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
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var animalShots = from entry in db.AnimalShotJunctions where entry.Animal_ID == animal.ID select entry;
            return animalShots;
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
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var removed = (from entry in db.Animals where entry.ID == animal.ID select entry).First();
            db.Animals.DeleteOnSubmit(removed);
            db.SubmitChanges();
        }

        public static int? GetBreed()
        {
            throw new NotImplementedException();
            //Chris is working on
        }

        public static int? GetLocation()
        {
            Room room = new Room();
            room.name = UserInterface.GetStringData("name", "room");
            room.building = UserInterface.GetStringData("name", "building");
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            db.Rooms.InsertOnSubmit(room);
            db.SubmitChanges();
            var animalLocation = (from entry in db.Rooms where entry.name == room.name && entry.building == room.building select entry.ID).First();
            return animalLocation;

        }

        public static int? GetDiet()
        {
            DietPlan diet = new DietPlan();
            diet.food = UserInterface.GetStringData("name", "food");
            diet.amount = UserInterface.GetIntegerData("name", "amount");
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var animalDiet = (from entry in db.DietPlans where entry.food == diet.food && entry.amount == diet.amount select entry.ID).First();
            return animalDiet;
        }

        public static void AddAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }

        public static Employee EmployeeLogin(string userName, string password)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();

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
