using System;
using System.ComponentModel;

namespace Hypno4Therapy.Site.Web.Mvc.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class UmbracoDisplayAttribute : DisplayNameAttribute
    {
        private readonly string dictionaryKey;

        // This is a positional argument
        public UmbracoDisplayAttribute(string dictionaryKey)
        {
            this.dictionaryKey = dictionaryKey;
        }

        public override string DisplayName
        {
            get
            {
                return UmbracoValidationHelper.UmbracoHelper.GetDictionaryValue(dictionaryKey);
            }
        }
    }
}