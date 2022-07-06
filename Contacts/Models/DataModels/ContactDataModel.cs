namespace Contacts
{
    public class ContactDataModel
    {
        #region Properties

        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        #endregion Properties

        #region Constructors

        public ContactDataModel()
        {
        }

        public ContactDataModel(string name, string phoneNumber, string email, string address)
        {
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Address = address;
        }

        #endregion Constructors

        #region Overridings

        public override string ToString() => $"Name: {this.Name}," +
            $"Phone number: {this.PhoneNumber}," +
            $"Email address: {this.Email}," +
            $"Address: {this.Address}";

        #endregion Overridings
    }
}