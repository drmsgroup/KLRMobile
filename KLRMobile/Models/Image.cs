using System;
using System.IO;

namespace KLRMobile.Models
{
    public class Image
    {
        public int Id { get; set; }
        public Stream imageStream { get; set; }
        public int InstrumentId { get; set; }
    }
}