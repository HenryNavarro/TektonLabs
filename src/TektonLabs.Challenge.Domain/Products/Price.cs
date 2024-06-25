using TektonLabs.Challenge.Domain.Abstractions;
using TektonLabs.Challenge.Domain.Products.Errors;
using TektonLabs.Challenge.Domain.Shared;

namespace TektonLabs.Challenge.Domain.Products;

/// <summary>
/// Entidad Valor Precio
/// </summary>
/// <param name="Value">Precio</param>
/// <param name="DiscountPercent">Descuento [0-100]</param>
/// <param name="CurrencyType">Moneda</param>
public record Price(decimal Value, int DiscountPercent, CurrencyType CurrencyType)
{
    public static Price Zero() => new(0, 0, CurrencyType.None);
    public static Price Zero(int discount) => new(0, discount, CurrencyType.None);
    public static Price Zero(int discount, CurrencyType currencyType) => new(0, discount, currencyType);
    public bool IsZero => this == Zero(DiscountPercent, CurrencyType);

    public static Result<Price> Create(decimal value, int discountPercent)
    {
        return new Price(value, discountPercent, CurrencyType.Sol);
    }
    public static Result<Price> Create(decimal value, int discountPercent, CurrencyType currencyType)
    {
        if (!(discountPercent >= 0 && discountPercent <= 100))
            Result.Failure<Price>(PriceErrors.ValueNotRange);

        return new Price(value, discountPercent, currencyType);
    }

  
    public decimal FinalPrice => Value * (100 - DiscountPercent) / 100;

}


