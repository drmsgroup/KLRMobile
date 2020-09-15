using System;

namespace KLRMobile.Models
{
    public class TitleLien
    {
        public string Id { get; set; }
        public string SecurityId { get; set; }
        public string SecurityType { get; set; }
        public DateTime DateFiled { get; set; }
        public string FileNumber { get; set; }
        public string TitleNumber { get; set; }
        public string VINNumber { get; set; }
        public string IndexedBy { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Description { get; set; }
    }
}