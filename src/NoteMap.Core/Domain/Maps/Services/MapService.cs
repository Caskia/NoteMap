using Jane;
using Jane.Repositories;
using System.Threading.Tasks;

namespace NoteMap.Maps
{
    public class MapService : IMapService
    {
        private readonly IIdGenerator _idGenerator;
        private readonly IMongoDbRepository<Map, long> _mapRepository;

        public MapService(
            IIdGenerator idGenerator,
            IMongoDbRepository<Map, long> mapRepository
            )
        {
            _idGenerator = idGenerator;
            _mapRepository = mapRepository;
        }

        public async Task<Map> CreateAsync(Map map)
        {
            map.Id = _idGenerator.NextId();
            return await _mapRepository.InsertAsync(map);
        }
    }
}