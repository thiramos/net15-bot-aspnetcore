namespace SimpleBotCore.Logic
{
    public class SimpleMessage
    {
        public string Id { get; }
        public string User { get; }
        public string Text { get; }

        public SimpleMessage(string id, string username, string text)
        {
            Id = id;
            User = username;
            Text = text;
        }
    }
}
