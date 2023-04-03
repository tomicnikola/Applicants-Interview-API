namespace InterviewAPI.Services.DocumentService
{
    public class DocumentService : IDocumentService
    {
        private readonly ApplicantsInterviewContext _context;

        public DocumentService(ApplicantsInterviewContext context)
        {
            _context = context;
        }
        public bool AddDocument(Document document)
        {
            _context.Add(document);
            return Save();
        }

        public bool DeleteDocument(Document document)
        {
            _context.Remove(document);
            return Save();
        }

        public bool DocumentExists(int id)
        {
            return _context.Documents.Any(d => d.Id == id);
        }

        public Document? GetDocument(int id)
        {
            var document = _context.Documents.Find(id);
            if (document is null)
                return null;
            return document;
        }

        public ICollection<Document> GetDocuments()
        {
            var documents = _context.Documents.ToList();
            return documents;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateDocument(Document document)
        {
            _context.Update(document);
            return Save();
        }
    }
}
