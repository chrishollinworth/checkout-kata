﻿namespace CheckoutService
{
    public interface ICheckout
    {
        void Scan(string item);

        int GetTotalPrice();
    }
}