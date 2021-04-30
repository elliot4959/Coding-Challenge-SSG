using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Interview
{
    [TestFixture]
    public class Tests
    {
        // Global variables for use in multiple tests
        // Set as constants so no need to worry about issues with mutability
        private const int validId = 1;
        private const int invalidId = 2;
        
        [SetUp]
        public void Setup()
        {
            // Can be used to run code immediately before tests, no need for it here
        }

        [TearDown]
        public void Teardown()
        {
            // Can be used to run code immediately after tests, no need for it here
        }
        
        [Test]
        public void IStorableId_MockedWithValue_ReturnsGivenValue()
        {
            // Arrange - setup quick mock with value for Id property
            Mock<IStoreable> mock = new Mock<IStoreable>();
            mock.Setup(i => i.Id).Returns(validId);
            IStoreable storeable = mock.Object;

            // Assert - check that the Id matches the value we arranged
            Assert.AreEqual(validId, storeable.Id);
        }

        [Test]
        public void All_EmptyList_NotNull()
        {
            // Arrange - create new instance of repository in memory and get all items from it
            InMemoryRepository<IStoreable> repository = new InMemoryRepository<IStoreable>();
            ICollection<IStoreable> collection = repository.All() as ICollection<IStoreable>;

            // Assert - check that the returned collection is not null
            Assert.IsNotNull(collection);
        }

        [Test]
        public void All_EmptyList_IsEmpty()
        {
            // Arrange - create new instance of repository in memory and get all items from it
            InMemoryRepository<IStoreable> repository = new InMemoryRepository<IStoreable>();
            ICollection<IStoreable> collection = repository.All() as ICollection<IStoreable>;

            // Assert - check that the returned collection is empty
            Assert.IsEmpty(collection);
        }

        [Test]
        public void Add_SingleItem_RetunsCorrectCount()
        {
            // Arrange - setup quick mock storable
            Mock<IStoreable> storableMock = new Mock<IStoreable>();
            storableMock.Setup(i => i.Id).Returns(validId);
            IStoreable item = storableMock.Object;

            // Act - save item to repository
            InMemoryRepository<IStoreable> repository = new InMemoryRepository<IStoreable>();
            repository.Save(item);

            // Assert - check that the collection contains exactly one item
            ICollection<IStoreable> collection = repository.All() as ICollection<IStoreable>;
            Assert.AreEqual(1, collection.Count);
        }

        [Test]
        public void Add_SingleItem_ContainsExactItem()
        {
            // Arrange - setup quick mock storable
            Mock<IStoreable> storableMock = new Mock<IStoreable>();
            storableMock.Setup(i => i.Id).Returns(validId);
            IStoreable item = storableMock.Object;

            // Act - save item to repository
            InMemoryRepository<IStoreable> repository = new InMemoryRepository<IStoreable>();
            repository.Save(item);

            // Assert - check that the collection contains the correct item
            ICollection<IStoreable> collection = repository.All() as ICollection<IStoreable>;
            Assert.IsTrue(collection.Contains(item));
        }

        [Test]
        public void Delete_SingleItem_RemovesItemFromRepository()
        {
            // Arrange - setup quick mock storable
            Mock<IStoreable> storableMock = new Mock<IStoreable>();
            storableMock.Setup(i => i.Id).Returns(validId);
            IStoreable item = storableMock.Object;

            // Save the item to the repository
            InMemoryRepository<IStoreable> repository = new InMemoryRepository<IStoreable>();
            repository.Save(item);

            // Act - delete the item from the repository
            repository.Delete(item.Id);

            // Assert - check that the collection does not contain the item
            ICollection<IStoreable> collection = repository.All() as ICollection<IStoreable>;
            Assert.IsFalse(collection.Contains(item));
        }

        [Test]
        public void Delete_InvalidId_RemovesNoItem()
        {
            // Arrange - setup quick mock storable
            Mock<IStoreable> storableMock = new Mock<IStoreable>();
            storableMock.Setup(i => i.Id).Returns(validId);
            IStoreable item = storableMock.Object;

            // Save the item to the repository
            InMemoryRepository<IStoreable> repository = new InMemoryRepository<IStoreable>();
            repository.Save(item);

            // Act - try to delete an invalid item from the repository
            repository.Delete(invalidId);

            // Assert - check that the collection does not contain the item
            ICollection<IStoreable> collection = repository.All() as ICollection<IStoreable>;
            Assert.IsTrue(collection.Contains(item));
        }

        [Test]
        public void FindById_ValidId_ReturnsItem()
        {
            // Arrange - setup quick mock storable
            Mock<IStoreable> storableMock = new Mock<IStoreable>();
            storableMock.Setup(i => i.Id).Returns(validId);
            IStoreable item = storableMock.Object;

            // Save the item to the repository
            InMemoryRepository<IStoreable> repository = new InMemoryRepository<IStoreable>();
            repository.Save(item);

            // Act - find item by Id used
            IStoreable storeable = repository.FindById(item.Id);

            // Assert - check that the storeable variable has a value
            Assert.IsNotNull(storeable);
        }

        [Test]
        public void FindById_ValidId_MatchesItem()
        {
            // Arrange - setup quick mock storable
            Mock<IStoreable> storableMock = new Mock<IStoreable>();
            storableMock.Setup(i => i.Id).Returns(validId);
            IStoreable item = storableMock.Object;

            // Save the item to the repository
            InMemoryRepository<IStoreable> repository = new InMemoryRepository<IStoreable>();
            repository.Save(item);

            // Act - find item by Id used
            IStoreable storeable = repository.FindById(item.Id);

            // Assert - check that the storeable variable has a value
            Assert.AreEqual(item, storeable);
        }

        [Test]
        public void FindById_InvalidId_ReturnsNull()
        {
            // Arrange - setup quick mock storable
            Mock<IStoreable> storableMock = new Mock<IStoreable>();
            storableMock.Setup(i => i.Id).Returns(validId);
            IStoreable item = storableMock.Object;

            // Save the item to the repository
            InMemoryRepository<IStoreable> repository = new InMemoryRepository<IStoreable>();
            repository.Save(item);

            // Act - find item by Id used
            IStoreable storeable = repository.FindById(invalidId);

            // Assert - check that the storeable variable has a value
            Assert.IsNull(storeable);
        }
    }
}