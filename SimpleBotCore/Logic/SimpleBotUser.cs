using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBotCore.Logic
{
    public class SimpleBotUser
    {
        

        public string Reply(SimpleMessage message)
        {
            
            Banco.Instance.SalvarMensagem(message);
            var contador = Banco.Instance.ContadorMsgs(message.Id);

            return $"{message.User} disse '{message.Text}'. ({contador} mensagem(ns) enviada(s))";
        }

    }
}