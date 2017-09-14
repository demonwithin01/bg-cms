
using System.Diagnostics;

namespace ApollyonWebLibrary.Extensions
{
    public static class StopwatchExtensions
    {

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Constructor & Intialisation

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        /// <summary>
        /// Logs the current stopwatch elapsed seconds to the debug window.
        /// </summary>
        /// <param name="stopwatch">The stopwatch to log to the debug window.</param>
        /// <param name="message">The message to be logged with the elapsed seconds.</param>
        /// <param name="restart">Whether or not to automatically reset the current elapsed seconds.</param>
        public static void Log( this Stopwatch stopwatch, string message, bool restart = true )
        {
            Debug.WriteLine( message + " (" + stopwatch.Elapsed.TotalSeconds + "s)" );

            if ( restart )
            {
                stopwatch.Restart();
            }
        }

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Protected Methods

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Static Methods

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Properties

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Derived Properties

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

    }
}
