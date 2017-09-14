using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Framework.Models.Page.Sections
{
    public class ContactSection : PageSectionTemplate
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        public void SendEmail()
        {
            MailMessage message = new MailMessage();

            Domain domain = new ContentManagementDb().Domains.Find( UserSession.Current.DomainId );

            if ( string.IsNullOrEmpty( domain.EmailAddress ) )
            {
                return;
            }

            message.To.Add( domain.EmailAddress );
            message.From = new MailAddress( this.EmailAddress );
            message.Subject = "Online Enquiry";

            message.Body = this.Enquiry;

            using ( SmtpClient smtp = new SmtpClient() )
            {
                smtp.Send( message );
            }
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        [Display( Name = "Name" )]
        public string Name { get; set; }

        [Display( Name = "Email" )]
        public string EmailAddress { get; set; }

        [Display( Name = "Enquiry" )]
        public string Enquiry { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
