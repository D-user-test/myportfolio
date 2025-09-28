

using myportfolio.Models;

namespace myportfolio.Services.ProfileS
{
    public interface IProfileRepository
    {
     
        void Create(Profile profile);
        void Update(Profile profile);
        void Delete(int id);
    }

}
