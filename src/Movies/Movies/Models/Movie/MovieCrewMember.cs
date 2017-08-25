using System.Runtime.Serialization;

namespace Movies.Models.Movie
{
    [DataContract]
    public class MovieCrewMember
    {
        [DataMember(Name = "id")]
        public int PersonId { get; set; }

        [DataMember(Name = "credit_id")]
        public string CreditId { get; set; }

        [DataMember(Name = "department")]
        public string Department { get; set; }

        [DataMember(Name = "job")]
        public string Job { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "profile_path")]
        public string ProfilePath { get; set; }
    }
}