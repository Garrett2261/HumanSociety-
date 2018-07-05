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

        public static IQueryable<ClientAnimalJunction> GetUserAdoptionStatus(Client client)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var adoptionStatus = from entry in db.ClientAnimalJunctions where entry.client == client.ID select entry;
            return adoptionStatus;


        }

        public static object GetAnimalByID(int iD)
        {
            //var clientData = from entry in db.Clients where entry.ID == client.ID select entry;
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var animalData = from entry in db.Animals where entry.ID == iD select entry;
            return animalData;

            
        }

        public static void Adopt(Animal animal, Client client)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            ClientAnimalJunction clientAnimalJunction = new ClientAnimalJunction();
            clientAnimalJunction.animal = animal.ID;
            clientAnimalJunction.client = client.ID;
            clientAnimalJunction.approvalStatus = "pending";
            db.ClientAnimalJunctions.InsertOnSubmit(clientAnimalJunction);
            db.SubmitChanges();
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
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            Client client = new Client();
            client.firstName = firstName;
            client.lastName = lastName;
            client.userName = username;
            client.pass = password;
            client.email = email;
            client.UserAddress1.addessLine1 = streetAddress;
            client.UserAddress1.zipcode = zipCode;
            client.UserAddress1.USStates = state;
            db.Clients.InsertOnSubmit(client);
            db.SubmitChanges();
        }

        public static void UpdateClient(Client client)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var clientData1 = from entry in db.Clients where entry.pass == client.pass select entry;
            var clientData2 = from entry in db.Clients where entry.income == client.income select entry;
            var clientData3 = from entry in db.Clients where entry.kids == client.kids select entry;
            var clientData4 = from entry in db.Clients where entry.homeSize == client.homeSize select entry;
            clientData1.First().pass = client.pass;
            clientData2.First().income = client.income;
            clientData3.First().kids = client.kids;
            clientData4.First().homeSize = client.homeSize;
            db.SubmitChanges();
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
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var clientData = from entry in db.Clients where entry.ID == client.ID select entry;
            clientData.First().UserAddress1.addessLine1 = client.UserAddress1.addessLine1;
            clientData.First().UserAddress1.addressLine2 = client.UserAddress1.addressLine2;
            clientData.First().UserAddress1.zipcode = client.UserAddress1.zipcode;
            clientData.First().UserAddress1.USStates = client.UserAddress1.USStates;
            db.SubmitChanges();
        }

        public static void UpdateFirstName(Client client)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var clientData = from entry in db.Clients where entry.ID == client.ID select entry;
            clientData.First().firstName = client.firstName;
            db.SubmitChanges();
        }

        public static object GetPendingAdoptions()
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var pendingAdoptions = from entry in db.ClientAnimalJunctions where entry.approvalStatus == "pending" select entry;
            return pendingAdoptions;
        }

        public static void UpdateLastName(Client client)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var clientData = from entry in db.Clients where entry.ID == client.ID select entry;
            clientData.First().lastName = client.lastName;
            db.SubmitChanges();
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
            Breed breed = new Breed();
            breed.breed1 = UserInterface.GetStringData("name", "breed");
            breed.pattern = UserInterface.GetStringData("name", "pattern");
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var animalBreed = (from entry in db.Breeds where entry.breed1 == breed.breed1 && entry.pattern == breed.pattern select entry.ID).First();
            return animalBreed;
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
            
        }

        public static bool CheckEmployeeUserNameExist(string username)
        {
            throw new NotImplementedException();
        }
    }
}
