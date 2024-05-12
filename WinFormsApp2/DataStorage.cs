using System;
using System.Collections.Generic;

namespace WinFormsApp2
{
    public static class DataStorage
    {
        public static List<Donation> Donations { get; } = new List<Donation>();
        public static List<Donor> Donors { get; } = new List<Donor>();
    }

    public class Donation
    {
        public decimal Amount { get; set; }
        public string DonorName { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }

    public class Donor
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
