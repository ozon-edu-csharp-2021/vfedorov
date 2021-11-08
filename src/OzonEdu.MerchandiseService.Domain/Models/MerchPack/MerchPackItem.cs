namespace OzonEdu.MerchandiseService.Domain.Models
{
    using OzonEdu.Extensions;
    using OzonEdu.MerchandiseService.Domain.Exceptions;

    public class MerchPackItem : Entity<long>
    {
        public MerchPackItem(Item item, Quantity qty)
        {
            item.ThrowIfNull(nameof(item));
            qty.ThrowIfNull(nameof(qty));

            if(qty.Value < 1m)
            {
                throw new MerchDomainException($"Merch pack item quantity cannot be lower than 1");
            }

            this.Item = item;
            this.Qty = qty;
        }

        public Item Item { get; private set; }
        public Quantity Qty { get; private set; }

        public void IncreaseQuantity(Quantity qtyToAdd)
        {
            qtyToAdd.ThrowIfNull(nameof(qtyToAdd));

            if(qtyToAdd.Value < 1m)
            {
                throw new MerchDomainException("Added quantity cannot be lower than 1");
            }

            this.Qty = new (this.Qty.Value + qtyToAdd.Value);
        }

        public void DecreaseQuantity(Quantity qtyToRemove)
        {
            qtyToRemove.ThrowIfNull(nameof(qtyToRemove));

            if(qtyToRemove.Value < 1m)
            {
                throw new MerchDomainException("Removed quantity cannot be lower than 1");
            }

            if(qtyToRemove.Value >= Qty.Value)
            {
                throw new MerchDomainException($"Cannot remove quantity {qtyToRemove} as only {Qty} available");
            }

            this.Qty = new (this.Qty.Value - qtyToRemove.Value);
        }

        public void SetQuantity(Quantity quantity)
        {
            quantity.ThrowIfNull(nameof(quantity));

            if(quantity.Value < 1m)
            {
                throw new MerchDomainException($"Merch pack item quantity cannot be lower than 1");
            }

            this.Qty = quantity;
        }

        public void SetItem(Item item)
        {
            item.ThrowIfNull(nameof(item));

            this.Item = item;
        }
    }
}
