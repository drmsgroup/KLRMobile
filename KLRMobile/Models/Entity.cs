using System;

namespace KLRMobile.Models
{
    public class Entity
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int InstrumentId { get; set; }
        public EntityType EntityType { get; set; }
    }

    public enum EntityType
    {
        FatherOfBride,
        MotherOfBride,
        FatherOfGroom,
        MotherOfGroom,
        Bride,
        Groom,
        Grantor,
        Grantee
    }
}