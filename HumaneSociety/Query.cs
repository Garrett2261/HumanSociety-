using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    public static class Query
    {
        private delegate void EmployeeActions(Employee employee);
        public static void RunEmployeeQueries(Employee employee, string v)
        {
            EmployeeActions create = EmployeeCreate;
            EmployeeActions read = EmployeeRead;
            EmployeeActions update = EmployeeUpdate;
            EmployeeActions delete = EmployeeDelete;
            switch (v)
            {
                case "create":
                    create(employee);
                    break;
                case "read":
                    read(employee);
                    break;
                case "update":
                    update(employee);
                    break;
                case "delete":
                    delete(employee);
                    break;
                default:
                    throw new Exception();
            }
        }
        public static void EmployeeCreate(Employee employee)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            Employee employeeNew = employee;
            db.Employees.InsertOnSubmit(employeeNew);
            db.SubmitChanges();
        }
        public static void EmployeeRead(Employee employee)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var read = db.Employees.Where(e => e.employeeNumber == employee.employeeNumber).First();
            Console.WriteLine(read.firsttName);
            Console.WriteLine(read.lastName);
            Console.WriteLine(read.userName);
            Console.WriteLine(read.employeeNumber);
            Console.WriteLine(read.email);
        }
        public static void EmployeeUpdate(Employee employee)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var updatedEmployee = db.Employees.Where(e => e.employeeNumber == employee.employeeNumber).First();
            updatedEmployee.firsttName = employee.firsttName;
            updatedEmployee.lastName = employee.lastName;
            updatedEmployee.employeeNumber = employee.employeeNumber;
            updatedEmployee.email = employee.email;
            db.SubmitChanges();
        }
        public static void EmployeeDelete(Employee employee)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var deletedEmployee = db.Employees.Where(c => c.employeeNumber == employee.employeeNumber).First();
            db.Employees.DeleteOnSubmit(deletedEmployee);
            db.SubmitChanges();
        }
        

        public static Client GetClient(string userName, string password)
        {
            //ask wade if instead of password it should be pass since that's what we are looking for
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            Client client = new Client();
            var newClient = (from entry in db.Clients where entry.userName == userName && entry.pass == password select entry).First();
            return newClient;
        }

        public static IQueryable<ClientAnimalJunction> GetUserAdoptionStatus(Client client)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var adoptionStatus = from entry in db.ClientAnimalJunctions where entry.client == client.ID select entry;
            return adoptionStatus;
//            var adoptionstatus = from entry in db.ClientAnimalJunctions where entry.approvalStatus == client select entry;
        }

        public static Animal GetAnimalByID(int iD)
        {
            //var clientData = from entry in db.Clients where entry.ID == client.ID select entry;
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var animalData = (from entry in db.Animals where entry.ID == iD select entry).First();
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

        public static IEnumerable<Client> RetrieveClients()
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var clientList = from entry in db.Clients select entry;
            return clientList;
        }

        public static IQueryable<USState> GetStates()
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var usStates = from item in db.USStates select item;
            return usStates;
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
            //client.userAddress set equal to fk on UserAddresses table
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

        public static IEnumerable<ClientAnimalJunction> GetPendingAdoptions()
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
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var adoptionUpdated = from entry in db.ClientAnimalJunctions where Convert.ToBoolean(entry.approvalStatus) == Convert.ToBoolean(clientAnimalJunction.approvalStatus) select entry;
            adoptionUpdated.First().approvalStatus = clientAnimalJunction.approvalStatus;
            db.SubmitChanges();
        }

        public static IEnumerable<AnimalShotJunction> GetShots(Animal animal)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var animalShots = from entry in db.AnimalShotJunctions where entry.Animal_ID == animal.ID select entry;
            return animalShots;
        }

        public static void UpdateShot(string v, Animal animal)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var shotupdated = (from entry in db.Shots where entry.name == v select entry).First();
            if (shotupdated == null)
            {
                shotupdated = db.Shots.Where(s => s.name == v).FirstOrDefault();
            }
        }

        public static void EnterUpdate(Animal animal, Dictionary<int, string> updates)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var animalUpdate = (from entry in db.Animals where entry.ID == animal.ID select entry).First();
            if (updates.ContainsKey(1))
            {
                animalUpdate.Breed1.Catagory1.catagory1 = updates[1];
            }
            if (updates.ContainsKey(2))
            {
                animalUpdate.Breed1.breed1 = updates[2];
            }
            if (updates.ContainsKey(3))
            {
                animalUpdate.name = updates[3];
            }
            if (updates.ContainsKey(4))
            {
                animalUpdate.age = Int32.Parse(updates[4]);
            }
            if (updates.ContainsKey(5))
            {
                animalUpdate.demeanor = updates[5];
            }
            if (updates.ContainsKey(6))
            {
                animalUpdate.kidFriendly = bool.Parse(updates[6]);
            }
            if (updates.ContainsKey(7))
            {
                animalUpdate.petFriendly = bool.Parse(updates[7]);
            }
            if (updates.ContainsKey(8))
            {
                animalUpdate.weight = Int32.Parse(updates[8]);
            }

           
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

            //HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            //var animalData = from entry in db.Animals where entry.breed == breed select entry;
            //return animalData;

        }

        // changed the following getlocation method from void to int.  Useremployee.AddAnimal was complaining about it.  victor
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
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            db.Animals.InsertOnSubmit(animal);
            db.SubmitChanges();
        }

        public static Employee EmployeeLogin(string userName, string password)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            Employee employee = new Employee();
            var login = (from entry in db.Employees where entry.userName == userName && entry.pass == password select entry).First();
            return login;
            

        }

        public static Employee RetrieveEmployeeUser(string email, int employeeNumber)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            Employee employee = new Employee();
            var employeeUser = (from entry in db.Employees where entry.email == email && entry.employeeNumber == employeeNumber select entry).First();
            return employeeUser;
        }

        public static void AddUsernameAndPassword(Employee employee)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var updateEmployee = (from entry in db.Employees where entry.email == employee.email select entry).First();
            updateEmployee.userName = employee.userName;
            updateEmployee.pass = employee.pass;
            db.Employees.InsertOnSubmit(updateEmployee);
            db.SubmitChanges();

        }

        public static bool CheckEmployeeUserNameExist(string username)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var checkUsername = from entry in db.Employees where entry.userName == username select entry;
            if (checkUsername == null)
            {
                return false;
            }
            else
            {
                return true;
            }
            
            
        }
    }
}
