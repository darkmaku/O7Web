// Create by Felix A. Bueno
namespace Angkor.O7Web.Services.Common.Exception
{
    public class ParseException : System.Exception
    {
        protected ParseException(string message) : base(message)
        {
        }

        public static ParseException Make(string message) => new ParseException(message);
    }
}