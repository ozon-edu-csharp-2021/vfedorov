namespace OzonEdu.MerchandiseService.Domain.Tests
{
    using System;
    using System.Collections.Generic;
    using OzonEdu.MerchandiseService.Domain.Exceptions;
    using OzonEdu.MerchandiseService.Domain.Models;
    using OzonEdu.MerchandiseService.Domain.Models.Base;
    using Xunit;

    public class MerchPackItemTests
    {
        [Fact]
        public void CreateSuccess()
        {
            // arrange
            var item = new Item(ItemType.TShirt, new Name("Item"));
            var qty = new Quantity(1);

            // act
            MerchPackItem merchPackItem = new MerchPackItem(item, qty);

            // assert
            Assert.NotNull(merchPackItem);
        }

        [Theory]
        [MemberData(nameof(ItemsData))]
        public void CreateWithPropertiesSuccess(ItemType itemType, Name name, Quantity qty, long itemId)
        {
            // act
            var item = new Item(itemType, name);
            item.SetId(itemId);

            var merchItem = new MerchPackItem(item, qty);

            // assert
            Assert.Equal(item, merchItem.Item);
            Assert.Equal(qty, merchItem.Qty);
        }

        [Fact]
        public void CreateQuantityInvalid()
        {
            // arrange
            var item = new Item(ItemType.TShirt, new Name("Item"));
            var qty = new Quantity(0);

            // act - assert
            Assert.Throws<MerchDomainException>(() => new MerchPackItem(item, qty));
        }

        [Fact]
        public void CreateQuantityNull()
        {
            // arrange
            var item = new Item(ItemType.Bag, new Name("Some"));

            // act - assert
            Assert.Throws<ArgumentNullException>(() => new MerchPackItem(item, null));
        }

        [Fact]
        public void CreateItemNull()
        {
            // arrange
            var qty = new Quantity(10);

            // act - assert
            Assert.Throws<ArgumentNullException>(() => new MerchPackItem(null, qty));
        }


        [Fact]
        public void IncreaseQuantitySuccess()
        {
            // arrange
            var item = new Item(ItemType.Notepad, new Name("Notepad"));
            var qty = new Quantity(10);
            var qtyToAdd = new Quantity(15);
            var qtyExpected = new Quantity(25);
            var merchItem = new MerchPackItem(item, qty);


            // act
            merchItem.IncreaseQuantity(qtyToAdd);

            // assert
            Assert.Equal(qtyExpected, merchItem.Qty);
        }

        [Fact]
        public void IncreaseQuantityInvalidValue()
        {
            // arrange
            var item = new Item(ItemType.Notepad, new Name("Item"));
            var qty = new Quantity(10);
            var qtyToAdd = new Quantity(0);
            var merchItem = new MerchPackItem(item, qty);

            // act - assert
            Assert.Throws<MerchDomainException>(() => merchItem.IncreaseQuantity(qtyToAdd));
        }

        [Fact]
        public void DecreaseQuantitySuccess()
        {
            // arrange
            var item = new Item(ItemType.Notepad, new Name("Notepad"));
            var qty = new Quantity(10);
            var qtyToDecrease = new Quantity(5);
            var qtyExpected = new Quantity(5);
            var merchItem = new MerchPackItem(item, qty);


            // act
            merchItem.DecreaseQuantity(qtyToDecrease);

            // assert
            Assert.Equal(qtyExpected, merchItem.Qty);
        }

        [Fact]
        public void DecreaseQuantityInvalidValue()
        {
            // arrange
            var item = new Item(ItemType.Notepad, new Name("Item"));
            var qty = new Quantity(10);
            var qtyToDecrease = new Quantity(-5);
            var merchItem = new MerchPackItem(item, qty);

            // act - assert
            Assert.Throws<MerchDomainException>(() => merchItem.DecreaseQuantity(qtyToDecrease));
        }

        [Fact]
        public void SetQuantitySuccess()
        {
            // arrange
            var item = new Item(ItemType.Notepad, new Name("Item"));
            var qty = new Quantity(10);
            var qtyToSet = new Quantity(5);
            var merchItem = new MerchPackItem(item, qty);


            // act
            merchItem.SetQuantity(qtyToSet);

            // assert
            Assert.Equal(qtyToSet, merchItem.Qty);
        }

        [Fact]
        public void SetQuantityInvalidValue()
        {
            // arrange
            var item = new Item(ItemType.Pen, new Name("Item"));
            var qty = new Quantity(10);
            var qtyToSet = new Quantity(-7);
            var mwrchItem = new MerchPackItem(item, qty);

            // act - assert
            Assert.Throws<MerchDomainException>(() => mwrchItem.SetQuantity(qtyToSet));
        }

        [Fact]
        public void SetItemSuccess()
        {
            // arrange
            var item = new Item(ItemType.Notepad, new Name("Item"));
            var qty = new Quantity(1);
            var itemToSet = new Item(ItemType.Socks, new Name("Socks"));
            var merchItem = new MerchPackItem(item, qty);

            item.SetId(1);
            itemToSet.SetId(2);

            // act
            merchItem.SetItem(itemToSet);

            // assert
            Assert.Equal(itemToSet, merchItem.Item);
        }

        [Fact]
        public void SetItemTypeNull()
        {
            // arrange
            var item = new Item(ItemType.Pen, new Name("Item"));
            var qty = new Quantity(1);
            var merchItem = new MerchPackItem(item, qty);

            // assert
            Assert.Throws<ArgumentNullException>(() => merchItem.SetItem(null));
        }

        [Fact]
        public void IncreaseQuantityNull()
        {
            // arrange
            var item = new Item(ItemType.Pen, new Name("Name"));
            var qty = new Quantity(1);
            var merchItem = new MerchPackItem(item, qty);

            // assert
            Assert.Throws<ArgumentNullException>(() => merchItem.IncreaseQuantity(null));
        }

        [Fact]
        public void DecreaseQuantityNull()
        {
            // arrange
            var item = new Item(ItemType.Pen, new Name("Item"));
            var qty = new Quantity(1);
            var merchItem = new MerchPackItem(item, qty);

            // assert
            Assert.Throws<ArgumentNullException>(() => merchItem.DecreaseQuantity(null));
        }

        [Fact]
        public void SetQuantityNull()
        {
            // arrange
            var item = new Item(ItemType.Pen, new Name("Item"));
            var qty = new Quantity(1);
            var mwrchItem = new MerchPackItem(item, qty);

            // act - assert
            Assert.Throws<ArgumentNullException>(() => mwrchItem.SetQuantity(null));

        }


        public static IEnumerable<object[]> ItemsData()
        {
            yield return new object[] { ItemType.Notepad, new Name("Notepad item"), new Quantity(10), 1 };
            yield return new object[] { ItemType.Bag, new Name("Bag item"), new Quantity(20), 2 };
            yield return new object[] { ItemType.Sweatshirt, new Name("Sweatshirt item"), new Quantity(1), 3 };
            yield return new object[] { ItemType.TShirt, new Name("T-shirt item"), new Quantity(125), 4 };
        }
    }

}
