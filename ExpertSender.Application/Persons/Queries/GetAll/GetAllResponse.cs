using ExpertSender.Application.Persons.ViewModels;

namespace ExpertSender.Application.Persons.Queries.GetAll;

public class GetAllResponse
{
    public List<PersonViewModel> Persons { get; set; }
}
