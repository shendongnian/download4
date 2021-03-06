        [TestMethod]
        public void ComplexOrOperatorDBTest()
        {
            var allAffectedPosts =
                DatabaseContext.Posts.Where(
                    post =>
                    DatabaseContext.RatePeriods.Any(period => period.From < post.PostDate && period.To > post.PostDate));
            Assert.AreEqual(3, allAffectedPosts.Count());
        }
        [TestMethod]
        public void ComplexOrOperatorTestWithInMemoryObjects()
        {
            var inMemoryRatePeriods = new List<RatePeriod>
                {
                    new RatePeriod {ID = 1000, From = new DateTime(2002, 01, 01), To = new DateTime(2006, 01, 01)},
                    new RatePeriod {ID = 1001, From = new DateTime(1963, 01, 01), To = new DateTime(1967, 01, 01)}
                };
            var allAffectedPosts =
                DatabaseContext.Posts.Where(
                    post => inMemoryRatePeriods.Any(period => period.From < post.PostDate && period.To > post.PostDate));
            Assert.AreEqual(3, allAffectedPosts.Count());
        }
