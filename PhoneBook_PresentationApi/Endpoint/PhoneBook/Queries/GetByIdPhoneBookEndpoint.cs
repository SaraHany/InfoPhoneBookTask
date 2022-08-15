using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneBook_Application.features.Phone_Book.Queries.GetPhoneBookDetails;
using PhoneBook_Application.features.Phone_Book.Queries.GetPhoneBookList;

namespace PhoneBook_PresentationApi.Endpoint.PhoneBook.Queries
{
    public class GetByIdPhoneBookEndpoint
    {
        private readonly IMediator _mediator;

        public GetByIdPhoneBookEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/GetByIdPhoneBook/{id:guid}")]
        public async Task<GetPhoneBookDetailsViewModel> HandleAsync(Guid id, CancellationToken cancellationToken)
        {
            var getEventDetailQuery = new GetPhoneBookDetailsQuery() { PhoneBookId = id };
            return await _mediator.Send(getEventDetailQuery);
        }
    }
}
