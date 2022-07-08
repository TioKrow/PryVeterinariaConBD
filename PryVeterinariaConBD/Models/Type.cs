using System;
using System.Collections.Generic;

#nullable disable

namespace PryVeterinariaConBD.Models
{
    public partial class Type
    {
        public Type()
        {
            PetFiles = new HashSet<PetFile>();
        }

        public int Id { get; set; }
        public string Type1 { get; set; }

        public virtual ICollection<PetFile> PetFiles { get; set; }
    }
}
