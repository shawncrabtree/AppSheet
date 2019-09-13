using AppSheet.Models;
using Refit;
using System.Threading.Tasks;

namespace AppSheet.Endpoint
{
    public interface IPeopleEndpoint
    {
        [Get("/list")]
        Task<PersonListResultModel> GetList(string token = null);

        [Get("/detail/{id}")]
        Task<PersonModel> GetPerson(int id);
    }
}
