using System;
using System.Collections.Generic;
using System.IO;

namespace ContactListProj1
{
    class Program
    {
        List<Contact> person = new List<Contact>();
        static void Main(string[] args)
        {
            Program p = new Program();
            p.loadFile();
            p.startMenu();

        }

        public class Contact
        {
            private string name;
            private string phonenumber;
            private string email;
            private string notes;

            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }

            public string Phonenumber
            {
                get
                {
                    return phonenumber;
                }
                set
                {
                    phonenumber = value;
                }
            }

            public string Email
            {
                get
                {
                    return email;
                }
                set
                {
                    email = value;
                }
            }

            public string Notes
            {
                get
                {
                    return notes;
                }
                set
                {
                    notes = value;
                }
            }

            public Contact(String name, String phoneNumber, String email, String notes) : base()
            {
                this.name = name;
                this.phonenumber = phoneNumber;
                this.email = email;
                this.notes = notes;
            }

            public String toString()
            {
                return name + ";" + phonenumber + ";" + email + ";" + notes;
            }

        }

        public void loadFile()
        {
            using (System.IO.StreamReader file = new System.IO.StreamReader(@"ContactPerson1.txt"))

            try
            {
                //StreamReader file = new StreamReader(@"ContactPerson1.txt");
                while (!file.EndOfStream)
                {   
                    string line = file.ReadLine();
                        string[] txt = line.Split(";");
                        
                        person.Add(new Contact(txt[0], txt[1], txt[2], txt[3]));

                   
                }
                file.Close();
            }

            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
            }

        }


        public void showContact()
        {
            Console.WriteLine("List of contacts: ");
            //loadFile();
            foreach (Contact p in person)
            {
                Console.WriteLine(p.Name + ";" + p.Phonenumber + ";" + p.Email + ";" + p.Notes);
            }
            startMenu();
        }

        public void saveContact()
        {
            using (StreamWriter writeFile = new StreamWriter(@"ContactPerson1.txt",false))
            {
                foreach (Contact p in person)
                {
                    writeFile.WriteLine(p.Name + ";" + p.Phonenumber + ";" + p.Email +";"+ p.Notes);
                }

            }
        }

        public void addContact()
        {
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter phone number:");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter email:");
            string email = Console.ReadLine();
            Console.WriteLine("Enter notes:");
            string notes = Console.ReadLine();
            Contact a = new Contact(name, phoneNumber, email, notes);
            person.Add(a);
            saveContact();
            Console.WriteLine("New contact added.");
            startMenu();
        }

        public void searchContact()
        {
            Console.WriteLine("Search for who?");
            string searchPerson = Console.ReadLine();
            foreach (Contact p in person)
            {
                if (searchPerson == p.Name)
                {
                    Console.WriteLine("Contact found.");
                    Console.WriteLine("---end---");
                    startMenu();
                }

            }
        }

        public void deleteContact()
        {
            Console.WriteLine("Delete who?");
            string deletePerson = Console.ReadLine();
            foreach (Contact p in person)
            {
                if (deletePerson == p.Name)
                {
                    person.Remove(p);
                    saveContact();
                    startMenu();
                }

            }
        }

        public void updateContact()
        {
            Console.WriteLine("What would you like to update ? Type 'name' / 'phonenumber' / 'email' / 'notes' to update");
            string updateService = Console.ReadLine();

            if (updateService == "name")
            {
                Console.WriteLine("Who's name?");
                string updatePersonN = Console.ReadLine();
                foreach (Contact p in person)
                {
                    if (updatePersonN == p.Name)
                    {
                        Console.WriteLine("Enter new name: ");
                        string newName = Console.ReadLine();
                        p.Name = newName;
                        saveContact();
                        Console.WriteLine("New name has been updated.");
                        startMenu();
                    }


                }
            }

            if (updateService == "phonenumber")
            {
                Console.WriteLine("Who's phone number?");
                string updatePhone = Console.ReadLine();
                foreach (Contact p in person)
                {
                    if (updatePhone == p.Name)
                    {
                        Console.WriteLine("Enter new phone number: ");
                        string newPhone = Console.ReadLine();
                        p.Phonenumber = newPhone;
                        saveContact();
                        Console.WriteLine("Phone number has been updated.");
                        startMenu();
                    }


                }
            }

            if (updateService == "email")
            {
                Console.WriteLine("Who's email?");
                string updateEmail = Console.ReadLine();
                foreach (Contact p in person)
                {
                    if (updateEmail == p.Name)
                    {
                        Console.WriteLine("Enter new email: ");
                        string newEmail = Console.ReadLine();
                        p.Email = newEmail;
                        saveContact();
                        Console.WriteLine("New email has been updated.");
                        startMenu();
                    }


                }
            }

            if (updateService == "notes")
            {
                Console.WriteLine("Who's notes?");
                string updateNotes = Console.ReadLine();
                foreach (Contact p in person)
                {
                    if (updateNotes == p.Name)
                    {
                        Console.WriteLine("Enter new notes: ");
                        string newNotes = Console.ReadLine();
                        p.Notes = newNotes;
                        saveContact();
                        Console.WriteLine("New notes has been updated.");
                        startMenu();
                    }

                }
            }

            else
            {
                Console.WriteLine("Please only type in the following commands: 'name'/'phonenumber'/'email'/'notes' to update");
                updateContact();
            }
        }

        public void startMenu()
        {
            
            Console.WriteLine("Hello!Welcome for using this contact list app!");
            Console.WriteLine("Type 'add' for adding a contact, 'show' for showing existing contact, 'search' for searching a contact in list, 'delete' to delete a contact,'updatecontact' to change an existing contact,'exit' to exit program. ");
            string command = Console.ReadLine();
            if (command == "add")
            {
                addContact();
            }

            if (command == "show")
            {
                showContact();
            }

            if (command == "search")
            {
                searchContact();
            }

            if (command == "delete")
            {
                deleteContact();
            }

            if (command == "updatecontact")
            {
                updateContact();
            }

            if (command == "exit")
            {
                Console.WriteLine("Bye");
                //System.Environment.Exit(0);
            }
        }
    }
}
