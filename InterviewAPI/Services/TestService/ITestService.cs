namespace InterviewAPI.Services.TestService
{
    public interface ITestService
    {
        bool AddTest(Test test);
        ICollection<Test> GetTests();
        Test? GetTest(int id);
        Test? GetTest(string code);
        bool UpdateTest(Test test);
        bool DeleteTest(Test test);
        bool TestExists(int id);
        bool Save();
    }
}
