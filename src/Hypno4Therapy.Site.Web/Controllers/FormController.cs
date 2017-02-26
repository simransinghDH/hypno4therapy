using Hypno4Therapy.Site.Core.Mails;
using Hypno4Therapy.Site.Web.Models.Forms;
using Hypno4Therapy.Site.Web.Models.Mails;
using System.Collections.Specialized;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace Hypno4Therapy.Site.Web.Controllers
{
    public class FormController : SurfaceController
    {
        private IMailProcessor mailProcessor;

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            mailProcessor = new MailProcessor();
            string result = mailProcessor.Send(model).ToString().ToLowerInvariant();

            var queryString = new NameValueCollection();
            queryString.Add("succes", result);

            return RedirectToCurrentUmbracoPage(queryString);
        }
    }
}