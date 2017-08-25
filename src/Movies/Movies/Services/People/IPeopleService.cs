using Movies.Models;
using Movies.Models.People;
using System.Threading.Tasks;

namespace Movies.Services.People
{
    public interface IPeopleService
    {
        Task<Person> FindByIdAsync(int personId, string language = "en");

        Task<SearchResponse<Person>> SearchByNameAsync(string query, int pageNumber = 1, string language = "en");

        Task<PersonImage> GetImagesAsync(int personId, string language = "en");
    }
}