namespace InterviewAPI.Services.TestService
{
    public class TestService : ITestService
    {
        private readonly ApplicantsInterviewContext _context;

        public TestService(ApplicantsInterviewContext context)
        {
            _context = context;
        }
        public bool AddTest(Test test)
        {
            _context.Add(test);
            return Save();
        }

        public bool DeleteTest(Test test)
        {
            _context.Remove(test);
            return Save();
        }

        public Test? GetTest(int id)
        {
            var test = _context.Tests.Find(id);
            if (test is null)
                return null;
            return test;
        }

        public Test? GetTest(string code)
        {
            var test = _context.Tests.Where(s => s.Code == code).FirstOrDefault();
            if (test is null)
                return null;
            return test;
        }

        public ICollection<Test> GetTests()
        {
            var tests = _context.Tests.ToList();
            return tests;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool TestExists(int id)
        {
            return _context.Tests.Any(t => t.Id == id);
        }

        public bool UpdateTest(Test test)
        {
            _context.Update(test);
            return Save();
        }
    }
}
