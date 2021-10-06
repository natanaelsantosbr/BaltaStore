namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Customer
    {
        //Solid

        /*
        S. Principio da responsabilidade unica (Organização)
        O. Esta aberto para extensão (sem sealed), mas esta fechado para modificação (private set)
        LID        
        */

        public Customer(string firstName, string lastName, string document, string email, string phone, string address)
        {
            this.FistName = firstName;
            this.LastName = lastName;
            this.Document = document;
            this.Email = email;
            this.Phone = phone;
            this.Address = address;
        }
        public string FistName { get; private set; }

        public string LastName { get; private set; }

        public string Document { get; private set; }

        public string Email { get; private set; }

        public string Phone { get; private set; }

        public string Address { get; private set; }

    }
}