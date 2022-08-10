using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asab_Sanj
{

    public interface IMessage
    {
        void SendMessage(bool language);
    }

    public class MessageEngine
    {
        private readonly IMessage message;
        public MessageEngine(IMessage messageType)
        {
            message = messageType;
        }

        public void Send(bool language)
        {
            message.SendMessage(language);
        }
    }

    public class WinMessage : IMessage
    {
        public string message, caption;
        public void SendMessage(bool language)
        {
            if (language)
            {
                message = "Congragualation";
                caption = "You Win";
            }
            else
            {
                message = "شما برنده شدید";
                caption = "!تبریک";
            }
            MessageBox.Show(message, caption, MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
        }
    }

    public class GameOverMessage : IMessage
    {
        public string message, caption;
        public void SendMessage(bool language)
        {
            if (language)
            {
                message = "Sorry, your lose ";
                caption = "Game Over";
            }
            else
            {
                message = "متاسفانه باختی :(";
                caption = "!باختید";
            }
            MessageBox.Show(message, caption, MessageBoxButtons.OK,
                MessageBoxIcon.Stop);
        }
    }

    public class TimeoutMessage : IMessage
    {
        public string message, caption;
        public void SendMessage(bool language)
        {
            if (language)
            {
                message = "Your time is end!";
                caption = "Game Over";
            }
            else
            {
                message = "!زمان شما به اتمام رسید";
                caption = "!باختید";
            }
            MessageBox.Show(message, caption, MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);
        }
    }

}