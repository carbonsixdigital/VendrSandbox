using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Vendr.Core;
using Vendr.Core.Api;
using Vendr.Core.Models;
using VendrSandbox.Core.Models.DocumentTypes;

namespace VendrSandbox.Core.Extensions
{
    public static class PublishedContentExtensions
    {
        public static Homepage GetHomepage(this IPublishedContent content)
            => content.AncestorOrSelf<Homepage>();

        public static CheckoutPage GetCheckoutPage(this IPublishedContent content)
        => content.AncestorOrSelf<Homepage>()?.FirstChild<CheckoutPage>(x => x.IsPublished());

        public static CartPage GetCartPage(this IPublishedContent content)
            => content.AncestorOrSelf<Homepage>()?.FirstChild<CartPage>(x => x.IsPublished() && x.TemplateId > 0);

        public static IEnumerable<CheckoutStepPage> GetSteps(this IPublishedContent content)
            => content.Children?.OfType<CheckoutStepPage>()?.Where(x => x.IsPublished() && x.TemplateId > 0);

        public static StoreReadOnly GetStore(this IPublishedContent content)
           => content.AncestorOrSelf<Homepage>()?.Store;

        public static OrderReadOnly GetCurrentOrder(this IPublishedContent content)
            => VendrApi.Instance.GetCurrentOrder(content.GetStore().Id);

        public static string GetProductReference(this IProduct content)
            => content.Key.ToString();

        public static IProductSnapshot AsVendrProduct(this IProduct content)
            => VendrApi.Instance.GetProduct(content.GetProductReference());

        public static Price CalculatePrice(this IProduct content)
            => content.AsVendrProduct()?.CalculatePrice();

        public static string GetAltText(this IPublishedContent content)
            => content != null && content.HasValue("altText") ? content.Value<string>("altText") : string.Empty;

        public static T Previous<T>(this IEnumerable<T> content, int id) where T : IPublishedContent
            => content != null
                 ? content.TakeWhile(x => !x.Id.Equals(id)).LastOrDefault()
                 : default;

        public static T Next<T>(this IEnumerable<T> content, int id) where T : IPublishedContent
            => content != null
                ? content.SkipWhile(x => !x.Id.Equals(id)).Skip(1).FirstOrDefault()
                : default;       
    }
}