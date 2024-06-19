using System.Data;

namespace TektonLabs.Challenge.Application.Abstractions.Data;
public interface ISqlConnectionFactory
{

    IDbConnection CreateConnection();

}

