using TektonLabs.Challenge.Domain.Abstractions;

namespace TektonLabs.Challenge.Domain.Products.Errors;
public static class ProductErrors
{
    public static Error ProductNotExits = new Error("Product", "El producto no existe");

}