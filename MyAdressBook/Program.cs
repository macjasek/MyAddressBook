using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var contacts = new SortedDictionary<string, Contact>();

            //W celach testowych dwa kontakty
            contacts["jan"] = new Contact() { Name = "jan",
                FirstName = "Jan",
                LastName = "Kowalski",
                Emails = new List<string>() { "j.kowalski@wp.pl", "janekk@onet.pl" },
                Phones = new List<string>() { "888963125","+48659214326" }
            };

            contacts["piotr"] = new Contact()
            {
                Name = "piotr",
                FirstName = "Piotr",
                LastName = "Nowak",
                Emails = new List<string>() { "pnowak@nazwa.pl", "piotrek76@onet.pl" },
                Phones = new List<string>() { "88893453", "+48643534536" }
            };

            var a = 0;
            do
            {           
                Console.WriteLine("Operacje na kontaktach:");
                Console.WriteLine("1-Dodaj 2-Usuń 3-Edytuj 4-Wyświetl listę 5-Wyświetl szczegóły 6-Wyjście");
                Console.WriteLine();
                a = int.Parse(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        AddContact(contacts);
                        break;
                    case 2:
                        DeleteContact(contacts);
                        break;
                    case 3:
                        EditContact(contacts);  
                        break;
                    case 4:
                        ContactListShort(contacts);
                        break;
                    case 5:
                        ContactDetails(contacts);
                        break;
                    default:
                        break;
                }

            } while (a != 6);

        }

        static void ContactNamesList(SortedDictionary<string,Contact> dictionary)
        {
            Console.WriteLine("Lista nazw kontaktów");
            foreach (var item in dictionary)
            {
                Console.WriteLine(item.Key);
            }
        }

        static void ContactListShort(SortedDictionary<string, Contact> dictionary)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("|           Lista kontaktów           |");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("|   Nazwa   |   Imię   |   Nazwisko   |");
            Console.WriteLine("---------------------------------------");
            foreach (var item in dictionary)
            {
                
                Console.WriteLine($"|{item.Key,-11}|{dictionary[item.Key].FirstName,-10}|{dictionary[item.Key].LastName,-14}|");
            }
            Console.WriteLine("---------------------------------------");
            Console.WriteLine();
        }

        static void ContactDetails(SortedDictionary<string, Contact> contacts, string contactToShow)
        {
            var firstName = contacts[contactToShow].FirstName;
            var lastName = contacts[contactToShow].LastName;
            var emails = contacts[contactToShow].Emails;
            var phones = contacts[contactToShow].Phones;
            Console.Clear();
            Console.WriteLine("Szczegółowe dane kontaktu:");
            Console.WriteLine($"Nazwa: {contactToShow}");
            Console.WriteLine($"Imię: {firstName}");
            Console.WriteLine($"Nazwisko: {lastName}");
            Console.WriteLine("Adresy e-mail:");
            foreach (var item in emails)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Telefony");
            foreach (var item in phones)
            {
                Console.WriteLine(item);
            }
        }

        static void AddContact(SortedDictionary<string,Contact> contacts)
        {
            Console.Clear();
            Console.WriteLine("Podaj nazwę kontaktu");
            var contactName = Console.ReadLine();
            if (!contacts.ContainsKey(contactName))
            {
                Console.Clear();
                Console.WriteLine("Podaj imię kontaktu");
                var firstName = Console.ReadLine();

                Console.Clear();
                Console.WriteLine("Podaj nazwisko kontaktu");
                var lastName = Console.ReadLine();

                var emails = new List<string>();
                string email;

                Console.Clear();
                Console.WriteLine("Podaj email kontaktu");
                email = Console.ReadLine();
                while (email != "")
                {
                    emails.Add(email);
                    Console.Clear();
                    Console.WriteLine("Podaj kolejny email kontaktu lub Enter by przejść dalej");
                    email = Console.ReadLine();
                }

                string phone;
                var phones = new List<string>();

                Console.Clear();
                Console.WriteLine("Podaj telefon kontaktu");
                phone = Console.ReadLine();
                while (phone != "")
                {
                    phones.Add(phone);

                    Console.Clear();
                    Console.WriteLine("Podaj kolejny telefon nowego kontaktu lub Enter by przejść dalej");
                    phone = Console.ReadLine();
                }

                contacts[contactName] = new Contact()
                {
                    Name = contactName,
                    FirstName = firstName,
                    LastName = lastName,
                    Emails = emails,
                    Phones = phones
                };
                Console.Clear();
                Console.WriteLine("Dodano nowy kontakt");

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Kontakt o podanej nazwie już istnieje.");
            }
        }

        static void DeleteContact(SortedDictionary<string, Contact> contacts)
        {
            Console.WriteLine("Podaj nazwę kontaktu do usunięcia");
            ContactNamesList(contacts);
            var contactToDelete = Console.ReadLine();
            if (contacts.ContainsKey(contactToDelete))
            {
                contacts.Remove(contactToDelete);
                Console.WriteLine($"Kontakt {contactToDelete} usunięty");
            }
            else
            {
                Console.WriteLine("Brak kontaktu o podanej nazwie na liście");
            }
        }

        static void EditContact(SortedDictionary<string, Contact> contacts)
        {
            Console.WriteLine("Podaj nazwę kontaktu do edycji");
            ContactNamesList(contacts);
            var contactToEdit = Console.ReadLine();
            if (contacts.ContainsKey(contactToEdit))
            {

                var firstName = contacts[contactToEdit].FirstName;
                var lastName = contacts[contactToEdit].LastName;
                var emails = contacts[contactToEdit].Emails;
                var phones = contacts[contactToEdit].Phones;

                contacts.Remove(contactToEdit);

                Console.WriteLine("Aktualne dane kontaktu:");
                Console.WriteLine($"1 - Nazwa: {contactToEdit}");
                Console.WriteLine($"2 - Imię: {firstName}");
                Console.WriteLine($"3 - Nazwisko: {lastName}");
                Console.WriteLine("4 - adresy e-mail:");
                foreach (var item in emails)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("5 - Telefony");
                foreach (var item in phones)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("Wybierz numer pola do edycji lub Enter aby wyjść.");

                var b = int.Parse(Console.ReadLine());

                switch (b)
                {
                    case 1:
                        Console.WriteLine("Podaj nazwę kontaktu");
                        contactToEdit = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Podaj imię kontaktu");
                        firstName = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Podaj nazwisko kontaktu");
                        lastName = Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("Edycja email 1-dodanie 2-usunięcie 3-zmiana");
                        var c = int.Parse(Console.ReadLine());
                        switch (c)
                        {
                            case 1:
                                Console.WriteLine("Wpisz e-mail kontaktu.");
                                emails.Add(Console.ReadLine());
                                break;
                            case 2:
                                Console.WriteLine("Podaj numer adresu email do usunięcia");
                                var counter = 1;
                                foreach (var item in emails)
                                {
                                    Console.WriteLine($"{counter}- {item}");
                                    counter++;
                                }
                                var emailId = int.Parse(Console.ReadLine());
                                emails.RemoveAt(emailId - 1);
                                break;
                            case 3:
                                Console.WriteLine("Podaj numer adresu email do zmiany");
                                counter = 1;
                                foreach (var item in emails)
                                {
                                    Console.WriteLine($"{counter}- {item}");
                                    counter++;
                                }
                                emailId = int.Parse(Console.ReadLine());
                                emails.RemoveAt(emailId - 1);
                                Console.WriteLine("Wpisz e-mail kontaktu.");
                                emails.Add(Console.ReadLine());
                                break;
                            default:
                                break;
                        }
                        break;
                    case 5:
                        Console.WriteLine("Edycja telefonu 1-dodanie 2-usunięcie 3-zmiana");
                        c = int.Parse(Console.ReadLine());
                        switch (c)
                        {
                            case 1:
                                Console.WriteLine("Wpisz nr telefonu kontaktu.");
                                phones.Add(Console.ReadLine());
                                break;
                            case 2:
                                Console.WriteLine("Podaj id numeru telefonu do usunięcia");
                                var counter = 1;
                                foreach (var item in phones)
                                {
                                    Console.WriteLine($"{counter}- {item}");
                                    counter++;
                                }
                                var phoneId = int.Parse(Console.ReadLine());
                                emails.RemoveAt(phoneId - 1);
                                break;
                            case 3:
                                Console.WriteLine("Podaj id numeru telefonu do zmiany");
                                counter = 1;
                                foreach (var item in emails)
                                {
                                    Console.WriteLine($"{counter}- {item}");
                                    counter++;
                                }
                                phoneId = int.Parse(Console.ReadLine());
                                phones.RemoveAt(phoneId - 1);
                                Console.WriteLine("Wpisz nr telefonu kontaktu.");
                                emails.Add(Console.ReadLine());
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
                contacts[contactToEdit] = new Contact() { Name = contactToEdit, FirstName = firstName, LastName = lastName, Emails = emails, Phones = phones };

            }
            else
            {
                Console.WriteLine("Brak kontaktu o podanej nazwie na liście");
            }
        }
        
        static void ContactDetails(SortedDictionary<string,Contact> contacts)
        {
            Console.Clear();
            Console.WriteLine("Podaj nazwę kontaktu do wyświetlenia szczegółów");
            ContactNamesList(contacts);
            var nameToShow = Console.ReadLine();
            ContactDetails(contacts, nameToShow);
            Console.WriteLine();
        }
    }
}
