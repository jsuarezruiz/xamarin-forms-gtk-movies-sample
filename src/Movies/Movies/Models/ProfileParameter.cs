using Movies.Models.People;
using System.Collections.Generic;

namespace Movies.Models
{
    public class ProfileParameter
    {
        public Profile Current { get; set; }

        public List<Profile> Images { get; set; }
    }
}