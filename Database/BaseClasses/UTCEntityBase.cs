using System;

namespace ContentManagementSystemDatabase.BaseClasses
{

    public class UTCEntityBase
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        public virtual void Initialise()
        {
            this.IsDeleted = false;
            this.DateCreated = DateTime.UtcNow;
            this.DateUpdated = DateTime.UtcNow;
        }

        public virtual void UpdateTimeStamp()
        {
            this.DateUpdated = DateTime.UtcNow;
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        public bool IsDeleted { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }

}
