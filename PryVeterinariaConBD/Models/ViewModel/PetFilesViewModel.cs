using System;

namespace PryVeterinariaConBD.Models.ViewModel
{
    public class PetFilesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string OwnerName { get; set; }
        public string OwnerPhone { get; set; }
        public DateTime CreationDate { get; set; }
        public int? IdType { get; set; }

        public virtual Type IdTypeNavigation { get; set; }
    }
}
