using Jane.AspNetCore.Cors;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NoteMap.Elements;
using NoteMap.Maps;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteMap.WebApi.Controllers
{
    [Route("maps")]
    [EnableCors(CorsPolicyNames.CorsAllPolicyName)]
    public class MapController : Controller
    {
        private readonly IElementAppService _elementAppService;
        private readonly IMapAppService _mapAppService;

        public MapController(
            IElementAppService elementAppService,
            IMapAppService mapAppService
            )
        {
            _elementAppService = elementAppService;
            _mapAppService = mapAppService;
        }

        [Route("{id:long}/elements")]
        [HttpPost]
        public async Task<ElementDto> CreateElementAsync(long id, [FromBody]CreateElementInput input)
        {
            input.MapId = id;
            return await _elementAppService.CreateElementOnMapAsync(input);
        }

        [Route("")]
        [HttpPost]
        public async Task<MapDto> CreateMapAsync([FromBody]CreateMapInput input)
        {
            return await _mapAppService.CreateMapAsync(input);
        }

        [Route("{id:long}/elements/{elementId:long}")]
        [HttpDelete]
        public async Task<bool> DeleteElementAsync(long id, long elementId)
        {
            await _elementAppService.DeleteElementAsync(elementId);
            return true;
        }

        [Route("{id:long}/elements")]
        [HttpGet]
        public async Task<IList<ElementDto>> GetElementsOnMapAsync(
            long id,
            [FromQuery]double x1 = 0,
            [FromQuery]double y1 = 0,
            [FromQuery]double x2 = 0,
            [FromQuery]double y2 = 0
            )
        {
            return await _elementAppService.GetElementsOnMapAsync(new GetElementsOnMapInput()
            {
                MapId = id,
                BeginPosition = new Position()
                {
                    X = x1,
                    Y = y1
                },
                EndPosition = new Position()
                {
                    X = x2,
                    Y = y2
                }
            });
        }

        [Route("{id:long}")]
        [HttpGet]
        public async Task<MapDto> GetMapAsync(long id)
        {
            return await _mapAppService.GetMapAsync(id);
        }

        [Route("{id:long}/offset")]
        [HttpPut]
        public async Task<bool> UpdateMapOffsetAsync(long id, [FromBody]UpdateMapOffsetInput input)
        {
            input.Id = id;
            await _mapAppService.UpdateMapOffsetAsync(input);
            return true;
        }

        [Route("{id:long}/elements/{elementId:long}/layer_styles")]
        [HttpPut]
        public async Task<bool> UpdateElementLayerStylesAsync(long id, long elementId, [FromBody]UpdateElementLayerStylesInput input)
        {
            input.Id = elementId;
            await _elementAppService.UpdateElementLayerStylesAsync(input);
            return true;
        }

        [Route("{id:long}/elements/{elementId:long}/position")]
        [HttpPut]
        public async Task<bool> UpdateElementPositionAsync(long id, long elementId, [FromBody]UpdateElementPositionInput input)
        {
            input.Id = elementId;
            await _elementAppService.UpdateElementPositionAsync(input);
            return true;
        }
    }
}