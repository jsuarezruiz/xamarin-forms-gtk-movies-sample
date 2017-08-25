using System.Runtime.Serialization;

namespace Movies.Models.Movie
{
    [DataContract]
    public class MovieCastMember
    {
        [DataMember(Name = "id")]
        public int PersonId { get; set; }

        [DataMember(Name = "cast_id")]
        public int CastId { get; set; }

        [DataMember(Name = "credit_id")]
        public string CreditId { get; set; }

        [DataMember(Name = "character")]
        public string Character { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "order")]
        public int Order { get; set; }

        [DataMember(Name = "profile_path")]
        public string ProfilePath { get; set; }
    }
}