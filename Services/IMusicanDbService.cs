using System.Threading.Tasks;

namespace kol2.Services
{
    public interface IMusicanDbService
    {
        Task DeleteMusican(int idMusican);
    }
}
