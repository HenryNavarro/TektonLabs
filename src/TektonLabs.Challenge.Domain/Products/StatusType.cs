using TektonLabs.Challenge.Domain.Abstranctions;

namespace TektonLabs.Challenge.Domain.Products;

public record StatusType(int Code, string Name)
{
    public static readonly StatusType Inactivo = new(0, "INACTIVO");
    public static readonly StatusType Activo = new(1, "ACTIVO");

    public static Result<StatusType> Create(int code, string name="")
    {
        return new StatusType(code, name);
    }
}


