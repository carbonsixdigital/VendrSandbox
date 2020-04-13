using Umbraco.Core;
using Umbraco.Core.Composing;
using VendrSandbox.Core.Interfaces;
using VendrSandbox.Core.Models.Builders;
using VendrSandbox.Core.Models.DocumentTypes;
using VendrSandbox.Core.Services;

namespace VendrSandbox.Core.Composers
{
    public class WebComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            // builders
            composition.Register<IBuilder<Master>, MasterBuilder>();
            composition.Register<IBuilder<Homepage>, HomepageBuilder>();

            composition.Register<IBuilder<ProductsPage>, ProductsPageBuilder>();
            composition.Register<IBuilder<CollectionPage>, CollectionPageBuilder>();
            composition.Register<IBuilder<ProductPage>, ProductPageBuilder>();

            composition.Register<IBuilder<CartPage>, CartPageBuilder>();
            composition.Register<IBuilder<CheckoutPage>, CheckoutPageBuilder>();
            composition.Register<IBuilder<CheckoutInformationPage>, CheckoutInformationPageBuilder>();
            composition.Register<IBuilder<CheckoutShippingPaymentMethodPage>, CheckoutShippingPaymentMethodPageBuilder>();
            composition.Register<IBuilder<CheckoutReviewPage>, CheckoutReviewPageBuilder>();
            composition.Register<IBuilder<CheckoutConfirmationPage>, CheckoutConfirmationPageBuilder>();

            // services
            composition.Register<INavigationService, NavigationService>();

        }
    }
}
