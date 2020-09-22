using System;

namespace KLRMobile.Models
{
    public class TitleLienResultItem
    {
        public string Id { get; set; }
        public string Debtor { get; set; }
        public string LienHolder { get; set; }
        public string FileNumber { get; set; }
        public string VINNumber { get; set; }
        public string Description { get; set; }
        public DateTime DateFiled { get; set; }
        public DateTime Released { get; set; }
    }
}