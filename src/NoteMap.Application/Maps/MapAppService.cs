using Jane;
using Jane.AutoMapper;
using Jane.Repositories;
using System.Threading.Tasks;

namespace NoteMap.Maps
{
    public class MapAppService : IMapAppService
    {
        private readonly IMongoDbRepository<Map, long> _mapRepository;
        private readonly IMapService _mapService;

        public MapAppService(
            IMongoDbRepository<Map, long> mapRepository,
            IMapService mapService
            )
        {
            _mapRepository = mapRepository;
            _mapService = mapService;
        }

        public async Task<MapDto> CreateMapAsync(CreateMapInput input)
        {
            var map = input.MapTo<Map>();

            map = await _mapService.CreateAsync(map);

            return map.MapTo<MapDto>();
        }

        public async Task<MapDto> GetMapAsync(long id)
        {
            var map = await _mapRepository.FirstOrDefaultAsync(m => m.Id == id);
            if (map == null)
            {
                throw new BaseException($"Map[{id}] not found!");
            }

            return map.MapTo<MapDto>();
        }

        public async Task UpdateMapOffsetAsync(UpdateMapOffsetInput input)
        {
            var map = await _mapRepository.FirstOrDefaultAsync(m => m.Id == input.Id);
            if (map == null)
            {
                throw new BaseException($"Map[{input.Id}] not found!");
            }

            map.Offset = input.Offset;

            await _mapRepository.UpdateAsync(map);
        }
    }
}