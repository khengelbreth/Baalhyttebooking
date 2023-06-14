using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baalhyttebooking
{
    public class Reservation
    {
        private int _id;
        private DateTime _tidspunkt;
        private Boernegruppe _boernegruppe;

        public Reservation(int id, DateTime tidspunkt, Boernegruppe boernegruppe) 
        { 
            _id = id;
            _tidspunkt = tidspunkt;
            _boernegruppe = boernegruppe;
        }
        
        public int Id 
        { 
            get { return _id; } 
            set { _id = value; } 
        }
        public DateTime Tidspunkt 
        { 
            get { return _tidspunkt; } 
            set { _tidspunkt = value; } 
        }

        public Boernegruppe Boernegruppe 
        {
            get { return _boernegruppe; }
            set { _boernegruppe = value; } 
        }

        public override string ToString()
        {
            return $"Reservations ID: {Id} - " + $"Tidspunkt: {Tidspunkt}. " + $"Børnegruppe: {Boernegruppe}. ";
        }

    }
}
