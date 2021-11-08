namespace OzonEdu.MerchandiseService.Domain.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using OzonEdu.Extensions;

    public class MerchPack : Entity<long>
    {
        protected MerchPack()
        {
            this.packItems = new List<MerchPackItem>();
        }

        public MerchPack(MerchType merchType)
        {
            this.MerchType = merchType;
        }

        /// <summary>
        /// Gets or sets merch pack type
        /// </summary>
        public MerchType MerchType { get; private set; }

        /// <summary>
        /// Holds merch pack items collection of <see cref="MerchPackItem"/>
        /// </summary>
        private readonly List<MerchPackItem> packItems;

        /// <summary>
        /// Holds merch pack items collection of <see cref="MerchPackItem"/>
        /// </summary>
        public IReadOnlyCollection<MerchPackItem> PackItems => this.packItems;

        /// <summary>
        /// Adds item to the pack
        /// </summary>
        /// <param name="item">Item to add</param>
        public void AddPackItem(MerchPackItem item)
        {
            item.ThrowIfNull(nameof(item));

            // TODO should consider transient items here
            var existingItem = packItems.FirstOrDefault(_ => _.Item == item.Item);

            if(existingItem is null)
            {
                existingItem.IncreaseQuantity(item.Qty);
            }
            else
            {
                packItems.Add(item);
            }
        }

        /// <summary>
        /// Removes item from the pack
        /// </summary>
        /// <param name="item">Item to remove</param>
        public void RemovePackItem(MerchPackItem item)
        {
            item.ThrowIfNull(nameof(item));

            // TODO should consider transient items here
            var existingItem = packItems.FirstOrDefault(_ => _.Item == item.Item);

            if(existingItem != null)
            {
                // trying to decrease quantity for the existing item
                if(item.Qty == existingItem.Qty)
                {
                    packItems.Remove(existingItem);
                }
                else
                {
                    existingItem.DecreaseQuantity(item.Qty);
                }
            }
        }
    }
}
