using System;

namespace KLRMobile.Models
{
    public class LRMRResultItem
    {
        public string Id { get; set; }
        public string FirstParty { get; set; }
        public string SecondParty { get; set; }
        public string BookNumber { get; set; }
        public string PageNumber { get; set; }
        public DateTime DateFiled { get; set; }
    }
}