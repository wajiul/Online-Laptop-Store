namespace LaptopStoreAPI.Exceptions
{
   public class DomainNotFoundException: Exception
   {
        public DomainNotFoundException(string message): base(message)
        {
            
        }
   }

    public class DomainExistException : Exception
    {
        public DomainExistException(string message) : base(message)
        {

        }
    }

    public class InvalidModelStateException: Exception
    {
        public InvalidModelStateException(string message): base(message)
        {
            
        }
    }



}
