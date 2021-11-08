namespace OzonEdu.MerchandiseService.Domain.Models
{
    using OzonEdu.Extensions;
    using OzonEdu.MerchandiseService.Domain.Exceptions;
    using OzonEdu.MerchandiseService.Domain.Models.Base;

    /// <summary>
    /// Represents item entity 
    /// </summary>
    public class Item : Entity<long>
    {
        /// <summary>
        /// Creates instance of <see cref="Item"/>
        /// </summary>
        /// <param name="itemType">Item type</param>
        /// <param name="name">Item name</param>
        public Item(ItemType itemType, Name name)
        {
            itemType.ThrowIfNull(nameof(itemType));
            name.ThrowIfNull(nameof(itemType));

            this.ItemType = itemType;
            this.Name = name;
        }

        /// <summary>
        /// Gets item name
        /// </summary>
        public Name Name { get; private set; }

        /// <summary>
        /// Gets item type
        /// </summary>
        public ItemType ItemType { get; private set; }

        /// <summary>
        /// Sets item type
        /// </summary>
        /// <param name="itemType"></param>
        public void SetItemType(ItemType itemType)
        {
            itemType.ThrowIfNull(nameof(itemType));

            this.ItemType = itemType;
        }

        /// <summary>
        /// Sets item name
        /// </summary>
        /// <param name="name"></param>
        public void SetName(Name name)
        {
            name.ThrowIfNull(nameof(name));

            this.Name = name;
        }

        public void SetId(long id)
        {
            if(!this.IsTransient())
            {
                throw new MerchDomainException("Item ID is already set");                 
            }

            this.Id = id;
        }
    }
}
