namespace KadGen.ClassTracker.WebApi.ViewModels
{
    public class TermViewModel
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
