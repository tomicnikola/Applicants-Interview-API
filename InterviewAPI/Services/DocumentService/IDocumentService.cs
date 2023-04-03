namespace InterviewAPI.Services.DocumentService
{
    public interface IDocumentService
    {
        bool AddDocument(Document document);
        ICollection<Document> GetDocuments();
        Document? GetDocument(int id);
        bool UpdateDocument(Document document);
        bool DeleteDocument(Document document);
        bool DocumentExists(int id);
        bool Save();
    }
}
