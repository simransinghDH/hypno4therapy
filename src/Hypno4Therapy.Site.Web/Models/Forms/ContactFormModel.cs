using Hypno4Therapy.Site.Web.Mvc.Attributes;

namespace Hypno4Therapy.Site.Web.Models.Forms
{
    public class ContactFormModel
    {
        [UmbracoDisplay("Site.Contact.Labels.Naam")]
        [UmbracoRequired("Site.Contact.Validatie.Naam")]
        public string Name { get; set; }

        [UmbracoDisplay("Site.Contact.Labels.Email")]
        [UmbracoRequired("Site.Contact.Validatie.Email")]
        public string Email { get; set; }

        [UmbracoDisplay("Site.Contact.Labels.Telefoon")]
        [UmbracoRequired("Site.Contact.Validatie.Telefoon")]
        public string Telephone { get; set; }

        [UmbracoDisplay("Site.Contact.Labels.Boodschap")]
        public string Message { get; set; }

        public override string ToString()
        {
            return string.Format("Naam: {0}, Email: {1}, Telefoon: {2}, Boodschap:{3}", Name, Email, Telephone, Message);
        }
    }
}