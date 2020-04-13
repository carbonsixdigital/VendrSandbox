using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages;
using Umbraco.Web.Composing;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Vendr.Core.Models;
using VendrSandbox.Core.Models.DocumentTypes;
using System.Web.Mvc;

namespace VendrSandbox.Core.ViewModels.Checkout
{
    public class CartItemViewModel
    {
        public CartItemViewModel(OrderLineReadOnly orderLine, int index)
        {
            Index = index;
            OrderLine = orderLine;

            var umbracoContextFactory = DependencyResolver.Current.GetService<IUmbracoContextFactory>();
            if (umbracoContextFactory != null)
            {
                using (var cref = umbracoContextFactory.EnsureUmbracoContext())
                {
                    Node = cref.UmbracoContext?.Content?.GetById(orderLine.ProductReference.As<Guid>());
                    Url = Node.ContentType.Alias == ProductVariant.ModelTypeAlias ? Node.Parent.Url : Node.Url;
                }
            }
        }

        public int Index { get; internal set; }
        public OrderLineReadOnly OrderLine { get; internal set; }

        public IPublishedContent Node { get; internal set; }
        public string Url { get; internal set; }
    }
}
