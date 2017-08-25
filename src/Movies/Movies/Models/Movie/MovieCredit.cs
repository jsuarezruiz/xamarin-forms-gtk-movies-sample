using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Movies.Models.Movie
{
    [DataContract]
    public class MovieCredit
    {
        [DataMember(Name = "id")]
        public int MovieId { get; set; }

        [DataMember(Name = "cast")]
        public IList<MovieCastMember> CastMembers { get; set; }

        [DataMember(Name = "crew")]
        public IList<MovieCrewMember> CrewMembers { get; set; }
    }
}