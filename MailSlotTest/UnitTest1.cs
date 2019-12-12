using MailSlot;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace MailSlotTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RoundTrip()
        {
            using (var server = new MailslotServer("round_trip"))
            {
                using (var client = new MailslotClient("round_trip"))
                {
                    for (var i = 0; i < 10; i++)
                    {
                        var msg = $"Message {i}";
                        client.SendMessage(msg);
                        var read = server.GetNextMessage();
                        Assert.AreEqual(msg, read);
                    }
                }
            }
        }
    }
}
