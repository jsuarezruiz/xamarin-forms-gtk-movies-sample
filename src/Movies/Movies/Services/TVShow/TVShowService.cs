using System.Threading.Tasks;
using Movies.Models;
using Movies.Services.Request;

namespace Movies.Services.TVShow
{
    public class TVShowService : ITVShowService
    {
        private readonly IRequestService _requestProvider;

        public TVShowService(IRequestService requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task<Models.TVShow.TVShow> FindByIdAsync(int tvShowId, string language = "en")
        {
            string uri = $"{AppSettings.ApiUrl}tv/{tvShowId}?api_key={AppSettings.ApiKey}&language={language}";

            Models.TVShow.TVShow response = await _requestProvider.GetAsync<Models.TVShow.TVShow>(uri);

            return response;
        }

        public async Task<Models.TVShow.TVShow> GetLatestAsync(string language = "en")
        {
            string uri = $"{AppSettings.ApiUrl}tv/latest?api_key={AppSettings.ApiKey}&language={language}";

            Models.TVShow.TVShow response = await _requestProvider.GetAsync<Models.TVShow.TVShow>(uri);

            return response;
        }

        public async Task<SearchResponse<Models.TVShow.TVShow>> GetPopularAsync(int pageNumber = 1, string language = "en")
        {
            string uri = $"{AppSettings.ApiUrl}tv/popular?api_key={AppSettings.ApiKey}&language={language}&page={pageNumber}";

            SearchResponse<Models.TVShow.TVShow> response = await _requestProvider.GetAsync<SearchResponse<Models.TVShow.TVShow>>(uri);

            return response;
        }

        public async Task<SearchResponse<Models.TVShow.TVShow>> GetTopRatedAsync(int pageNumber = 1, string language = "en")
        {
            string uri = $"{AppSettings.ApiUrl}tv/top_rated?api_key={AppSettings.ApiKey}&language={language}&page={pageNumber}";

            SearchResponse<Models.TVShow.TVShow> response = await _requestProvider.GetAsync<SearchResponse<Models.TVShow.TVShow>>(uri);

            return response;
        }
    }
}