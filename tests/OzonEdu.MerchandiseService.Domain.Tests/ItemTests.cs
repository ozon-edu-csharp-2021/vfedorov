namespace OzonEdu.MerchandiseService.Domain.Tests
{
    using System;
    using System.Collections.Generic;
    using OzonEdu.MerchandiseService.Domain.Models;
    using OzonEdu.MerchandiseService.Domain.Models.Base;
    using Xunit;

    public class ItemTests
    {
        [Fact]
        public void CreateSuccess()
        {
            // arrange
            var name = new Name("Some item");
            var itemType = ItemType.Bag;

            // act
            var item = new Item(itemType, name);

            // assert
            Assert.NotNull(item);
        }

        [Theory]
        [MemberData(nameof(ItemsData))]
        public void CreateAndCheckProperties(Name name, ItemType itemType)
        {
            // act
            var item = new Item(itemType, name);

            // assert
            Assert.Equal(name, item.Name);
            Assert.Equal(itemType, item.ItemType);
        }

        [Fact]
        public void CreateNameNull()
        {
            var itemType = ItemType.Bag;

            // assert
            Assert.Throws<ArgumentNullException>(() => new Item(itemType, null));
        }

        [Fact]
        public void CreateItemTypeNull()
        {
            var name = new Name("Some name");

            // assert
            Assert.Throws<ArgumentNullException>(() => new Item(null, name));
        }

        [Fact]
        public void SetName()
        {
            // arrange
            var name = new Name("Some item");
            var itemType = ItemType.Bag;
            var newName = new Name("Some item changed");
            var item = new Item(itemType, name);

            // act
            item.SetName(newName);

            // assert
            Assert.Equal(newName, item.Name);
        }

        [Fact]
        public void SetNameNull()
        {
            // arrange
            var name = new Name("Some item");
            var itemType = ItemType.Bag;
            var item = new Item(itemType, name);

            // assert
            Assert.Throws<ArgumentNullException>(() => item.SetName(null));
        }

        [Fact]
        public void SetItemType()
        {
            // arrange
            var name = new Name("Some item");
            var itemType = ItemType.Bag;
            var newItemType = ItemType.Socks;
            var item = new Item(itemType, name);

            // act
            item.SetItemType(newItemType);

            // assert
            Assert.Equal(newItemType, item.ItemType);
        }

        [Fact]
        public void SetItemTypeNull()
        {
            // arrange
            var name = new Name("Some item");
            var itemType = ItemType.Bag;
            var item = new Item(itemType, name);

            // assert
            Assert.Throws<ArgumentNullException>(() => item.SetItemType(null));
        }

        public static IEnumerable<object[]> ItemsData =>
            new List<object[]>
            {
                new object[] { new Name("The first item"), ItemType.Bag },
                new object[] { new Name("The second item"), ItemType.TShirt },
                new object[] { new Name("The third item"), ItemType.Sweatshirt },
                new object[] { new Name("The fourth item"), ItemType.Pen },
            };
    }
}
