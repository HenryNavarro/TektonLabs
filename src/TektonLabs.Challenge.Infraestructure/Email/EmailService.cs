using TektonLabs.Challenge.Application.Abstractions.Email;

namespace TektonLabs.Challenge.Infraestructure.Email;

internal sealed class EmailService : IEmailService
{
    public Task SendAsync(string recipient, string subject, string body)
    {
        return Task.CompletedTask;
    }
}