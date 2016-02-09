using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystem.Framework
{
    public class SaveResult
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        private SaveResult( SaveResultState state )
        {
            this.State = state;
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        /// <summary>
        /// Primarily, this override is to aid debugging.
        /// </summary>
        public override string ToString()
        {
            switch ( State )
            {
                case SaveResultState.Success:
                    return "Succeeded";
                case SaveResultState.Fail:
                    return "Failed";
                case SaveResultState.AccessDenied:
                    return "Access was Denied";
                case SaveResultState.IncorrectDomain:
                    return "Incorrect Domain";
            }

            return base.ToString();
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Static Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        public SaveResultState State { get; private set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Static Methods

        public static SaveResult Success { get { return new SaveResult( SaveResultState.Success ); } }

        public static SaveResult Fail { get { return new SaveResult( SaveResultState.Fail ); } }

        public static SaveResult AccessDenied { get { return new SaveResult( SaveResultState.AccessDenied ); } }

        public static SaveResult IncorrectDomain { get { return new SaveResult( SaveResultState.IncorrectDomain ); } }

        public static SaveResult WriteFailure { get { return new SaveResult( SaveResultState.WritePermissionsFailed ); } }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
