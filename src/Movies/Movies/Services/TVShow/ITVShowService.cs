using Movies.Models;
using System.Threading.Tasks;

namespace Movies.Services.TVShow
{
    public interface ITVShowService
    {
        Task<Models.TVShow.TVShow> FindByIdAsync(int tvShowId, string language = "en");

        Task<Models.TVShow.TVShow> GetLatestAsync(string language = "en");

        Task<SearchResponse<Models.TVShow.TVShow>> GetTopRatedAsync(int pageNumber = 1, string language = "en");

        Task<SearchResponse<Models.TVShow.TVShow>> GetPopularAsync(int pageNumber = 1, string language = "en");
    }
}