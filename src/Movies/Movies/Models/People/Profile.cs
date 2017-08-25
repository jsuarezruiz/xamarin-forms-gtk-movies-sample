using System.Runtime.Serialization;

namespace Movies.Models.People
{
    [DataContract]
    public class Profile
    {
        [DataMember(Name = "width")]
        public int Width { get; set; }

        [DataMember(Name = "height")]
        public int Height { get; set; }

        [DataMember(Name = "vote_count")]
        public int VoteCount { get; set; }

        [DataMember(Name = "vote_average")]
        public double VoteAverage { get; set; }

        [DataMember(Name = "file_path")]
        public string FilePath { get; set; }

        [DataMember(Name = "aspect_ratio")]
        public double AspectRatio { get; set; }
    }
}