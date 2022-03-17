using System;
using System.Linq;

namespace Delegates
{
    class Program
    {
        public delegate string ValidationChaine(string s);
        static void Main(string[] args)
        {
            // DEMANDER LE NOM DE L'UTILISATEUR

            string nom = DemanderChaineUtilisateur("Quel est vrotre nom ? ", CheckValidationNom);

            // DEMANDER LE NUMERO DE TELEPHONE DE L'UTILISATEUR

            string tel = DemanderChaineUtilisateur("Quel est votre numéro de téléphone ? ", CheckValidationTel);


            Console.WriteLine();
            Console.WriteLine("Bonjour " + nom + ", vous êtes joignable au " + tel);


        }

        static string DemanderChaineUtilisateur(string message, ValidationChaine fonctionValidation = null)
        {
            Console.Write(message + " ");
            string reponse = Console.ReadLine();
            
            if (fonctionValidation != null)
            {
                string erreur = fonctionValidation(reponse);

                if (erreur != null)
                {
                    Console.WriteLine("ERREUR : " + erreur);
                    return DemanderChaineUtilisateur(message, fonctionValidation);
                }
            }
            
            return reponse;
        }

        static string CheckValidationNom (string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return "Le nom ne doit pas être vide";
            }

            if (s.Any(char.IsDigit)) 
            {
                return "Le nom ne doit pas contenir de chiffres";
            }
            return null;
 
        }
       

            static string CheckValidationTel(string s)
            {
                if (string.IsNullOrWhiteSpace(s))
                {
                    return "Le numéro de téléphone ne doit pas être vide";
                }

                if (s.Length != 10)
                {
                    return "Le numéro de téléphone doit contenir 10 chiffres";
             
                }
            

                if (!s.All(char.IsDigit))
                {
                    return "Le numéro de téléphone ne doit contenir que des chiffres";
                }
                return null;
            }

    }
}
