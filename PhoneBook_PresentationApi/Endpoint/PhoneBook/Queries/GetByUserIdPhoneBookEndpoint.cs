using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneBook_Application.features.Phone_Book.Queries.GetPhoneBookByUserID;

namespace PhoneBook_PresentationApi.Endpoint.PhoneBook.Queries
{
    public class GetByUserIdPhoneBookEndpoint
    {
        private readonly IMediator _mediator;

        public GetByUserIdPhoneBookEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/GetByUserIdPhoneBook/{id:guid}")]
        public async Task<List<GetPhoneBookByUserViewModel>> HandleAsync(Guid id, CancellationToken cancellationToken)
        {
            var getEventDetailQuery = new GetPhoneBookByUserQuery() { UserId = id };
            return await _mediator.Send(getEventDetailQuery);
        }
    }
}
