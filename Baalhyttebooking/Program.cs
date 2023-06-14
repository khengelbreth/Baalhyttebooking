using System.Security.Cryptography.X509Certificates;

namespace Baalhyttebooking
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("OPGAVE 1:"); //Opgave 1:
            Boernegruppe boernegruppe = new Boernegruppe("1","Ulvene","Toddlers",5);
            Console.WriteLine(boernegruppe.Navn);
            Console.WriteLine(boernegruppe.Aldersgruppe);
            Console.WriteLine(boernegruppe);
            Console.WriteLine("-------------------------------------------");

            Console.WriteLine("OPGAVE 2:"); //Opgave 2:
            Reservation reservation = new Reservation(1,new DateTime().AddYears(2022).AddHours(12),boernegruppe);
            Console.WriteLine(reservation.Tidspunkt);
            Console.WriteLine(reservation);
            Console.WriteLine("-------------------------------------------");

            //Opgave 3:
            //-----------------------------------------------

            Console.WriteLine("OPGAVE 6:"); //Opgave 6:
            Reservationer resListe = new Reservationer();
            resListe.RegistrerReservation(1,reservation);
            resListe.PrintReservationer();
            Console.WriteLine("-------------------------------------------");
            resListe.FjernReservation(reservation); 
            resListe.PrintReservationer();
            Console.WriteLine("-------------------------------------------");

            //Opgave 7:
            //------------------------------------------------

            //Opgave 8:
            Console.WriteLine("OPGAVE 8:");
            Boernegruppe boernegruppe2 = new Boernegruppe("2", "Løverne", "Børnehavebørn", 10);
            Boernegruppe boernegruppe3 = new Boernegruppe("3", "Girafferne", "Vuggestue", 7);
            Boernegruppe boernegruppe4 = new Boernegruppe("4", "Spejderne", "Folkeskole", 13);
            Reservation reservation1 = new Reservation(5,new DateTime(2023,6,15,12,0,0),boernegruppe2);
            Reservation reservation2 = new Reservation(6, new DateTime(2023, 6, 15, 14, 0, 0), boernegruppe3);
            Reservation reservation3 = new Reservation(7, new DateTime(2024, 6, 15, 18, 0, 0), boernegruppe4);

            bool erReservation1Sand = resListe.ReservationOK(reservation1);
            Console.WriteLine($"Reservation 1 (ID:{reservation1.Id}) er OK?: " + erReservation1Sand);

            bool erReservation2Sand = resListe.ReservationOK(reservation2);
            Console.WriteLine($"Reservation 2 (ID:{reservation2.Id}) er OK?: " + erReservation2Sand);

            bool erReservation3Sand = resListe.ReservationOK(reservation3);
            Console.WriteLine($"Reservation 3 (ID:{reservation3.Id}) er OK?: " + erReservation3Sand);

            Console.WriteLine();
            int antalReservationer = resListe.AntalReservationer(boernegruppe);
            Console.WriteLine("Antal reservationer for børnegruppen: " + antalReservationer);
            Console.WriteLine("--------------------------------------------------------");

            Console.WriteLine("OPGAVE 9:"); //Opgave 9:
            try
            {
                resListe.ReservationOKK(reservation1);
                Console.WriteLine($"Reservations ID {reservation1.Id}, er OK.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                resListe.ReservationOKK(reservation3);
                Console.WriteLine($"Reservations ID {reservation3.Id}, er OK.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("------------------------------------------------------------------------");
        }
    }
}