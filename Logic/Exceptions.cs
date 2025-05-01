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

public class CannotFeedCatException : Exception
{
    public CannotFeedCatException()
    {

    }

    public CannotFeedCatException(string message) : base(message)
    {

    }

    public CannotFeedCatException(string message, Exception inner) : base (message, inner)
    {
        
    }
}

public class HappyCatException : Exception
{
    public HappyCatException()
    {

    }

    public HappyCatException(string message) : base(message)
    {

    }

    public HappyCatException(string message, Exception inner) : base (message, inner)
    {
        
    }
}