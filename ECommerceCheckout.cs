using System;
class Program
{
    static void Main(string[] args)
    {
       ECommerceCheckoutClass.OrderCalculator();
    }
}
public class ECommerceCheckoutClass
{
    public static void OrderCalculator()
    {
        Console.WriteLine("Enter Customer Type (Standard, Gold, VIP)");
        var customerType = Console.ReadLine().ToLower();

        Console.WriteLine("Enter Subtotal ($):");
        double subTotal = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter Package Weight (kg):");
        var weight = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Is this International delivery \n(Yes or No)");
        bool isInternational = Console.ReadLine().Trim().ToLower() == "yes";

        Console.WriteLine("Enter Promo Code");
        var promoCode = Console.ReadLine();

        double discountRate = 0.0;
        if (subTotal < 0 || weight <= 0)
        {
            Console.WriteLine("Invalid order output!");
            return;
        }
        if (customerType == "standard")
        {
            if (subTotal > 200)
            {
                discountRate = 0.10;
            }
            else
            {
                discountRate = 0.0;
            }
        }
        else if (customerType == "gold")
        {
            if (subTotal > 150)
            {
                discountRate = 0.15;
            }
            else if (subTotal >= 50)
            {
                discountRate = 0.10;
            }
            else if (subTotal < 50)
            {
                discountRate = 0.0;
            }
        }
        else if (customerType == "vip")
        {
            if (subTotal > 100)
            {
                discountRate = 0.20;
            }
            else if (subTotal <= 100)
            {
                discountRate = 0.10;
            }
        }
        double shippingFee = 0.0;
        if (weight > 10 )
        {
            shippingFee = 25.00;
        }
        else if (weight >= 5)
        {
            shippingFee = 15.00;
        }
        else if (weight < 5)
        {
            shippingFee = 10.00;
        }
        if (isInternational)
        {
            shippingFee += 15.00;
        }
        if (promoCode.Trim().ToLower() == "lawliet123")
        {
            discountRate = 0.30;
        }
        else 
        {
            Console.WriteLine("Invalid promo code.");
        }
        double discountAmount = subTotal * discountRate;
        double finalTotal = (subTotal - discountRate) + shippingFee;
        Console.WriteLine("=== Order Summary ===");
        Console.WriteLine($"Original Subtotal: {subTotal}");
        Console.WriteLine($"Discounted Subtotal: {discountAmount}");
        Console.WriteLine($"Shipping Fee: {shippingFee}");
        Console.WriteLine($"Final Total: {finalTotal}");
    }
}
