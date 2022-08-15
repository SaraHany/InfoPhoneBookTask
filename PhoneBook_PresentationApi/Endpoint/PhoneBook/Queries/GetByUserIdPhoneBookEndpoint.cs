using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneBook_Application.features.Phone_Book.Queries.GetPhoneBookByUserID;

namespace PhoneBook_PresentationApi.Endpoint.PhoneBook.Queries
{
    public class GetByUserIdPhoneBookEndpoint : EndpointBaseAsync.WithRequest<string>.WithActionResult<List<GetPhoneBookByUserViewModel>>
    {
        private readonly IMediator _mediator;

        public GetByUserIdPhoneBookEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        //public async Task<List<GetPhoneBookByUserViewModel>> HandleAsync(Guid id, CancellationToken cancellationToken)
        //{
        //    var getEventDetailQuery = new GetPhoneBookByUserQuery() { UserId = id };
        //    return await _mediator.Send(getEventDetailQuery);
        //}

        [HttpGet("/GetByUserIdPhoneBook/{id:guid}")]
        public override async Task<ActionResult<List<GetPhoneBookByUserViewModel>>> HandleAsync([FromRoute] string id, CancellationToken cancellationToken = default)
        {
            var getEventDetailQuery = new GetPhoneBookByUserQuery() { UserId = id };
            return await _mediator.Send(getEventDetailQuery);
        }
    }
}
