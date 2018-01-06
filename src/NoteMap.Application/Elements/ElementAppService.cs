using Jane;
using Jane.AutoMapper;
using Jane.Repositories;
using NoteMap.Maps;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace NoteMap.Elements
{
    public class ElementAppService : IElementAppService
    {
        private readonly IMongoDbRepository<Element, long> _elementRepository;
        private readonly IElementService _elementService;
        private readonly IMongoDbRepository<Map, long> _mapRepository;

        public ElementAppService(
            IMongoDbRepository<Element, long> elementRepository,
            IElementService elementService,
            IMongoDbRepository<Map, long> mapRepository
            )
        {
            _elementRepository = elementRepository;
            _elementService = elementService;
            _mapRepository = mapRepository;
        }

        public async Task<ElementDto> CreateElementOnMapAsync(CreateElementInput input)
        {
            var map = await _mapRepository.FirstOrDefaultAsync(m => m.Id == input.MapId);
            if (map == null)
            {
                throw new BaseException($"Map[{input.MapId}] not found!");
            }

            var element = input.MapTo<Element>();

            element = await _elementService.CreateAsync(element);

            return element.MapTo<ElementDto>();
        }

        public async Task<IList<ElementDto>> GetElementsOnMap(GetElementsOnMapInput input)
        {
            var map = await _mapRepository.FirstOrDefaultAsync(m => m.Id == input.MapId);
            if (map == null)
            {
                throw new BaseException($"Map[{input.MapId}] not found!");
            }

            var elements = _elementRepository.GetAll()
                 .Where(e => e.Position.X >= input.BeginPosition.X && e.Position.X <= input.EndPosition.X)
                 .Where(e => e.Position.Y >= input.BeginPosition.Y && e.Position.Y <= input.EndPosition.Y)
                 .ToList();

            return elements.MapTo<List<ElementDto>>();
        }

        public async Task UpdateElementLayerStylesAsync(UpdateElementLayerStylesInput input)
        {
            var element = await _elementRepository.FirstOrDefaultAsync(e => e.Id == input.Id);
            if (element == null)
            {
                throw new BaseException($"Element[{input.Id}] not found!");
            }

            element.LayerStyles = input.LayerStyles;

            await _elementRepository.UpdateAsync(element);
        }

        public async Task UpdateElementPositionAsync(UpdateElementPositionInput input)
        {
            var element = await _elementRepository.FirstOrDefaultAsync(e => e.Id == input.Id);
            if (element == null)
            {
                throw new BaseException($"Element[{input.Id}] not found!");
            }

            element.Position = input.Position;

            await _elementRepository.UpdateAsync(element);
        }
    }
}