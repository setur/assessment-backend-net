using System;
using System.Collections.Generic;

#nullable disable

namespace SeturDirectoryApp.Models
{
    public partial class User
    {
        public int Uuid { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int? CantactInformationId { get; set; }
        public string Company { get; set; }
    }
}
