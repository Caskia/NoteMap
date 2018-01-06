using Jane;
using Jane.Repositories;
using System.Threading.Tasks;

namespace NoteMap.Elements
{
    public class ElementService : IElementService
    {
        private readonly IMongoDbRepository<Element, long> _elementRepository;
        private readonly IIdGenerator _idGenerator;

        public ElementService(
            IMongoDbRepository<Element, long> elementRepository,
            IIdGenerator idGenerator
            )
        {
            _elementRepository = elementRepository;
            _idGenerator = idGenerator;
        }

        public async Task<Element> CreateAsync(Element element)
        {
            element.Id = _idGenerator.NextId();
            await _elementRepository.InsertAsync(element);

            return element;
        }
    }
}