using ApollyonWebLibrary.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApollyonWebLibraryTests.Extensions
{
    [TestClass]
    public class BoolExtensionsTests
    {

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Constructor & Intialisation

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        [TestMethod]
        public void BoolExtensions_All()
        {
            Assert.AreEqual( "correct", true.ToString( "correct", "incorrect" ) );
            Assert.AreEqual( "incorrect", false.ToString( "correct", "incorrect" ) );

            Assert.AreEqual( "Yes", true.ToYesNo() );
            Assert.AreEqual( "No", false.ToYesNo() );

            Assert.AreEqual( "true", true.ToJS() );
            Assert.AreEqual( "false", false.ToJS() );

            Assert.AreEqual( "True", true.ToString() );
            Assert.AreEqual( "False", false.ToString() );
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
