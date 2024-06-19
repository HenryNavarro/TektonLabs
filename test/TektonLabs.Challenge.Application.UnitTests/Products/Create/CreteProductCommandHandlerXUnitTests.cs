namespace TektonLabs.Challenge.Application.UnitTests.Products.Create;
internal sealed class CreteProductCommandHandlerXUnitTests
{
        private readonly Mock<UnitOfWork> _unitOfWork;
    //private readonly Mock<IEmailService> _emailService;
    private readonly Mock<ILogger<CreateProductCommandHandler>> _logger;

    public CreteProductCommandHandlerXUnitTests()
    {
        _unitOfWork = MockUnitOfWork.GetUnitOfWork();

        _emailService = new Mock<IEmailService>();

        _logger = new Mock<ILogger<CreateStreamerCommandHandler>>();


        MockStreamerRepository.AddDataStreamerRepository(_unitOfWork.Object.StreamerDbContext);
    }

    [Fact]
    public async Task CreateStreamerCommand_InputStreamer_ReturnsNumber()
    {
        var streamerInput = new CreateStreamerCommand
        {
            Nombre = "Vaxi Streaming",
            Url = "https://vaxistreaming.com"
        };

        var handler = new CreateStreamerCommandHandler(_unitOfWork.Object, _mapper, _emailService.Object, _logger.Object);

        var result = await handler.Handle(streamerInput, CancellationToken.None);

        result.ShouldBeOfType<int>();
    }
}
