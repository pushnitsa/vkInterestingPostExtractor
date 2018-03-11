using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VkInterestingPostExtractor;
using VkInterestingPostExtractor.Exceptions;
using VkInterestingPostExtractor.Transmitters;
using VkNet.Model;

namespace Tests
{
    [TestClass]
    public class WallPostFetcherTest
    {
        [TestMethod]
        public void TestSimpleFetch()
        {
            var dateFetcher = CreateDateTimeOffsetFetcher(7);
            
            var postTransmitter = CreateMockedPostTransmitter();

            postTransmitter
                .SetupSequence(r => r.Get(It.IsAny<long>(), It.IsAny<ulong>()))
                .Returns(new List<Post>
                {
                    new Post
                    {
                        Date = DateTime.UtcNow.AddDays(-10)
                    }
                })
                .Returns(new List<Post>
                {
                    new Post
                    {
                        Date = DateTime.UtcNow
                    }
                });
            
            var fetcher = new WallPostFetcher(dateFetcher, postTransmitter.Object);
            
            var res = fetcher.FetchPosts(1);
            
            Assert.AreEqual(1, res.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(DateTimeNullException))]
        public void TestNullDateTime()
        {
            var dateTimeOffset = CreateDateTimeOffsetFetcher(7);
            var postTransmitter = CreateMockedPostTransmitter();

            postTransmitter
                .SetupSequence(r => r.Get(It.IsAny<long>(), It.IsAny<ulong>()))
                .Returns(new List<Post>
                {
                    new Post()
                })
                .Returns(new List<Post>
                {
                    new Post()
                });

            var postFetcher = CreateWallPostFetcher(dateTimeOffset, postTransmitter.Object);

            var posts = postFetcher.FetchPosts(1);
        }

        [TestMethod]
        public void TestCuttingOldPosts()
        {
            var dateTimeOffsetFetcher = CreateDateTimeOffsetFetcher(7);
            var postTransmitter = CreateMockedPostTransmitter();

            postTransmitter
                .SetupSequence(p => p.Get(It.IsAny<long>(), It.IsAny<ulong>()))
                .Returns(new List<Post>
                {
                    new Post
                    {
                        Date = DateTime.UtcNow
                    }
                })
                .Returns(new List<Post>
                {
                    new Post
                    {
                        Date = DateTime.UtcNow.AddDays(-10)
                    },
                    new Post
                    {
                        Date = DateTime.UtcNow.AddDays(-5)
                    }
                })
                .Returns(new List<Post>
                {
                    new Post
                    {
                        Date = DateTime.UtcNow.AddDays(-8)
                    }
                });

            var postFetcher = CreateWallPostFetcher(dateTimeOffsetFetcher, postTransmitter.Object);

            var posts = postFetcher.FetchPosts(1);
            
            Assert.AreEqual(2, posts.Count());
        }

        [TestMethod]
        public void TestPostsOrdering()
        {
            var dateTimeOffsetFetcher = CreateDateTimeOffsetFetcher(7);
            var postTransmitter = CreateMockedPostTransmitter();

            var firstPost = new Post
            {
                Date = DateTime.UtcNow.AddDays(-2)
            };

            var secondPost = new Post
            {
                Date = DateTime.UtcNow
            };

            postTransmitter
                .SetupSequence(p => p.Get(It.IsAny<long>(), It.IsAny<ulong>()))
                .Returns(new List<Post>
                {
                    firstPost
                })
                .Returns(new List<Post>
                {
                    new Post
                    {
                        Date = DateTime.UtcNow.AddDays(-10)
                    },
                    secondPost,
                    new Post
                    {
                        Date = DateTime.UtcNow.AddDays(-8)
                    }
                });

            var postFetcher = CreateWallPostFetcher(dateTimeOffsetFetcher, postTransmitter.Object);

            var posts = postFetcher.FetchPosts(1).ToList();
            
            Assert.AreEqual(2, posts.Count());
            Assert.AreEqual(secondPost.Date, posts[1].Date);
            Assert.AreEqual(firstPost.Date, posts[0].Date);
        }

        private Mock<IPostTransmitter> CreateMockedPostTransmitter()
        {
            return new Mock<IPostTransmitter>();
        }

        private DateTimeOffsetFetcher CreateDateTimeOffsetFetcher(int daysOffset)
        {
            return new DateTimeOffsetFetcher(daysOffset);
        }

        private WallPostFetcher CreateWallPostFetcher(DateTimeOffsetFetcher offsetFetcher, IPostTransmitter postTransmitter)
        {
            return new WallPostFetcher(offsetFetcher, postTransmitter);
        }
    }
}