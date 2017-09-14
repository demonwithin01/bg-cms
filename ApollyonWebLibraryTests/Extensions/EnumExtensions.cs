using System;
using System.ComponentModel.DataAnnotations;
using ApollyonWebLibrary.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApollyonWebLibraryTests.Extensions
{
    [TestClass]
    public class EnumExtensionsTests
    {

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Class Members

        enum TestEnum
        {
            [Display( Name = "Test Value 1" )]
            TestValue1 = 1,
            
            [Display( Name = "Test Value 2" )]
            TestValue2 = 2
        }

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Constructor & Intialisation

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        [TestMethod]
        public void EnumExtensions_All()
        {
            Assert.AreEqual( "Test Value 1", TestEnum.TestValue1.GetDisplayText() );
            Assert.AreEqual( "Test Value 2", EnumExtensions.GetDisplayText( TestEnum.TestValue2 as Enum ) );

            Assert.AreEqual( 1, TestEnum.TestValue1.ToInt() );
            Assert.AreEqual( 2, TestEnum.TestValue2.ToInt() );
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
