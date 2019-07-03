namespace SimpleBotCore.Logic
{
    public class SimpleBotUser
    {
        public string Reply(SimpleMessage message)
        {
            Banco.Instance.SalvarMensagem(message);
            var contador = Banco.Instance.ContadorMensagem(message.Id);

            return $"{message.User} disse '{message.Text}'. ({contador} mensagem(ns) enviada(s))";
        }

    }
}
