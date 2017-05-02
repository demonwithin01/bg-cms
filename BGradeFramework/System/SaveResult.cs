using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystem.Framework
{
    //TODO: Replace with one in BGrade Library?
    /// <summary>
    /// Defines the result of a save action.
    /// </summary>
    public class SaveResult
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        /// <summary>
        /// Creates a new save result with the provided state.
        /// </summary>
        /// <param name="state">The state of the save.</param>
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
            return State.GetDescription();
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

        /// <summary>
        /// Gets the save state result.
        /// </summary>
        public SaveResultState State { get; private set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Static Methods

        /// <summary>
        /// Creates a new instance of a save result that states the save was successful.
        /// </summary>
        public static SaveResult Success { get { return new SaveResult( SaveResultState.Success ); } }

        /// <summary>
        /// Creates a new instance of a save result that states the save failed due to a non-categorised issue.
        /// </summary>
        public static SaveResult Fail { get { return new SaveResult( SaveResultState.Fail ); } }

        /// <summary>
        /// Creates a new instance of a save result that states the save failed due to access being denied.
        /// </summary>
        public static SaveResult AccessDenied { get { return new SaveResult( SaveResultState.AccessDenied ); } }

        /// <summary>
        /// Creates a new instance of a save result that states the save failed due to the current domain being different to the one requested.
        /// </summary>
        public static SaveResult IncorrectDomain { get { return new SaveResult( SaveResultState.IncorrectDomain ); } }

        /// <summary>
        /// Creates a new instance of a save result that states the save failed due to invalid write permissions.
        /// </summary>
        public static SaveResult WriteFailure { get { return new SaveResult( SaveResultState.InvalidWritePermissions ); } }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
