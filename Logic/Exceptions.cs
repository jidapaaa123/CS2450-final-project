using System;

public class SolidObjectCollisionException : Exception
{
    public SolidObjectCollisionException()
    {

    }

    public SolidObjectCollisionException(string message) : base(message)
    {

    }

    public SolidObjectCollisionException(string message, Exception inner) : base (message, inner)
    {
        
    }
}