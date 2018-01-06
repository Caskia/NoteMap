using Jane.Dependency;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteMap.Elements
{
    public interface IElementAppService : ITransientDependency
    {
        Task<ElementDto> CreateElementOnMapAsync(CreateElementInput input);

        Task<IList<ElementDto>> GetElementsOnMap(GetElementsOnMapInput input);

        Task UpdateElementLayerStylesAsync(UpdateElementLayerStylesInput input);

        Task UpdateElementPositionAsync(UpdateElementPositionInput input);
    }
}