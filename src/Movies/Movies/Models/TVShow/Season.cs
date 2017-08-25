using System;
using System.Runtime.Serialization;

namespace Movies.Models.TVShow
{
    [DataContract]
    public class Season
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "air_date")]
        public DateTime AirDate { get; set; }

        [DataMember(Name = "episode_count")]
        public int EpisodeCount { get; set; }

        [DataMember(Name = "poster_path")]
        public string PosterPath { get; set; }

        [DataMember(Name = "season_number")]
        public int SeasonNumber { get; set; }
    }
}