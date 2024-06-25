using MediatR;
using TektonLabs.Challenge.Domain.Abstractions;

namespace TektonLabs.Challenge.Application.Abstractions.Messaging;
public interface IQueryHandler<TQuery, TResponse>
: IRequestHandler<TQuery, Result<TResponse>>
where TQuery : IQuery<TResponse>
{

}
