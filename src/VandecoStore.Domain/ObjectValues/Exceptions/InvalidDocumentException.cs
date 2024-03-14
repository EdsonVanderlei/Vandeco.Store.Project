namespace VandecoStore.Domain.ObjectValues.Exceptions;

public class InvalidDocumentException : Exception
{
    const string DEFAULT_INVALIDE_EMAIL_MESSAGE_TEMPLATE = "The document number {0} is invalid";

    public InvalidDocumentException(string documentNumber) : base(string.Format(DEFAULT_INVALIDE_EMAIL_MESSAGE_TEMPLATE, documentNumber))
    {

    }

    public static void ThrowIfInvalidDocument(bool valid, string documentNumber)
    {
        if (valid)
        {
            throw new InvalidDocumentException(documentNumber);
        }
    }
}
