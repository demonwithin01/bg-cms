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
            this.UTCDateCreated = DateTime.UtcNow;
            this.UTCDateUpdated = DateTime.UtcNow;
        }

        public virtual void UpdateTimeStamp()
        {
            this.UTCDateUpdated = DateTime.UtcNow;
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        public bool IsDeleted { get; set; }

        public DateTime UTCDateCreated { get; set; }

        public DateTime UTCDateUpdated { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }

}
