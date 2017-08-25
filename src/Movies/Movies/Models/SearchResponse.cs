using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Movies.Models
{
    [DataContract]
    public class SearchResponse<T> 
    {
        [DataMember(Name = "results")]
        public IReadOnlyList<T> Results { get; private set; }

        [DataMember(Name = "page")]
        public int PageNumber { get; private set; }

        [DataMember(Name = "total_pages")]
        public int TotalPages { get; private set; }

        [DataMember(Name = "total_results")]
        public int TotalResults { get; private set; }
    }
}