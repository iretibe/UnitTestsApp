namespace UnitTestsApp
{
    public interface ICustomer
    {
        int Discount { get; set; }
        int OrderTotal { get; set; }
        string GreetMessage { get; set; }
        bool IsPlatinum { get; set; }
        string GreetAndCombineNames(string firstName, string lastName);
        CustomerType GetCustomerDetails();
    }

    public class Customer : ICustomer
    {
        //public int Discount = 15;
        public int Discount { get; set; }
        public string greetMessage { get; set; }        
        public int OrderTotal { get; set; }
        public bool IsPlatinum { get; set; }
        int ICustomer.Discount { get; set; }
        public string GreetMessage { get; set; }

        public Customer()
        {
            Discount = 15;
            IsPlatinum = false;
        }

        public string GreetAndCombineNames(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentNullException("Empty First Name");
            }

            greetMessage = $"Hello, {firstName} {lastName}";

            Discount = 20;

            return greetMessage;
        }

        public CustomerType GetCustomerDetails()
        {
            if (OrderTotal < 100)
            {
                return new BasicCustomer();
            }

            return new PlatinumCustomer();
        }
    }

    public class CustomerType { }

    public class BasicCustomer : CustomerType { }
    public class PlatinumCustomer : CustomerType { }
}
