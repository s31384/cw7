namespace cw7.Exeptions;

public class BadRequestExeption : Exception
{
    public BadRequestExeption(string message) :  base(message) 
    {
    } 
}