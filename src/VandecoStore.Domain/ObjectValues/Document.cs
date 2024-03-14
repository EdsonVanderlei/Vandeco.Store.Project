using VandecoStore.Domain.ObjectValues.Exceptions;

namespace VandecoStore.Domain.ObjectValues
{
    public readonly struct Document
    {
        public string DocumentNumber { get; }

        public Document(string document)
        {
            InvalidDocumentException.ThrowIfInvalidDocument(false, document);
        }

        public static implicit operator Document(string document) => new Document(document);

        public static implicit operator string(Document document) => document.DocumentNumber;
    }
}
