namespace InterviewAPI.Services.TestService
{
    public class TestService : ITestService
    {
        private readonly ApplicantsInterviewContext _context;

        public TestService(ApplicantsInterviewContext context)
        {
            _context = context;
        }
        public ICollection<Test> AddTest(Test test)
        {
            _context.Tests.Add(test);
            _context.SaveChanges();

            return _context.Tests.ToList();
        }

        public ICollection<Test>? DeleteTest(int id)
        {
            var test = _context.Tests.Find(id);
            if (test is null)
                return null;

            _context.Tests.Remove(test);
            _context.SaveChanges();

            return _context.Tests.ToList();
        }

        public Test? GetTest(int id)
        {
            var test = _context.Tests.Find(id);
            if (test is null)
                return null;
            return test;
        }

        public ICollection<Test> GetTests()
        {
            var tests = _context.Tests.ToList();
            return tests;
        }

        public ICollection<Test>? UpdateTest(Test testRequest)
        {
            var test = _context.Tests.Find(testRequest.Id);
            if (test is null)
                return null;

            test.Code = testRequest.Code;
            test.Duration = testRequest.Duration;
            test.MaxScore = testRequest.MaxScore;

            _context.SaveChanges();
            return _context.Tests.ToList();
        }
    }
}
