
namespace SpyCommunicationLib.Directors
{
    using SpyCommunicationLib.Builders;

    /// <summary>
    /// Director class that manages and applies a token to token-based message builders.
    /// </summary>
    public class TokenMessageDirector
    {
        private string? _token;

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenMessageDirector"/> class with no token set.
        /// </summary>
        public TokenMessageDirector()
        {
            _token = null;
        }

        /// <summary>
        /// Sets the token value to be used for message building.
        /// </summary>
        /// <param name="token">The token string, must not be null or empty.</param>
        /// <exception cref="ArgumentException">Thrown when token is null or empty.</exception>
        public void SetToken(string token)
        {
            if (string.IsNullOrEmpty(token))
                throw new ArgumentException("Token cannot be null or empty.", nameof(token));
            _token = token;
        }

        /// <summary>
        /// Gets the currently set token, or null if none is set.
        /// </summary>
        public string? Token { get => _token; }

        /// <summary>
        /// Configures the token on the given token message builder.
        /// </summary>
        /// <param name="builder">The builder implementing <see cref="ITokenMessageBuilder"/> interface.</param>
        /// <exception cref="InvalidOperationException">Thrown if token has not been set before calling.</exception>
        protected void ConfigureToken(ITokenMessageBuilder builder)
        {
            if (string.IsNullOrEmpty(_token))
                throw new InvalidOperationException("Token is not set. Use SetToken method to set the token.");
            builder.SetToken(_token);
        }
    }
}
