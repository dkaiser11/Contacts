using MySql.Data.MySqlClient;
using System;
using System.Linq;

namespace Contacts
{
    public class ContactListModel
    {
        #region Public Properties

        public OrderedList<ContactDataModel> Contacts { get; private set; }

        #endregion Public Properties

        #region Public Methods

        public void AddContact(ContactDataModel contact)
        {
            Contacts.Add(contact);
            addContact(contact);
        }

        public void RemoveContact(string name)
        {
            Contacts.Remove(Contacts.ToList().Find(contact => contact.Name == name));

            removeContact(name);
        }

        #endregion Public Methods

        #region Fields

        private string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Contacts\Contacts.json";
        private string connectionString = @"datasource=localhost;port=3306;username=root;password=IhDKuba14Jg!";
        private MySqlConnection connection;

        #endregion Fields

        #region Private Methods

        private void initialize()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
            getContacts();
        }

        private void getContacts()
        {
            this.Contacts = new OrderedList<ContactDataModel>(contact => contact.Name);
            string query = @"SELECT name, phoneNumber, email, address FROM contacts.contacts";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Contacts.Add(new ContactDataModel(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
                }
            }
        }

        private void addContact(ContactDataModel contact)
        {
            string query = @$"INSERT INTO contacts.contacts (name, phoneNumber, email, address) VALUES ('{contact.Name}', '{contact.PhoneNumber}', '{contact.Email}', '{contact.Address}')";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            getContacts();
        }

        private void removeContact(string name)
        {
            string query = @$"DELETE FROM contacts.contacts WHERE name='{name}'";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            getContacts();
        }

        #endregion Private Methods

        #region Constructor

        public ContactListModel()
        {
            initialize();
        }

        #endregion Constructor
    }
}