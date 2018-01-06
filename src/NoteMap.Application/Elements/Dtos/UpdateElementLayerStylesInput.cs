using Jane.Application.Services.Dto;
using System.Collections.Generic;

namespace NoteMap.Elements
{
    public class UpdateElementLayerStylesInput : EntityDto<long>
    {
        public List<LayerStyle> LayerStyles { get; set; }
    }
}