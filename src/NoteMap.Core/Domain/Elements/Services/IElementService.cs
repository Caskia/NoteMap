using Jane.Dependency;
using System.Threading.Tasks;

namespace NoteMap.Elements
{
    public interface IElementService : ITransientDependency
    {
        Task<Element> CreateAsync(Element element);
    }
}