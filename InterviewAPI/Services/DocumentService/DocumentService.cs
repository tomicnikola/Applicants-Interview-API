namespace InterviewAPI.Services.DocumentService
{
    public class DocumentService : IDocumentService
    {
        private readonly ApplicantsInterviewContext _context;

        public DocumentService(ApplicantsInterviewContext context)
        {
            _context = context;
        }
        public ICollection<Document> AddDocument(Document document)
        {
            _context.Documents.Add(document);
            _context.SaveChanges();

            return _context.Documents.ToList();
        }

        public ICollection<Document>? DeleteDocument(int id)
        {
            var document = _context.Documents.Find(id);
            if (document is null)
                return null;

            _context.Documents.Remove(document);
            _context.SaveChanges();

            return _context.Documents.ToList();
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

        public ICollection<Document>? UpdateDocument(Document documentRequest)
        {
            var document = _context.Documents.Find(documentRequest.Id);
            if (document is null)
                return null;

            document.Name = documentRequest.Name;
            document.Document1 = documentRequest.Document1;
            document.Url = documentRequest.Url;
            document.LastUpdate = documentRequest.LastUpdate;

            _context.SaveChanges();
            return _context.Documents.ToList();

        }
    }
}
