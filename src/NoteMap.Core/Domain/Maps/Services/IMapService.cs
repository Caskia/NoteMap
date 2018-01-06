using Jane.Dependency;
using System.Threading.Tasks;

namespace NoteMap.Maps
{
    public interface IMapService : ITransientDependency
    {
        Task<Map> CreateAsync(Map map);
    }
}