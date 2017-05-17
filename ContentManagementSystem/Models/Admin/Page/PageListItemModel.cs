using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentManagementSystem.Framework;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Admin.Models
{
    public class PageListItemModel
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public PageListItemModel( Page page )
        {
            PageContent pageContent = page.PageContent.OrderByDescending( s => s.UTCDateUpdated ).First();

            PageId = page.PageId;
            Title = pageContent.Title;

            LastEditedByName = pageContent.LastEditedByUser.UserName;
            DateUpdated = pageContent.UTCDateUpdated.ToLocalTime();

            bool isPublished = page.PageContent.Count( (Func<PageContent, bool>)(s => s.PublishStatus == PublishStatus.Published) ) > 0;
            bool hasDraft = page.PageContent.Count( (Func<PageContent, bool>)(s => s.PublishStatus == PublishStatus.Draft) ) > 0;

            if ( isPublished && hasDraft )
            {
                PageStatus = "Published / Draft Pending";
            }
            else if ( isPublished )
            {
                PageStatus = "Published";
            }
            else if ( hasDraft )
            {
                PageStatus = "Draft Pending";
            }
            else
            {
                PageStatus = "Not Published, No Draft";
            }
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Static Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        public int PageId { get; set; }

        public string Title { get; set; }

        public DateTime DateUpdated { get; set; }

        public string PageStatus { get; set; }

        public string LastEditedByName { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}