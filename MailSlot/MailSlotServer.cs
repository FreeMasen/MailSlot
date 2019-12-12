using System;
using System.Text;

namespace MailSlot
{
    public class MailslotServer : IDisposable
    {
        private MailSlot Slot;

        public MailslotServer(string name, string domain = ".")
        {
            Slot = MailSlot.ForServer(domain, name);
        }

        public string GetNextMessage()
        {
            var bytes = Slot.GetNextMessage();

            return Encoding.UTF8.GetString(bytes);
        }

        public void Dispose()
        {
            if (Slot != null)
            {
                ((IDisposable)Slot).Dispose();
            }
        }
    }
}
