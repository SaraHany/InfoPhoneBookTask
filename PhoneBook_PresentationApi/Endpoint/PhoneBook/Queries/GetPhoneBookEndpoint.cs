using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneBook_Application.features.Phone_Book.Queries.GetPhoneBookList;
using System.Threading.Tasks;

namespace PhoneBook_PresentationApi.Endpoint.PhoneBook.Queries
{
    public class GetPhoneBookEndpoint : EndpointBaseAsync.WithoutRequest.WithActionResult<List<GetPhoneBookListViewModel>>
    {
        private readonly IMediator _mediator;

        public GetPhoneBookEndpoint (IMediator mediator)
        {
            _mediator = mediator;
        }

        //public async Task<List<GetPhoneBookListViewModel>> HandleAsync(CancellationToken cancellationToken)
        //{
        //    var dtos = await _mediator.Send(new GetPhoneBookListQuery());
        //    return dtos;
        //}

        [HttpGet("GetPhoneBook")]
        public override async Task<ActionResult<List<GetPhoneBookListViewModel>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            var dtos = await _mediator.Send(new GetPhoneBookListQuery());
            return dtos;
        }
    }
}
