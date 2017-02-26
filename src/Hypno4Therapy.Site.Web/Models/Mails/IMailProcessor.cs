using Hypno4Therapy.Site.Web.Models.Forms;
using System.Threading.Tasks;

namespace Hypno4Therapy.Site.Web.Models.Mails
{
    public interface IMailProcessor
    {
        bool Send(ContactFormModel contactFormModel);
    }
}