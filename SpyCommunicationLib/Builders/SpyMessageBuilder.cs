
namespace SpyCommunicationLib.Builders
{
    /// <summary>
    /// Builds a SpyMessage specifically for a Spy sender.
    /// </summary>
    internal class SpyMessageBuilder : IMessageBuilder
    {
        private SpyMessage _message = new SpyMessage();

        /// <summary>
        /// Initializes a new instance of the SpyMessageBuilder class and sets the sender.
        /// </summary>
        public SpyMessageBuilder()
        {
            SetSender();
        }

        /// <summary>
        /// Resets the builder to its initial state.
        /// </summary>
        public void Reset()
        {
            _message = new SpyMessage();
            SetSender();
        }

        /// <summary>
        /// Sets the sender of the message to Spy.
        /// </summary>
        public void SetSender()
        {
            _message.Sender = Sender.Spy;
        }

        /// <summary>
        /// Sets the action of the message.
        /// </summary>
        /// <param name="action">The message action.</param>
        public void SetAction(MessageAction action)
        {
            _message.Action = action;
        }

        /// <summary>
        /// Sets additional key-value options for the message.
        /// </summary>
        /// <param name="options">A dictionary of message options.</param>
        public void SetOptions(Dictionary<string, string> options)
        {
            foreach (var option in options)
                _message.Add(option.Key, option.Value);
        }

        /// <summary>
        /// Returns the built SpyMessage and resets the builder.
        /// </summary>
        /// <returns>The constructed SpyMessage.</returns>
        public SpyMessage GetMessage()
        {
            SpyMessage rep = _message;
            Reset();
            return rep;
        }
    }
}
