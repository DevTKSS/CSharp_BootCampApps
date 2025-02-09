using WebServices.DataModels;

namespace WebServices;
public interface IBreedSearchApi
{
    Task<IEnumerable<Breed>> GetBreeds(int limit = 1, int page = 0);
}