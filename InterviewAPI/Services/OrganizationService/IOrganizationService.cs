namespace InterviewAPI.Services.OrganizationService
{
    public interface IOrganizationService
    {
        bool AddOrganization(Organization organization);
        ICollection<Organization> GetOrganizations();
        Organization? GetOrganization(int id);
        bool UpdateOrganization(Organization organization);
        bool DeleteOrganization(Organization organization);
        bool OrganizationExists(int id);
        bool Save();
    }
}
