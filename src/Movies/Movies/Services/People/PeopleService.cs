using System.Threading.Tasks;
using Movies.Models;
using Movies.Models.People;
using Movies.Services.Request;

namespace Movies.Services.People
{
    public class PeopleService : IPeopleService
    {
        private readonly IRequestService _requestProvider;

        public PeopleService(IRequestService requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task<Person> FindByIdAsync(int personId, string language = "en")
        {
            string uri = $"{AppSettings.ApiUrl}person/{personId}?api_key={AppSettings.ApiKey}&language={language}";

            Person response = await _requestProvider.GetAsync<Person>(uri);

            return response;
        }

        public async Task<SearchResponse<Person>> SearchByNameAsync(string query, int pageNumber = 1, string language = "en")
        {
            string uri = $"{AppSettings.ApiUrl}search/person?api_key={AppSettings.ApiKey}&language={language}&page={pageNumber}";

            SearchResponse<Person> response = await _requestProvider.GetAsync<SearchResponse<Person>>(uri);

            return response;
        }

        public async Task<PersonImage> GetImagesAsync(int personId, string language = "en")
        {
            string uri = $"{AppSettings.ApiUrl}person/{personId}/images?api_key={AppSettings.ApiKey}&language={language}";

            PersonImage response = await _requestProvider.GetAsync<PersonImage>(uri);

            return response;
        }
    }
}