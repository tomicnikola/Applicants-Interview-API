namespace InterviewAPI.Services.OrganizationService
{
    public interface IOrganizationService
    {
        ICollection<Organization> AddOrganization(Organization organization);
        ICollection<Organization> GetOrganizations();
        Organization? GetOrganization(int id);
        ICollection<Organization>? UpdateOrganization(Organization organizationRequest);
        ICollection<Organization>? DeleteOrganization(int id);
    }
}
