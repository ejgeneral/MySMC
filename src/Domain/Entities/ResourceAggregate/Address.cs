﻿using Ardalis.GuardClauses;
using Domain.Common;

namespace Domain.Entities.ResourceAggregate
{
    public class Address : BaseAuditableEntity
    {
        // Related Resource record
        public Guid ResourceId { get; private set; }

        // Address Line 1
        public string Line1 { get; private set; } = string.Empty;

        // Address Line 2
        public string? Line2 { get; private set; }

        // Baranggay
        public string? Baranggay { get; private set; }

        // Municipality/City
        public string Municipality { get; private set; } = string.Empty;

        // Province
        public string Province { get; private set; } = string.Empty;

        // Postal Code / Zip Code
        public string? PostalCode { get; private set; }

        // Country
        public string Country { get; private set; } = string.Empty;

        // True/false indicator if the current address is the primary
        public bool IsPrimary { get; private set; } = false;

        #pragma warning disable CS8618 // Required by Entity Framework
        private Address() { }

        public static Address Create(
            Guid resourceId, 
            string line1, 
            string? line2, 
            string? baranggay, 
            string municipality, 
            string province, 
            string? postalCode, 
            string country,
            bool isPrimary)
        {
            Guard.Against.NullOrEmpty(resourceId, nameof(resourceId));

            var t = new Address();
            t.ResourceId = resourceId;
            t.Line1 = line1;
            t.Line2 = line2;
            t.Baranggay = baranggay;
            t.Municipality = municipality;
            t.Province = province;
            t.PostalCode = postalCode;
            t.Country = country;
            t.IsPrimary = isPrimary;

            return t;
        }
    }
}
