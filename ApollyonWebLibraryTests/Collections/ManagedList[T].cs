using System;
using System.Collections.Generic;
using ApollyonWebLibrary.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApollyonWebLibraryTests.Collections
{
    [TestClass]
    public class ManagedListTests
    {
        private bool _isChangeRaised = false;
        private ManagedList<int> _managedList;

        /// <summary>
        /// Handler for notifying Assert that the event was raised.
        /// </summary>
        /// <param name="obj"></param>
        private void HandleCollectionChange( ManagedList<int> obj )
        {
            _isChangeRaised = true;
        }

        /// <summary>
        /// Checks that the is raised variable is now true (meaning the event was fired), and that 
        /// the expected number of items are inside the list.
        /// </summary>
        /// <param name="expectedLength">The expected length of the list.</param>
        private void AssertChangeIsRaised( int expectedLength )
        {
            Assert.IsTrue( _isChangeRaised );
            Assert.AreEqual( expectedLength, _managedList.Count );

            _isChangeRaised = false;
        }
        
        [TestMethod]
        public void ManagedList_CheckCollectionRaiseEvent()
        {
            _managedList = new ManagedList<int>();
            _managedList.CollectionChanged += HandleCollectionChange;

            _managedList.Add( 1 );
            AssertChangeIsRaised( 1 );

            _managedList.AddRange( new List<int>() { 2, 3, 4, 5, 6, 7, 8, 9 } );
            AssertChangeIsRaised( 9 );

            _managedList.Remove( 3 );
            AssertChangeIsRaised( 8 );

            _managedList.RemoveAt( 2 );
            AssertChangeIsRaised( 7 );

            _managedList.Insert( 2, 3 );
            AssertChangeIsRaised( 8 );

            _managedList.RemoveAll( s => s == 3 );
            AssertChangeIsRaised( 7 );

            _managedList.RemoveRange( 2, 3 );
            AssertChangeIsRaised( 4 );

            _managedList.InsertRange( 2, new List<int>() { 1, 2, 3 } );
            AssertChangeIsRaised( 7 );

            _managedList.Clear();
            AssertChangeIsRaised( 0 );


        }
    }
}
