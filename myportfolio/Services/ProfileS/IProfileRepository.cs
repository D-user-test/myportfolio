

using myportfolio.Models;

namespace myportfolio.Services.ProfileS
{
    public interface IProfileRepository
    {
        List<Profile> GetAll();
        Profile GetById(int id);
        void Create(Profile profile);
        void Update(Profile profile);
        void Delete(int id);
    }

}
