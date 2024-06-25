using MediatR;
using TektonLabs.Challenge.Domain.Abstractions;

namespace TektonLabs.Challenge.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>, IBaseCommand
{ }

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
{ }

public interface IBaseCommand
{ }

