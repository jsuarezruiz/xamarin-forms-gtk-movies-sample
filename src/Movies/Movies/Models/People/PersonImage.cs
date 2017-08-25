using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Movies.Models.People
{
    [DataContract]
    public class PersonImage
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "profiles")]
        public List<Profile> profiles { get; set; }
    }
}