namespace InterviewAPI.Services.TestService
{
    public interface ITestService
    {
        ICollection<Test> AddTest(Test test);
        ICollection<Test> GetTests();
        Test? GetTest(int id);
        ICollection<Test>? UpdateTest(Test testRequest);
        ICollection<Test>? DeleteTest(int id);
    }
}
