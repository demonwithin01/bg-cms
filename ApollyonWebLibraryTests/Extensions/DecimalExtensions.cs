using ApollyonWebLibrary.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApollyonWebLibraryTests.Extensions
{
    [TestClass]
    public class DecimalExtensionsTests
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
        public void DecimalExtensions_All()
        {
            Assert.AreEqual( "$10", 10m.ToCurrency() );
            Assert.AreEqual( "$10,000", 10000m.ToCurrency() );

            Assert.AreEqual( "$10", 10.45m.ToCurrency() );
            Assert.AreEqual( "$10,000", 10000.45m.ToCurrency() );

            Assert.AreEqual( "$10.00", 10m.ToCurrency( 2 ) );
            Assert.AreEqual( "$10,000.00", 10000m.ToCurrency( 2 ) );
            
            Assert.AreEqual( "$10.45", 10.45m.ToCurrency( 2 ) );
            Assert.AreEqual( "$10,000.45", 10000.45m.ToCurrency( 2 ) );
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
