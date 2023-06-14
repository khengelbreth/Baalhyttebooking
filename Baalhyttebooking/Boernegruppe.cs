using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baalhyttebooking
{
    public class Boernegruppe
    {
        private string _id;
        private string _navn;
        private string _aldersgruppe;
        private int _antalDeltagere;

        public Boernegruppe(string id, string navn, string aldersgruppe, int antalDeltagere) 
        { 
            _id = id;
            _navn = navn;
            _aldersgruppe = aldersgruppe;
            _antalDeltagere = antalDeltagere;
        }

        public string Id 
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Navn 
        { 
            get { return _navn; } 
            set { _navn = value; } 
        }
        public string Aldersgruppe 
        { 
            get { return _aldersgruppe; }
            set { _aldersgruppe = value; } 
        }
        public int AntalDeltagere 
        { 
            get { return _antalDeltagere; }
            set { _antalDeltagere = value; }
        }

        public override string ToString()
        {
            return $"ID: {Id}. " + $"Børnegruppens navn er '{Navn}'. " + $"Aldersgruppen er: '{Aldersgruppe}'. " + $"{AntalDeltagere} deltagere tilmeldt.";
        }
    }
}
