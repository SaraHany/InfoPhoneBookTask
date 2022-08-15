using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneBook_Application.features.Phone_Book.Queries.GetPhoneBookList;
using System.Threading.Tasks;

namespace PhoneBook_PresentationApi.Endpoint.PhoneBook.Queries
{
    public class GetPhoneBookEndpoint
    {
        private readonly IMediator _mediator;

        public GetPhoneBookEndpoint (IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetPhoneBook")]
        public async Task<List<GetPhoneBookListViewModel>> HandleAsync(CancellationToken cancellationToken)
        {
            var dtos = await _mediator.Send(new GetPhoneBookListQuery());
            return dtos;
        }

    }
}
