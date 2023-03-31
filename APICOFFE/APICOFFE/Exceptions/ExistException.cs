namespace APICOFFE.Exceptions
{
    public class ExistException : ApplicationException
    {
        public ExistException(string name, object key)
          : base($"{name} with this: ({key}) exiist in database")
        {
        }

        public ExistException(string message)
            : base(message)
        {
        }
    }
}
