namespace VotingApp.API.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class LoggingAttribute:Attribute
    {
        public string Message { get; private set; }

        public LoggingAttribute(string message)
        {
            Message = message;
        }
    }
}
