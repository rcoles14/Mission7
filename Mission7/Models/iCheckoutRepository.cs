using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models
{
    public interface iCheckoutRepository
    {
        public IQueryable<Checkout> Checkouts { get; }

        public void SaveCheckout(Checkout checkout);
    }
}
