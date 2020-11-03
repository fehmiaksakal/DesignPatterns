using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            //newleme maliyetlerini kısmak için kullanılır. 
            //önemli olan kısım nesne yeniden oluşur, referans tip olmasına rağmen Customer nesnesi bir kere türetilir sonrasında içinden istenildiği kadar customer  türetilebilir.

            Customer firstCust = new Customer { Id = 1, FirstName = "Fehmi", LastName = "Aksakal", City = "İstanbul" };

            Customer secondCustomer = (Customer)firstCust.Clone();
            secondCustomer.FirstName = "SecFehmi";

            Console.WriteLine("First Name for FirstCustomer:"+firstCust.FirstName+ "\nFirst Name for SecondCustomer:"+secondCustomer.FirstName+"");
        }



    }
    public abstract class Person
    {
        public abstract Person Clone();

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Customer : Person
    {
        public string City { get; set; }
        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
}
