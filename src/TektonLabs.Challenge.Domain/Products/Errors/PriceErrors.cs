using TektonLabs.Challenge.Domain.Abstranctions;

namespace TektonLabs.Challenge.Domain.Products.Errors;
public static class PriceErrors
{
    public static Error ValueNotRange = new Error("Price.Discount", "El Porcentaje de Descuento debe estar entre 0 - 100");
    public static Error DiscountNotExits = new Error("Price.Discount", "Descuento no existe en Catalogo de Productos");

}

