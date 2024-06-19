using MediatR;
using TektonLabs.Challenge.Domain.Abstranctions;

namespace TektonLabs.Challenge.Application.Abstractions.Messaging;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{ }
