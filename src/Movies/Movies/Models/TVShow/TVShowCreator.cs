using System.Runtime.Serialization;

namespace Movies.Models.TVShow
{
    [DataContract]
    public class TVShowCreator
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "profile_path")]
        public string ProfilePath { get; set; }
    }
}