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

public class GameBoundaryCollisionException : Exception
{
    public GameBoundaryCollisionException()
    {

    }

    public GameBoundaryCollisionException(string message) : base(message)
    {

    }

    public GameBoundaryCollisionException(string message, Exception inner) : base (message, inner)
    {
        
    }
}