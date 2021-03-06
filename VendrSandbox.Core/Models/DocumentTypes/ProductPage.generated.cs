//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder v8.5.4
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.ModelsBuilder.Embedded;

namespace VendrSandbox.Core.Models.DocumentTypes
{
	/// <summary>Product Page</summary>
	[PublishedModel("productPage")]
	public partial class ProductPage : Master, IMetaInfo, IProduct, ISettings
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.5.4")]
		public new const string ModelTypeAlias = "productPage";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.5.4")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.5.4")]
		public new static IPublishedContentType GetModelContentType()
			=> PublishedModelUtility.GetModelContentType(ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.5.4")]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<ProductPage, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(), selector);
#pragma warning restore 0109

		// ctor
		public ProductPage(IPublishedContent content)
			: base(content)
		{ }

		// properties

		///<summary>
		/// Images
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.5.4")]
		[ImplementPropertyType("images")]
		public global::System.Collections.Generic.IEnumerable<global::Umbraco.Core.Models.PublishedContent.IPublishedContent> Images => this.Value<global::System.Collections.Generic.IEnumerable<global::Umbraco.Core.Models.PublishedContent.IPublishedContent>>("images");

		///<summary>
		/// Long Description
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.5.4")]
		[ImplementPropertyType("longDescription")]
		public global::System.Web.IHtmlString LongDescription => this.Value<global::System.Web.IHtmlString>("longDescription");

		///<summary>
		/// SEO Settings
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.5.4")]
		[ImplementPropertyType("SeoSettings")]
		public global::SEOChecker.MVC.MetaData SeoSettings => global::VendrSandbox.Core.Models.DocumentTypes.MetaInfo.GetSeoSettings(this);

		///<summary>
		/// Price: Enter a price for this product in each supported currency.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.5.4")]
		[ImplementPropertyType("price")]
		public global::Vendr.Web.Models.PricePropertyValue Price => global::VendrSandbox.Core.Models.DocumentTypes.Product.GetPrice(this);

		///<summary>
		/// SKU: The unique SKU of this product.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.5.4")]
		[ImplementPropertyType("sku")]
		public string Sku => global::VendrSandbox.Core.Models.DocumentTypes.Product.GetSku(this);

		///<summary>
		/// Hide Children From Navigation: Hides this page's children from the main navigation
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.5.4")]
		[ImplementPropertyType("hideChildrenFromNavigation")]
		public bool HideChildrenFromNavigation => global::VendrSandbox.Core.Models.DocumentTypes.Settings.GetHideChildrenFromNavigation(this);

		///<summary>
		/// Hide From Navigation: Hides the page from the main navigation and sitemap.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.5.4")]
		[ImplementPropertyType("hideFromNavigation")]
		public bool HideFromNavigation => global::VendrSandbox.Core.Models.DocumentTypes.Settings.GetHideFromNavigation(this);
	}
}
