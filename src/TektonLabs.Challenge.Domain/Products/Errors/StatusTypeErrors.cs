using TektonLabs.Challenge.Domain.Abstranctions;

namespace TektonLabs.Challenge.Domain.Products.Errors;
public static class StatusTypeErrors
{
    public static Error NotExist = new Error("StatusType", "El Tipo de Estado no existe.");

}

