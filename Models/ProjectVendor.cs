namespace TeamAlpha.Models
{
    public class ProjectVendor
    {
        public int ProjectId { get; set; }
        public Project? Project { get; set; }

        public int VendorId { get; set; }
        public Vendor? Vendor { get; set; }
    }
}
