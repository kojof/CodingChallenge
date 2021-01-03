using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ConstructionLine.CodingChallenge.Tests
{
    [TestFixture]
    public class SearchEngineTests : SearchEngineTestsBase
    {
        [Test]
        public void Test()
        {
            var shirts = new List<Shirt>
            {
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Medium", Size.Medium, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
            };

            var searchEngine = new SearchEngine(shirts);

            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> {Color.Red},
                Sizes = new List<Size> {Size.Small}
            };

            var results = searchEngine.Search(searchOptions);

            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(shirts, searchOptions, results.ColorCounts);
        }


        [Test]
        public void When_Null_SearchOptions_Expect_Null_SearchResults()
        {
            var shirts = new List<Shirt>
            {
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Medium", Size.Medium, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
            };

            var searchEngine = new SearchEngine(shirts);


            var results = searchEngine.Search(null);

            Assert.AreEqual(null, results.ColorCounts);
            Assert.AreEqual(null, results.Shirts);
            Assert.AreEqual(null, results.SizeCounts);
        }


        [Test]
        public void When_Empty_SearchOptions_Expect_Null_SearchResults()
        {
            var shirts = new List<Shirt>
            {
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Medium", Size.Medium, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
            };

            var searchEngine = new SearchEngine(shirts);

            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> { },
                Sizes = new List<Size> {  }
            };

            var results = searchEngine.Search(searchOptions);

            Assert.AreEqual(null, results.ColorCounts);
            Assert.AreEqual(null, results.Shirts);
            Assert.AreEqual(null, results.SizeCounts);

        }


        [Test]
        public void When_Null_Shirts_Throw_NullArgumentException()
        {
            Assert.Throws<ArgumentNullException>(() => new SearchEngine(null));
        }
    }
}
