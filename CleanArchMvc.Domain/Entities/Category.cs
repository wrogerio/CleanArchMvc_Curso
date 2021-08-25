﻿using System.Collections.Generic;
using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : EntityBase
    {
        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id <= 0, "Invalid Id Value");
            Id = id;
            ValidateDomain(name);
        }

        public string Name { get; private set; }

        public ICollection<Product> Products { get; set; }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required!");
            DomainExceptionValidation.When(name != null && name.Length < 3,
                "Invalid name. To short, minimum 3 characters");
            Name = name;
        }
    }
}