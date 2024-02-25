using Projet02P2_Pierre_Pourre;
using System;
using System.Data.Common;

namespace Projet02P2_Nom_complet
{
    class Program
    {
        //fonctions d'insertions
        //les fonctions d'insertion demandent à l'utilisateur les informations
        //nécessaires pour l'ajout d'un enregistrement à une ou plusieurs tables
        //elle vérifie la nature des données et appelle la méthode d'insertion à la BD
        public static void InsererCategorie() 
        {
            Console.WriteLine(" Veuillez remplir les données de la catégorie.");
            Console.WriteLine(" Nom du Produit :");
            string CategoryName = Console.ReadLine();

            DOAwocloo.QueryDML_DDL("insert into Categorie (CategoryName) values('" + CategoryName + "')");
        }
        public static void InsererProduit() {
            int InStock = 0;

            Console.WriteLine(" Veuillez remplir les données du Produit.");
            
            Console.WriteLine(" Nom du Produit :");
            string Name = Console.ReadLine();
            Console.WriteLine(" Description :");
            string Description = Console.ReadLine();
            Console.WriteLine(" Prix unitaire :");
            string UnitPrice = Console.ReadLine();
            Console.WriteLine(" ID catégorie :");
            string Categoryld = Console.ReadLine();

            while (InStock != 1 || InStock != 0) 
            {
                Console.WriteLine(" En stock O/N ? :");
                string answer = Console.ReadLine();
                if (answer == "N" || answer == "n" || answer == "non")
                {
                    InStock = 0;
                    break;
                }
                else if (answer == "O" || answer == "o" || answer == "oui")
                {
                    InStock = 1;
                    break;
                }
                else
                {
                    Console.WriteLine(" Erreur, veuillez recommencer! ");
                }
            } 

            Console.WriteLine(" Couts :");
            string Cost = Console.ReadLine();

            DOAwocloo.QueryDML_DDL("insert into Products (Nam_e, Des_cription, UnitPrice, Categoryld, InStock, Cost) values( '" + Name + "', '" + Description + "', '" + UnitPrice + "', '" + Categoryld + "', '" + InStock + "', '" + Cost + "')");
        }
        public static void InsererConsomateur() 
        {
            Console.WriteLine(" Veuillez remplir les données sur le Consommateur.");

            Console.WriteLine(" Nom :");
            string FirstName = Console.ReadLine();
            Console.WriteLine(" Prénom :");
            string LastName = Console.ReadLine();
            Console.WriteLine(" Adresse :");
            string Address = Console.ReadLine();
            Console.WriteLine(" Code postal :");
            string PostalCode = Console.ReadLine();
            Console.WriteLine(" Province :");
            string Province = Console.ReadLine();
            Console.WriteLine(" Numéro de téléphone Maison :");
            string HomePhone = Console.ReadLine(); 
            Console.WriteLine(" Date de naissance au format yyyy-MM-dd :");
            string BirthDate = Console.ReadLine();
            Console.WriteLine(" Date de décés au format yyyy-MM-dd :");
            string DeathDate = Console.ReadLine();

            DOAwocloo.QueryDML_DDL("insert into Customers (FirstName, LastName, Address, PostalCode, Province, HomePhone, BirthDate, DeathDate) values( '" + FirstName + "', '" + LastName + "', '" + Address + "', '" + PostalCode + "', '" + Province + "', '" + HomePhone + "', '" + BirthDate + "', '" + DeathDate + "')");
        }
        public static void InsererFacture() 
        {
            Console.WriteLine(" Veuillez remplir les données sur la Facture.");

            Console.WriteLine(" ID facture :");
            string Invoiceld = Console.ReadLine();
            Console.WriteLine(" Code du Consommateur :");
            string CustomerCode = Console.ReadLine();
            Console.WriteLine(" Date de la facture (yyyy-MM-dd) :");
            string InvoiceDate = Console.ReadLine();
            DOAwocloo.QueryDML_DDL("insert into Invoices (Invoiceld, CustomerCode, InvoiceDate) values('" + Invoiceld + "','" + CustomerCode + "', '" + InvoiceDate + "')");

            Console.WriteLine(" Veuillez remplir les détails de la Invoices.");


            Console.WriteLine(" ID facture :");
            string Invoicel = Console.ReadLine();
            Console.WriteLine(" ID du produit :");
            string Productid = Console.ReadLine();
            Console.WriteLine(" Quantité :");
            string Quantity = Console.ReadLine();
            Console.WriteLine(" Prix à l'unité :");
            string UnitPrice = Console.ReadLine();
            Console.WriteLine(" Réduction :");
            string Discount = Console.ReadLine();
            DOAwocloo.QueryDML_DDL("insert into InvoiceDetails (Invoiceld, Productid, Quantity, UnitPrice, Discount) values('" + Invoicel + "', '" + Productid + "', '" + Quantity + "', '" + UnitPrice + "', '" + Discount + "')");

        }

        //fonctions de recherche
        //les fonctions de recherche récupérent les données d'un élément
        //choisi par l'utilisateur qui l'identifie par son id
        //si l'élément n'existe pas on affiche un message d'erreur
        public static void RechercherCategorie() 
        {
            Console.WriteLine("Entrez l'ID de la catégorie recherché : ");
            string ID = Console.ReadLine();
            DbDataReader reader = DOAwocloo.QuerySELECT($"SELECT * FROM Categorie WHERE Categoryld = {ID};");

            using (reader)
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //pour la colonne idProduit
                        int CategoryIndex = reader.GetInt16(0);
                        string libelle = reader.GetString(1);


                        Console.WriteLine("Categoryld : " + CategoryIndex);
                        Console.WriteLine("Nom : " + libelle);

                    }
                }


            }
        }
        public static void RechercherProduit() 
        {
            Console.WriteLine("Entrez l'id du produit recherché : ");
            string ID = Console.ReadLine();
            DbDataReader reader = DOAwocloo.QuerySELECT($"SELECT * FROM Products WHERE Productid = {ID};");

            using (reader)
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string stock;
                        //pour la table Productid
                        int ProductIndex = reader.GetInt16(0);
                        string Name = reader.GetString(1);
                        string Description = reader.GetString(2);
                        double PrixUnit = reader.GetDouble(3);
                        int CategoryIndex = reader.GetInt16(4);
                        bool EnStock = reader.GetBoolean(5);
                        if (EnStock == false) { stock = "Plus en stock"; } else { stock = "En stock"; }
                        double Cout = reader.GetDouble(6);


                        Console.WriteLine("Productld : " + ProductIndex);
                        Console.WriteLine("Nom : " + Name);
                        Console.WriteLine("Description : " + Description);
                        Console.WriteLine("Prix Unitaire : " + PrixUnit);
                        Console.WriteLine("Categoryld : " + CategoryIndex);
                        Console.WriteLine("Stock : " + stock);
                        Console.WriteLine("Cout : " + Cout);

                    }
                }


            }
        }
        public static void RechercherConsomateur() 
        {
            Console.WriteLine("Entrez le code du Consommateur recherché : ");
            string ID = Console.ReadLine();
            DbDataReader reader = DOAwocloo.QuerySELECT($"SELECT * FROM Customers WHERE CustomerCode = {ID};");

            using (reader)
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string DeathDate_string;
                        //pour la table Productid
                        int CustomerCode = reader.GetInt16(0);
                        string FirstName = reader.GetString(1);
                        string LastName = reader.GetString(2);
                        string Address = reader.GetString(3);
                        string PostalCode = reader.GetString(4);
                        string Province = reader.GetString(5);
                        double HomePhone = reader.GetDouble(6);
                        DateTime BirthDate = reader.GetDateTime(7);
                        string BirthDate_string = BirthDate.ToString("yyyy-MM-dd");
                        if (reader.IsDBNull(8))
                        {
                            DeathDate_string = "Sans Objet";
                        }
                        else 
                        {   DateTime DeathDate = reader.GetDateTime(8);
                            DeathDate_string = DeathDate.ToString("yyyy-MM-dd");
                        }
                        Console.WriteLine("ID Consommateur : " + CustomerCode);
                        Console.WriteLine("Nom : " + FirstName);
                        Console.WriteLine("Prénom : " + LastName);
                        Console.WriteLine("Adresse : " + Address);
                        Console.WriteLine("Code Postal : " + PostalCode);
                        Console.WriteLine("Province : " + Province);
                        Console.WriteLine("Téléphone Maison : " + HomePhone);
                        Console.WriteLine("Date de naissance : " + BirthDate_string);
                        Console.WriteLine("Date de décés : " + DeathDate_string);

                    }
                }


            }
        }
        public static void RechercherFacture() 
        {
            Console.WriteLine("Entrez l'id de la facture recherchée : ");
            string ID = Console.ReadLine();
            DbDataReader reader = DOAwocloo.QuerySELECT($"SELECT * FROM InvoiceDetails WHERE Invoiceld = {ID};");

            using (reader)
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        //pour la table InvoiceDetails
                        int Invoiceld = reader.GetInt16(0);
                        int Productid = reader.GetInt16(1);
                        int Quantity = reader.GetInt16(2);
                        double PrixUnit = reader.GetDouble(3);
                        int Discount = reader.GetInt16(4);

                        Console.WriteLine("Facture ID : " + Invoiceld);
                        Console.WriteLine("Produit ID : " + Productid);
                        Console.WriteLine("Quantité : " + Quantity);
                        Console.WriteLine("Prix Unitaire : " + PrixUnit);
                        Console.WriteLine("Réduction : " + Discount);
                        

                    }
                }
            }

            DbDataReader lecteur = DOAwocloo.QuerySELECT($"SELECT * FROM Invoices WHERE Invoiceld = {ID};");
            
            using (reader)
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        //pour la table Invoice
                        int Invoiceld = reader.GetInt16(0);
                        int CustomerCode = reader.GetInt16(1);
                        DateTime InvoiceDate = reader.GetDateTime(2);
                        string InvoiceDate_string = InvoiceDate.ToString("yyyy-MM-dd");

                        Console.WriteLine("Facture ID : " + Invoiceld);
                        Console.WriteLine("Code de Consomateur : " + CustomerCode);
                        Console.WriteLine("Date de Facture : " + InvoiceDate);
                        


                    }
                }
            }
        }

        //fonctions de modification
        //les fonctions de modification modifient les données d'un enregistrement 
        //identifié par son id
        //si l'élément n'existe pas on affiche un message d'erreur
        public static void ModifierCategorie() 
        {
            Console.WriteLine("Entrer l'ID de la catégorie que vous voulez changer : ");
            string ID = Console.ReadLine();
            Console.WriteLine("Changer le nom de la catégorie : ");
            string NomCat = Console.ReadLine();
            DOAwocloo.QueryDML_DDL($"UPDATE Categorie SET CategoryName = '{NomCat}' WHERE Categoryld = {ID};"); 
        
        }
        public static void ModifierProduit() 
        {
            Console.WriteLine("Entrer l'ID du produit que vous voulez changer : ");
            string ID = Console.ReadLine();
            Console.WriteLine("Changer le nom du produit : ");
            string NomProd = Console.ReadLine();
            DOAwocloo.QueryDML_DDL($"UPDATE Products SET Nam_e = '{NomProd}' WHERE Productid = {ID};");
        }
        public static void ModifierConsomateur() 
        {
            Console.WriteLine("Entrer le code de la personne que vous voulez changer : ");
            string code = Console.ReadLine();
            Console.WriteLine("Changer le nom de la personne : ");
            string NomNouv = Console.ReadLine();
            Console.WriteLine("Changer le prénom de la personne : ");
            string PrenomNouv = Console.ReadLine();
            DOAwocloo.QueryDML_DDL($"UPDATE Customers SET FirstName = '{NomNouv}', LastName = '{PrenomNouv}' WHERE CustomerCode = {code};");
        }
        public static void ModifierFacture() 
        {
            Console.WriteLine("Entrer l'ID de la facture que vous voulez changer : ");
            string ID = Console.ReadLine();
            Console.WriteLine("Changer la date de la facture (yyyy-MM-dd) : ");
            string nouvDate = Console.ReadLine();
            DOAwocloo.QueryDML_DDL($"UPDATE Invoices SET InvoiceDate = '{nouvDate}' WHERE Invoiceld = {ID};");

            Console.WriteLine("Entrer la nouvelle cantité : ");
            string Quant = Console.ReadLine();
            DOAwocloo.QueryDML_DDL($"UPDATE InvoiceDetails SET Quantity = '{Quant}' WHERE Invoiceld = {ID};");
        }

        //fonctions de suppression
        //les fonctions de suppression suppriment un enregistrement identifié 
        //par son id d'une ou plusieurs tables
        public static void SupprimerCategorie() 
        {
            Console.WriteLine("Entrer l'ID de la catégorie que vous voulez supprimer : ");
            string ID = Console.ReadLine();
            DOAwocloo.QueryDML_DDL($"ALTER TABLE Products DROP CONSTRAINT products_ibfk_1;");
            DOAwocloo.QueryDML_DDL($"UPDATE Products SET Categoryld = '0' WHERE Categoryld = {ID};");
            DOAwocloo.QueryDML_DDL($"DELETE FROM Categorie WHERE Categoryld = {ID};");

        }
        public static void SupprimerProduit() 
        {
            Console.WriteLine("Entrer l'ID du Produit que vous voulez supprimer : ");
            string ID = Console.ReadLine();
            DOAwocloo.QueryDML_DDL($"ALTER TABLE InvoiceDetails DROP CONSTRAINT InvoiceDetails_ibfk_1;");
            DOAwocloo.QueryDML_DDL($"UPDATE InvoiceDetails SET Productid = '0' WHERE Productid = {ID};");
            DOAwocloo.QueryDML_DDL($"DELETE FROM Products WHERE Productid = {ID};");
        }
        public static void SupprimerConsomateur() 
        {
            Console.WriteLine("Entrer le code du consomateur que vous voulez supprimer : ");
            string ID = Console.ReadLine();
            DOAwocloo.QueryDML_DDL($"ALTER TABLE Invoices DROP CONSTRAINT Invoices_ibfk_1;");
            DOAwocloo.QueryDML_DDL($"UPDATE Invoices SET CustomerCode = '0' WHERE CustomerCode = {ID};");
            DOAwocloo.QueryDML_DDL($"DELETE FROM Customers WHERE CustomerCode = {ID};");
        }
        public static void SupprimerFacture() 
        {
            Console.WriteLine("Entrer l'ID de la facture que vous voulez supprimer : ");
            string ID = Console.ReadLine();
            DOAwocloo.QueryDML_DDL($"ALTER TABLE InvoiceDetails DROP CONSTRAINT invoicedetails_ibfk_2;");
            DOAwocloo.QueryDML_DDL($"UPDATE InvoiceDetails SET Invoiceld = '0' WHERE Invoiceld = {ID};");
            DOAwocloo.QueryDML_DDL($"DELETE FROM Invoices WHERE Invoiceld = {ID};");
        }

        static void Main(string[] args)
        {
            DOAwocloo.connect();
            int choix = 0;
            
                Console.WriteLine("Wooclo - Base de données");
                Console.WriteLine("1 - Insertion");
                Console.WriteLine("2 - Recherche");
                Console.WriteLine("3 - Modification");
                Console.WriteLine("4 - Suppression");
                
             do
            {   
                Console.Write("Tapez votre choix : ");
                int.TryParse(Console.ReadLine(),out choix);
            } while (choix < 1 || choix > 4);
            switch (choix)
            {
                case 1:
                    
                        Console.WriteLine("1- Insertion des données:");
                        Console.WriteLine(" 1 - Catégorie");
                        Console.WriteLine(" 2 - Produit");
                        Console.WriteLine(" 3 - Consomateur");
                        Console.WriteLine(" 4 - Facture");
                    do {
                        Console.Write("Tapez votre choix : ");
                        int.TryParse(Console.ReadLine(), out choix);
                    } while (choix < 1 || choix > 4);

                    switch (choix)
                    {
                        case 1:
                            InsererCategorie();
                            break;
                        case 2:
                            InsererProduit();
                            break;
                        case 3:
                            InsererConsomateur();
                            break;
                        case 4:
                            InsererFacture();
                            break;
                    }

                    
                    break;
                case 2:
                    
                        Console.WriteLine("2- Recherche des données:");
                        Console.WriteLine(" 1 - Catégorie");
                        Console.WriteLine(" 2 - Produit");
                        Console.WriteLine(" 3 - Consomateur");
                        Console.WriteLine(" 4 - Facture");
                    do
                    {
                        Console.Write("Tapez votre choix : ");
                        int.TryParse(Console.ReadLine(), out choix);
                    } while (choix < 1 || choix > 4);
                    switch (choix)
                    {
                        case 1:
                            RechercherCategorie();
                            break;
                        case 2:
                            RechercherProduit();
                            break;
                        case 3:
                            RechercherConsomateur();
                            break;
                        case 4:
                            RechercherFacture();
                            break;
                    }
                    break;
                case 3:

                    
                        Console.WriteLine("3- Modification des données:");
                        Console.WriteLine(" 1 - Catégorie");
                        Console.WriteLine(" 2 - Produit");
                        Console.WriteLine(" 3 - Consomateur");
                        Console.WriteLine(" 4 - Facture");
                     do
                    {
                        Console.Write("Tapez votre choix : ");
                        int.TryParse(Console.ReadLine(), out choix);
                    } while (choix < 1 || choix > 4);
                    switch (choix)
                    {
                        case 1:
                            ModifierCategorie();
                            break;
                        case 2:
                            ModifierProduit();
                            break;
                        case 3:
                            ModifierConsomateur();
                            break;
                        case 4:
                            ModifierFacture();
                            break;
                    }
                    break;
                case 4:
                    
                        Console.WriteLine("4- Suppression des données");
                        Console.WriteLine(" 1 - Catégorie");
                        Console.WriteLine(" 2 - Produit");
                        Console.WriteLine(" 3 - Consomateur");
                        Console.WriteLine(" 4 - Facture");
                    do
                    {
                        Console.Write("Tapez votre choix : ");
                        int.TryParse(Console.ReadLine(), out choix);
                    } while (choix < 1 || choix > 4);
                    switch (choix)
                    {
                        case 1:
                            SupprimerCategorie();
                            break;
                        case 2:
                            SupprimerProduit();
                            break;
                        case 3:
                            SupprimerConsomateur();
                            break;
                        case 4:
                            SupprimerFacture();
                            break;
                    }
                    break;
            }
            try
            {
                DOAwocloo.conn.Close();
            }
            catch
            {
                Console.WriteLine("ERROR: Connection can not be closed !");
            }
            Console.ReadKey();
            
        }
    }
}
