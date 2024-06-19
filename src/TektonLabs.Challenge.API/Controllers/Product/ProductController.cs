using MediatR;
using Microsoft.AspNetCore.Mvc;
using TektonLabs.Challenge.Application.Products.CreateProduct;
using TektonLabs.Challenge.Application.Products.Get;
using TektonLabs.Challenge.Application.Products.Update;

namespace TektonLabs.Challenge.API.Controllers.Product;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly ISender _sender;

    public ProductsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(
        int id,
        CancellationToken cancellationToken
    )
    {
        var query = new GetProductQuery(id);
        var result = await _sender.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
         CreateProductCommand request,
         CancellationToken cancellationToken
     )
    {
        var result = await _sender.Send(request, cancellationToken);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] UpdateProductRequest request,
         CancellationToken cancellationToken
     )
    {
        var command = new UpdateProductCommand(id, request.Name, request.Description, request.Stock, request.Price, request.Status);
        var result = await _sender.Send(command);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result);
    }

}