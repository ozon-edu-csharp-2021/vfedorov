namespace OzonEdu.MerchandiseService.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MediatR;

    public abstract class Entity<TId> : IEquatable<Entity<TId>>
    {
        private static readonly TId defaultId = default;
        private int? requestedHashCode;

        private TId id;

        public virtual TId Id
        {
            get
            {
                return this.id;
            }
            protected set
            {
                this.id = value;
            }
        }

        #region Domain events

        /// <summary>
        /// Holds domain events assotiated with entity
        /// </summary>
        private List<INotification> domainEvents;

        /// <summary>
        /// Publicly accessible readonly domain events
        /// </summary>
        public IReadOnlyCollection<INotification> DomainEvents => domainEvents?.AsReadOnly();

        /// <summary>
        /// Adds event to the list of domain events
        /// </summary>
        /// <param name="eventItem"></param>
        public void AddDomainEvent(INotification eventItem)
        {
            domainEvents ??= new List<INotification>();
            domainEvents.Add(eventItem);
        }

        /// <summary>
        /// Removes event from the list of domain events
        /// </summary>
        /// <param name="eventItem"></param>
        public void RemoveDomainEvent(INotification eventItem)
        {
            domainEvents?.Remove(eventItem);
        }

        /// <summary>
        /// CLears list of domain events
        /// </summary>
        public void ClearDomainEvents()
        {
            domainEvents?.Clear();
        }

        #endregion Domain events 

        public bool IsTransient()
        {
            return EqualityComparer<TId>.Default.Equals(this.Id, defaultId);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Entity<TId>);  
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!requestedHashCode.HasValue)
                {
                    requestedHashCode = this.Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)
                }

                return requestedHashCode.Value;
            }
            else
            {
                return base.GetHashCode();
            }
        }

        public bool Equals(Entity<TId> other)
        {
            if(other is null)
            {
                return false;
            }

            if(Object.ReferenceEquals(this, other))
            {
                return true;
            }

            if(this.GetType() != other.GetType())
            {
                return false;
            }

            if (other.IsTransient() || this.IsTransient())
            {
                return false;
            }
            else
            {
                return EqualityComparer<TId>.Default.Equals(other.Id, this.Id);
            }
        }

        public static bool operator ==(Entity<TId> left, Entity<TId> right)
        {
            if (Object.Equals(left, null))
            {
                return Object.Equals(right, null) ? true : false;
            }
            else
            {
                return left.Equals(right);
            }
        }

        public static bool operator !=(Entity<TId> left, Entity<TId> right)
        {
            return !(left == right);
        }
    }
}
