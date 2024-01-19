

using MediatR;
using StudioWeb.Domain.Enums;

namespace StudioWeb.Application.UseCases.Customers.Commands;

public class CreateCustomerCommand:IRequest<bool>
{
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public string Budget { get; set; }
    public string EMail { get; set; }
    public string? Comment { get; set; }
    public Status Status { get; set; }

}
