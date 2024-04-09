﻿using Intex_Defaults.Infrastructure;
using Intex_Defaults.Models;
using System.Text.Json.Serialization;

namespace Intex_Defaults.Models
{
    public class SessionCart : Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()
                .HttpContext?.Session;

            SessionCart cart = session?.GetJson<SessionCart>("Cart") ??
                new SessionCart();

            cart.Session = session;

            return cart;
        }

        [JsonIgnore]
        public ISession? Session { get; set; }
        public override void AddItem(Product prod, int quantity)
        {
            base.AddItem(prod, quantity);
            Session?.SetJson("Cart", this);
        }

        public override void RemoveLine(Product prod)
        {
            base.RemoveLine(prod);
            Session?.SetJson("Cart", this);
        }

        public override void Clear()
        {
            base.Clear();
        }
    }
}
