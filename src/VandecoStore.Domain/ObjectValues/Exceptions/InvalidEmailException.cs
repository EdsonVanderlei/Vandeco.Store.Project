﻿namespace VandecoStore.Domain.ObjectValues.Exceptions;

public class InvalidEmailException : Exception
{
    const string DEFAULT_INVALIDE_EMAIL_MESSAGE_TEMPLATE = "The Email Adress {0} is invalid";

    public InvalidEmailException(string emailAdress) : base(string.Format(DEFAULT_INVALIDE_EMAIL_MESSAGE_TEMPLATE, emailAdress))
    {

    }

    public static void ThrowIfInvalidEmail(bool valid, string adress)
    {
        if (!valid)
        {
            throw new InvalidEmailException(adress);
        }
    }
}
