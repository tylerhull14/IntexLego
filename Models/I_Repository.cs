﻿namespace IntexLego.Models
{
    public interface I_Repository
    {
        IEnumerable<Product> Products { get; }
    }
}
