namespace SpyCommunicationLib.Builders
{
    /// <summary>
    /// Builds a SpyMessage with sender, token, action, and options.
    /// </summary>
    internal class AppMessageBuilder : ITokenMessageBuilder, IMessageBuilder
    {
        /// <summary>
        /// The internal message being constructed.
        /// </summary>
        protected SpyMessage _message = new SpyMessage();

        /// <summary>
        /// Initializes a new instance of the AppMessageBuilder class and sets the sender.
        /// </summary>
        public AppMessageBuilder()
        {
            SetSender();
        }

        /// <summary>
        /// Sets the sender of the message. Meant to be overridden by subclasses.
        /// </summary>
        public virtual void SetSender()
        {
            // To be implemented in derived classes
        }

        /// <summary>
        /// Sets the authentication token for the message.
        /// </summary>
        /// <param name="token">The token to assign.</param>
        public void SetToken(string token)
        {
            _message.Token = token;
        }

        /// <summary>
        /// Resets the message to a new instance and sets the sender.
        /// </summary>
        public void Reset()
        {
            _message = new SpyMessage();
            SetSender();
        }

        /// <summary>
        /// Sets the action type of the message.
        /// </summary>
        /// <param name="action">The message action.</param>
        public void SetAction(MessageAction action)
        {
            _message.Action = action;
        }

        /// <summary>
        /// Adds the specified options to the message.
        /// </summary>
        /// <param name="options">A dictionary of key-value option pairs.</param>
        public void SetOptions(Dictionary<string, string> options)
        {
            foreach (var option in options)
                _message.Add(option.Key, option.Value);
        }

        /// <summary>
        /// Returns the built message and resets the builder for reuse.
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
