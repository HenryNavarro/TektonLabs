namespace TektonLabs.Challenge.Domain.Shared;

public record CurrencyType
{
    public static readonly CurrencyType None = new("");
    public static readonly CurrencyType Dolar = new("USD");
    public static readonly CurrencyType Euro = new("EUR");
    public static readonly CurrencyType Sol = new("SOL");
    private CurrencyType(string code) => Code = code;

    public string? Code { get; init; }
    public static readonly IReadOnlyCollection<CurrencyType> All = new[] { Dolar, Euro, Sol };
    public static CurrencyType FromCodigo(string code)
    {
        return All.FirstOrDefault(tm => tm.Code == code) ?? throw new ApplicationException("El tipo de moneda es invalido");
    }
}

