using Umbraco.Core.Models.PublishedContent;

namespace VendrSandbox.Core.Interfaces
{
    public interface IBuilder<T> where T : IPublishedContent
    {
        T Build(T model);           
    }
}