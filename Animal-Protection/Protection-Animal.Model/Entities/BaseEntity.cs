﻿using System.ComponentModel.DataAnnotations;

namespace Protection_Animal.Model.Entities
{
    public abstract class BaseEntity<T, TId>
    {
        public TId Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
    }
}
