using System;
using Newtonsoft.Json;
using ApollyonWebLibrary.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApollyonWebLibraryTests.Converters
{
    [TestClass]
    public class JsonDateConverterTests
    {

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Class Members

        class TestObject
        {
            public DateTime NonNullable { get; set; }

            public DateTime? Nullable { get; set; }
        }

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Constructor & Intialisation

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        [TestMethod]
        public void JsonDateConverter_All()
        {
            JsonDateConverter converter = new JsonDateConverter();
            TestObject testObj = new TestObject();

            Type typeOfDateTime = typeof( DateTime );
            Type typeOfNullableDateTime = typeof( DateTime? );

            Assert.IsTrue( converter.CanConvert( typeOfDateTime ), "Can convert DateTime" );
            Assert.IsTrue( converter.CanConvert( typeOfNullableDateTime ), "Can convert DateTime?" );
            Assert.IsFalse( converter.CanConvert( typeof( object ) ), "Cannot convert object" );

            Assert.IsNull( converter.ReadJson( null, typeOfNullableDateTime, null, null ) );
            Assert.IsNull( converter.ReadJson( null, typeOfNullableDateTime, "lkajsdf as", null ) );
            Assert.IsNotNull( converter.ReadJson( null, typeOfDateTime, null, null ) );
            Assert.IsNotNull( converter.ReadJson( null, typeOfDateTime, "lkajsdf as", null ) );

            Assert.AreEqual( new DateTime( 2017, 5, 4 ), converter.ReadJson( null, typeOfNullableDateTime, "04/05/2017", null ) );
            Assert.AreEqual( new DateTime( 2017, 5, 4 ), converter.ReadJson( null, typeOfDateTime, "04/05/2017", null ) );
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
