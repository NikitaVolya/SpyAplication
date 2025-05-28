
namespace SpyCommunicationLib.Builders
{
    /// <summary>
    /// Builds a SpyMessage specifically for a User sender.
    /// </summary>
    internal class UserMessageBuilder : AppMessageBuilder
    {
        /// <summary>
        /// Initializes a new instance of the UserMessageBuilder class.
        /// </summary>
        public UserMessageBuilder() : base()
        {
        }

        /// <summary>
        /// Sets the sender of the message to User.
        /// </summary>
        public override void SetSender()
        {
            _message.Sender = Sender.User;
        }
    }
}
