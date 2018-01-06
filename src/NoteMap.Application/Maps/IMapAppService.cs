using Jane.Dependency;
using System.Threading.Tasks;

namespace NoteMap.Maps
{
    public interface IMapAppService : ITransientDependency
    {
        Task<MapDto> CreateMapAsync(CreateMapInput input);

        Task<MapDto> GetMapAsync(long id);
    }
}