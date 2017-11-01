using KadGen.ClassTracker.Domain;

namespace KadGen.ClassTracker.WebApi.ViewModels
{
    public class OrganizationViewModel
    {
        public OrganizationViewModel(Organization organziation)
        {
            Id = organziation.Id;
            Name = organziation.Name;
        }

        public int Id { get;set; }
        public string Name { get; set; }
    }
}
