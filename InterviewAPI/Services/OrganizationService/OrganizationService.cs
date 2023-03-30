namespace InterviewAPI.Services.OrganizationService
{
    public class OrganizationService : IOrganizationService
    {
        private readonly ApplicantsInterviewContext _context;

        public OrganizationService(ApplicantsInterviewContext context)
        {
            _context = context;
        }
        public ICollection<Organization> AddOrganization(Organization organization)
        {
            _context.Organizations.Add(organization);
            _context.SaveChanges();

            return _context.Organizations.ToList();
        }

        public ICollection<Organization>? DeleteOrganization(int id)
        {
            var organization = _context.Organizations.Find(id);
            if (organization is null)
                return null;
            
            _context.Organizations.Remove(organization);
            _context.SaveChanges();

            return _context.Organizations.ToList();
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
            var organization = _context.Organizations.ToList();
            return organization;
        }

        public ICollection<Organization>? UpdateOrganization(Organization organizationRequest)
        {
            var organization = _context.Organizations.Find(organizationRequest.Id);
            if (organization is null)
                return null;

            organization.Code = organizationRequest.Code;
            organization.Name = organizationRequest.Name;
            organization.Description = organizationRequest.Description;

            _context.SaveChanges();
            return _context.Organizations.ToList();
        }
    }
}
