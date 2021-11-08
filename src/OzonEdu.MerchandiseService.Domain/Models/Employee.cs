namespace OzonEdu.MerchandiseService.Domain.Models
{
    using System;

    public class Employee : Entity<long>
    {
        public Employee(Email email, FullName fullName)
        {
            this.Email = email;
            this.FullName = fullName;
        }

        public Employee(long id, Email email, FullName fullName) :
            this(email, fullName)
        {
            if(id <= 0L)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            this.Id = id;
        }

        public Email Email { get; private set; }
        public FullName FullName { get; private set; }
    }
}
