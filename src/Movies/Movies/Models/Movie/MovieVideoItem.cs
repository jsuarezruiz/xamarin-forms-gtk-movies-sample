using System.Runtime.Serialization;

namespace Movies.Models.Movie
{
    [DataContract]
    public class MovieVideoItem
    {
        [DataMember(Name = "id")]
        public string MovieVideoItemId { get; set; }

        [DataMember(Name = "key")]
        public string Key { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "site")]
        public string Site { get; set; }

        [DataMember(Name = "size")]
        public int Size { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }
    }
}