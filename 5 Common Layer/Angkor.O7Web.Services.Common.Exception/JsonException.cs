// Create by Felix A. Bueno
namespace Angkor.O7Web.Services.Common.Exception
{
    public class JsonException : System.Exception
    {
        public JsonException(string message):base(message)
        { }

        public static JsonException MakeInvalidStructure => new JsonException("Invalid json's structure");
        
    }
}