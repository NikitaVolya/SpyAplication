
using SpyCommunicationLib.Builders;

namespace SpyCommunicationLib.Directors
{
    /// <summary>
    /// Director class for building spy-related messages.
    /// </summary>
    public class SpyMessageDirector
    {
        private SpyMessageBuilder _builder = new SpyMessageBuilder();

        /// <summary>
        /// Creates a message to send data with specified keys.
        /// </summary>
        /// <param name="keys">A collection of integer keys to include in the message.</param>
        /// <returns>A SpyMessage configured to send data with the given keys.</returns>
        public SpyMessage GetSendDataMessage(IEnumerable<int> keys)
        {
            _builder.SetAction(MessageAction.SendData);
            _builder.SetOptions(new Dictionary<string, string>
            {
                { "keys", string.Join(",", keys) }
            });
            return _builder.GetMessage();
        }
    }
}
