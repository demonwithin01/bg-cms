using System;

namespace ContentManagementSystemDatabase.BaseClasses
{

    public class EntityBase
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        public virtual void Initialise()
        {
            this.IsDeleted = false;
            this.DateCreated = DateTime.Now;
            this.DateUpdated = DateTime.Now;
        }

        public virtual void UpdateTimeStamp()
        {
            this.DateUpdated = DateTime.Now;
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
