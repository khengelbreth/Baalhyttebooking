using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Baalhyttebooking
{
    public class Reservationer
    {
        private int _id = 2023;
        private Dictionary<int,Reservation> _list;

        public Reservationer() 
        { 
            _list = new Dictionary<int,Reservation>();
            Console.WriteLine($"Reservationliste ID: {_id}) \n");
        }

        public Dictionary<int,Reservation> Reservations 
        {
            get { return _list; } 
        }
        public int Id 
        { 
            get { return _id; } 
            set { _id = value; } 
        }

        //Opgave 6:
        public void RegistrerReservation(Reservation reservation)
        {
            Reservations.Add(reservation.Id, reservation);
        }

        public void PrintReservationer()
        {
            foreach (var reservation in Reservations)
                Console.WriteLine(reservation);
        }

        public void FjernReservation(Reservation reservation)
        {
            Reservations.Remove(reservation.Id);
        }


        //Opgave 7:
        public int AntalReservationer(Boernegruppe bGruppe)
        {
            int count = 0;
            foreach (var reservation in Reservations)
            {
                if (reservation.Value.Boernegruppe.Equals(bGruppe))
                {
                    count++;
                }
            }
            return count;
        }

        public bool ReservationLedig(Reservation reservation)
        {
            foreach (var optagetReservation in Reservations)
            {
                if (optagetReservation.Value.Tidspunkt == reservation.Tidspunkt)
                {
                    return false;
                }
            }
            return true;
        }


        List<int> aabneTider = new List<int>() { 12, 14, 16, 18, 20 };
        public bool ReservationsTidspunktOK(Reservation reservation)
        {
            if (reservation.Tidspunkt.Year != _id)
            {
                return false;
            }

            if (reservation.Tidspunkt.DayOfWeek != DayOfWeek.Thursday)
            {
                return false;
            }

            if (!aabneTider.Contains(reservation.Tidspunkt.Hour))
            {
                return false;
            }

            if (reservation.Tidspunkt.Minute != 0 || reservation.Tidspunkt.Second != 0 || reservation.Tidspunkt.Millisecond != 0)
            {
                return false;
            }

            return true;
        }

        //Opgave 8:
        public bool ReservationOK(Reservation reservation)
        {
            if (reservation.Boernegruppe == null)
            {
                Console.WriteLine($"- Reservations ID {reservation.Id}. Reservations ID skal have en reference til en børnegruppe. -");
                return false;
            }
            if (AntalReservationer(reservation.Boernegruppe) >= 2)
            {
                Console.WriteLine($"- Reservations ID {reservation.Id}. Antallet af reservationer for børnegruppen er allerede højere end tilladt (2). -");
                return false;
            }
            if (!ReservationLedig(reservation))
            {
                Console.WriteLine($"- Reservations ID {reservation.Id}. Tidspunktet for reservationen er allerede optaget. -");
                return false;
            }
            if (!ReservationsTidspunktOK(reservation))
            {
                Console.WriteLine($"- Reservations ID {reservation.Id}. Tidspunktet for reservationen er ugyldigt. -");
                return false;
            }

            return true;
        }

        //Opgave 9:
        public void ReservationOKK(Reservation reservation)
        {
            if (reservation.Boernegruppe == null)
            {
                throw new Exception($"- Reservations ID {reservation.Id}. Skal have en reference til en børnegruppe. -");
            }
            if (AntalReservationer(reservation.Boernegruppe) >= 2)
            {
                throw new Exception($"- Reservations ID {reservation.Id}. Antallet af reservationer for børnegruppen er allerede højere end tilladt (2). -");
            }
            if (!ReservationLedig(reservation))
            {
                throw new Exception($"- Reservations ID {reservation.Id}. Tidspunktet for reservationen er allerede optaget. -");
            }

            if (!ReservationsTidspunktOK(reservation))
            {
                throw new Exception($"- Reservations ID {reservation.Id}. Tidspunktet for reservationen er ugyldigt. -");
            }
        }

    }
}
