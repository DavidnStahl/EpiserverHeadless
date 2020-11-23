using EPiServer.Core;

namespace EPiHeadless.Models.Pages
{
    public interface IHasRelatedContent
    {
        ContentArea RelatedContentArea { get; }
    }
}
