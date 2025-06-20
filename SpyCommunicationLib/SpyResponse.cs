
namespace SpyCommunicationLib
{
    /// <summary>
    /// Represents standard response codes for message handling.
    /// </summary>
    public enum ResponseCode
    {
        Empty = 0,
        Success = 200,
        BadRequest = 400,
        Unauthorized = 401,
        NotFound = 404,
        RequestTimeout = 408,
        Error = 500,
    }

    /// <summary>
    /// Represents a generic response containing a status code and content.
    /// </summary>
    /// <typeparam name="T">The type of the response content.</typeparam>
    public class SpyResponse<T> where T : class
    {
        private ResponseCode _code;
        public T? Content { get; set; }

        /// <summary>
        /// Initializes a new instance of the SpyResponse class with default values.
        /// </summary>
        public SpyResponse()
        {
            _code = ResponseCode.Empty;
            Content = null;
        }

        /// <summary>
        /// Gets or sets the response status code.
        /// </summary>
        public ResponseCode Code
        {
            get => _code;
            set
            {
                if (!Enum.IsDefined(typeof(ResponseCode), value))
                    throw new ArgumentOutOfRangeException(nameof(value), "Invalid response code.");
                _code = value;
            }
        }

        /// <summary>
        /// Returns the serialized string representation of the response.
        /// </summary>
        public override string ToString()
        {
            return SpySerializer.SerializeResponse<T>(this);
        }
    }
}
