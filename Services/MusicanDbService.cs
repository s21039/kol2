using kol2.Models;
using System.Threading.Tasks;

namespace kol2.Services
{
    public class MusicanDbService : IMusicanDbService
    {
        private readonly MusicDbContext _musicDbContext;

        public MusicanDbService(MusicDbContext musicDbContext)
        {
            _musicDbContext = musicDbContext;
        }

        public Task DeleteMusican(int idMusican)
        {
            throw new System.NotImplementedException();
        }
    }
}
