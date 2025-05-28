
namespace SpyCommunicationLib.Builders
{
    /// <summary>
    /// Builds a SpyMessage specifically for an Administrator sender.
    /// </summary>
    internal class AdminMessageBuilder : AppMessageBuilder
    {
        /// <summary>
        /// Initializes a new instance of the AdminMessageBuilder class.
        /// </summary>
        public AdminMessageBuilder() : base()
        {
        }

        /// <summary>
        /// Sets the sender of the message to Administrator.
        /// </summary>
        public override void SetSender()
        {
            _message.Sender = Sender.Administrator;
        }
    }
}
