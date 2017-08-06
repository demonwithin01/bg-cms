using System.Collections.Generic;
using System.Linq;
using ApollyonWebLibrary.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApollyonWebLibraryTests.Extensions
{
    [TestClass]
    public class LinqExtensionsTests
    {

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Class Members

        class TestObject
        {
            public TestObject( int key, string value )
            {
                this.Key = key;
                this.Value = value;
            }

            public int Key { get; set; }

            public string Value { get; set; }
        }

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Constructor & Intialisation

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        [TestMethod]
        public void LinqExtensions_All()
        {
            List<TestObject> testObjs = new List<TestObject>();
            testObjs.Add( new TestObject( 1, "1" ) );
            testObjs.Add( new TestObject( 2, "1" ) );
            testObjs.Add( new TestObject( 2, "2" ) );
            testObjs.Add( new TestObject( 1, "2" ) );

            IQueryable<TestObject> asQueryable = testObjs.AsQueryable();

            Assert.AreEqual( 4, asQueryable.Count() );

            asQueryable = LinqExtensions.DistinctBy( asQueryable, s => s.Key );

            Assert.AreEqual( 2, asQueryable.Count() );
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
