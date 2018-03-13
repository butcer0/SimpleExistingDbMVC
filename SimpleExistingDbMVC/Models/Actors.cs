using System;
using System.Collections.Generic;

namespace SimpleExistingDbMVC.Models
{
    public partial class Actors
    {
        public int Id { get; set; }
        public bool AcademyWinner { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
