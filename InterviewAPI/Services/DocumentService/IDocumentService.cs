namespace InterviewAPI.Services.DocumentService
{
    public interface IDocumentService
    {
        ICollection<Document> AddDocument(Document document);
        ICollection<Document> GetDocuments();
        Document? GetDocument(int id);
        ICollection<Document>? UpdateDocument(Document documentRequest);
        ICollection<Document>? DeleteDocument(int id);
    }
}
