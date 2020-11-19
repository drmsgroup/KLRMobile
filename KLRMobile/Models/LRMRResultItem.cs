using System;
using System.Collections.Generic;

namespace KLRMobile.Models
{
    public class LRMRResultItem
    {
        public int Id { get; set; }
        public string FirstParty { get; set; }
        public string SecondParty { get; set; }
        public string BookNumber { get; set; }
        public string BookName { get; set; }
        public string PageNumber { get; set; }
        public string InstrumentType { get; set; }
        public string UpdatedBy { get; set; }
        public string IndexedBy { get; set; }
        public string Description { get; set; }
        public DateTime DateFiled { get; set; }
        public DateTime LastUpdated { get; set; }
        public string HasImage { get; set; }
        public List<Entity> Entities { get; set; }
    }
}