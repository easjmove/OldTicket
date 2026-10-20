using System;
using System.Collections.Generic;


namespace BilletDirect
{
    public enum TicketType
    {
        Standard,
        Student,
        Vip,
        EarlyBird
    }


    public class OldTicket
    {
        public string EventName { get; set; }
        public double BasePrice { get; set; }
        public TicketType Type { get; set; }
        public bool HasBackstageAccess { get; set; }


        public OldTicket(string eventName, double basePrice, TicketType type)
        {
            EventName = eventName;
            BasePrice = basePrice;
            Type = type;
        }


        // Switch-monstret: Beregner pris baseret på type
        public double CalculateFinalPrice()
        {
            switch (Type)
            {
                case TicketType.Standard:
                    return BasePrice;


                case TicketType.Student:
                    // Studerende får 20% rabat, men betaler et administrationsgebyr på 15 kr.
                    return (BasePrice * 0.80) + 15.0;


                case TicketType.Vip:
                    // VIP koster det dobbelte, men inkluderer fri bar-tillæg på 250 kr.
                    return (BasePrice * 2.0) + 250.0;


                case TicketType.EarlyBird:
                    // Early Bird sparer 30% af basisprisen
                    return BasePrice * 0.70;


                default:
                    return BasePrice;
            }
        }


        // Switch-monstret del 2: Scanner billetten ved indgangen
        public void ValidateEntry()
        {
            Console.WriteLine($"--- Scanner billet til {EventName} ---");
            switch (Type)
            {
                case TicketType.Standard:
                    Console.WriteLine("Adgang: Hovedindgang godkendt.");
                    break;


                case TicketType.Student:
                    Console.WriteLine("Adgang: Hovedindgang godkendt. BEMÆRK: Kræver fremvisning af gyldigt studiekort!");
                    break;


                case TicketType.Vip:
                    Console.WriteLine("Adgang: Fast-track VIP-indgang! Udlever champagne-armbånd og adgangskort.");
                    break;


                case TicketType.EarlyBird:
                    Console.WriteLine("Adgang: Hovedindgang godkendt. (Tidlig ankomst registreret).");
                    break;
            }
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            List<OldTicket> tickets = new List<OldTicket>
            {
                new OldTicket("Roskilde Festival Dagsbillet", 1000, TicketType.Standard),
                new OldTicket("Roskilde Festival Dagsbillet", 1000, TicketType.Student),
                new OldTicket("Roskilde Festival Dagsbillet", 1000, TicketType.Vip),
                new OldTicket("Roskilde Festival Dagsbillet", 1000, TicketType.EarlyBird)
            };


            foreach (var ticket in tickets)
            {
                Console.WriteLine($"Billettype: {ticket.Type} | Pris: {ticket.CalculateFinalPrice():N2} DKK");
                ticket.ValidateEntry();
                Console.WriteLine();
            }
        }
    }
}
