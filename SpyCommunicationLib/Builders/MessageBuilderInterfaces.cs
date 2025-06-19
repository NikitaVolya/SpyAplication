
namespace SpyCommunicationLib.Builders
{

    /// <summary>
    /// Defines methods for building a SpyMessage object.
    /// </summary>
    public interface IMessageBuilder
    {
        /// <summary>
        /// Sets the sender of the message.
        /// </summary>
        void SetSender();

        /// <summary>
        /// Sets the action type of the message.
        /// </summary>
        /// <param name="action">The action to assign.</param>
        void SetAction(MessageAction action);

        /// <summary>
        /// Sets custom key-value options for the message.
        /// </summary>
        /// <param name="options">The options dictionary.</param>
        void SetOptions(Dictionary<string, string> options);

        /// <summary>
        /// Returns the fully constructed message.
        /// </summary>
        /// <returns>The built SpyMessage.</returns>
        SpyMessage GetMessage();
    }
}
