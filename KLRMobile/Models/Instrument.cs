using System;

namespace KLRMobile.Models
{
    public class Instrument
    {
        public int InstrumentId { get; set; }
        public string InstrumentType { get; set; }
        public DateTime DateFiled { get; set; }
        public string BookName { get; set; }
        public string BookNumber { get; set; }
        public string PageNumber { get; set; }
        public DateTime LastUpdated { get; set; }
        public string UpdatedBy { get; set; }
        public string Description { get; set; }
    }
}