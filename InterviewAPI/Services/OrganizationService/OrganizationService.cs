namespace InterviewAPI.Services.OrganizationService
{
    public class OrganizationService : IOrganizationService
    {
        private readonly ApplicantsInterviewContext _context;

        public OrganizationService(ApplicantsInterviewContext context)
        {
            _context = context;
        }
        public bool AddOrganization(Organization organization)
        {
            _context.Add(organization);
            return Save();
        }

        public bool DeleteOrganization(Organization organization)
        {
            _context.Remove(organization); 
            return Save();
        }

        public Organization? GetOrganization(int id)
        {
            var organization = _context.Organizations.Find(id);
            if (organization is null) 
                return null;
            return organization;
        }

        public ICollection<Organization> GetOrganizations()
        {
            var organizations = _context.Organizations.ToList();
            return organizations;
        }

        public bool OrganizationExists(int id)
        {
            return _context.Organizations.Any(o => o.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateOrganization(Organization organization)
        {
            _context.Update(organization);
            return Save();
        }

    }
}
