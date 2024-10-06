using System;
using System.Collections.Generic;

namespace ContactManager
{
    class Contact
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }

        public Contact(string nom, string prenom, string telephone, string email)
        {
            Nom = nom;
            Prenom = prenom;
            Telephone = telephone;
            Email = email;
        }
    }

    class ContactTools
    {
        public static List<Contact> contacts = new List<Contact>();

        public static void AfficherContacts()
        {
            foreach (Contact contact in contacts)
            {
                Console.WriteLine($"Nom : {contact.Nom}, Prénom : {contact.Prenom}, Téléphone : {contact.Telephone}, Email : {contact.Email}");
            }
        }

        public static void AjouterContact()
        {
            Console.WriteLine("Nom : ");
            string nom = Console.ReadLine();
            Console.WriteLine("Prénom : ");
            string prenom = Console.ReadLine();
            Console.WriteLine("Téléphone : ");
            string telephone = Console.ReadLine();
            Console.WriteLine("Email : ");
            string email = Console.ReadLine();
            Contact contact = new Contact(nom, prenom, telephone, email);
            contacts.Add(contact);
        }

        public static void ModifierContact()
        {
            Console.WriteLine("Nom du contact à modifier : ");
            string nom = Console.ReadLine();
            Contact contact = contacts.Find(c => c.Nom == nom);
            if (contact != null)
            {
                Console.WriteLine("Nouveau nom : ");
                contact.Nom = Console.ReadLine();
                Console.WriteLine("Nouveau prénom : ");
                contact.Prenom = Console.ReadLine();
                Console.WriteLine("Nouveau téléphone : ");
                contact.Telephone = Console.ReadLine();
                Console.WriteLine("Nouveau email : ");
                contact.Email = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Contact introuvable");
            }
        }

        public static void SupprimerContact()
        {
            Console.WriteLine("Nom du contact à supprimer : ");
            string nom = Console.ReadLine();
            Contact contact = contacts.Find(c => c.Nom == nom);
            if (contact != null)
            {
                contacts.Remove(contact);
            }
            else
            {
                Console.WriteLine("Contact introuvable");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool question = true;
            Console.WriteLine("1. Afficher les contacts");
            Console.WriteLine("2. Ajouter des contacts");
            Console.WriteLine("3. Modifier des contacts");
            Console.WriteLine("4. Supprimer des contacts");
            Console.WriteLine("5. Quitter");
            while (question)
            {
                try
                {
                    Console.WriteLine("Que voulez-vous faire ?");
                    int choix = int.Parse(Console.ReadLine());
                    switch (choix)
                    {
                        case 1:
                            Console.WriteLine("Afficher les contacts");
                            ContactTools.AfficherContacts();
                            break;
                        case 2:
                            Console.WriteLine("Ajouter des contacts");
                            ContactTools.AjouterContact();
                            break;
                        case 3:
                            Console.WriteLine("Modifier des contacts");
                            ContactTools.ModifierContact();
                            break;
                        case 4:
                            Console.WriteLine("Supprimer des contacts");
                            ContactTools.SupprimerContact();
                            break;
                        case 5:
                            Console.WriteLine("Quitter");
                            question = false;
                            break;
                        default:
                            Console.WriteLine("Choix invalide");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}