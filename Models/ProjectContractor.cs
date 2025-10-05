namespace TeamAlpha.Models
{
    public class ProjectContractor
    {
        public int ProjectId { get; set; }
        public Project? Project { get; set; }

        public int ContractorId { get; set; }
        public Contractor? Contractor { get; set; }
    }
}
