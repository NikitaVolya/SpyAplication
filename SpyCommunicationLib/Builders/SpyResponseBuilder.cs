
namespace SpyCommunicationLib.Builders
{
    /// <summary>
    /// Builds a SpyResponse object with a specified response code and content.
    /// </summary>
    /// <typeparam name="T">The type of the response content.</typeparam>
    internal class SpyResponseBuilder<T> where T : class
    {
        private SpyResponse<T> _response = new SpyResponse<T>();

        /// <summary>
        /// Initializes a new instance of the SpyResponseBuilder class.
        /// </summary>
        public SpyResponseBuilder()
        {
        }

        /// <summary>
        /// Resets the builder to a new empty SpyResponse.
        /// </summary>
        public void Reset()
        {
            _response = new SpyResponse<T>();
        }

        /// <summary>
        /// Sets the response code of the SpyResponse.
        /// </summary>
        /// <param name="code">The response code to set.</param>
        public void SetResponseCode(ResponseCode code)
        {
            _response.Code = code;
        }

        /// <summary>
        /// Sets the content of the SpyResponse.
        /// </summary>
        /// <param name="content">The response content to set.</param>
        public void SetContent(T content)
        {
            _response.Content = content;
        }

        /// <summary>
        /// Returns the constructed SpyResponse and resets the builder.
        /// </summary>
        /// <returns>The built SpyResponse object.</returns>
        public SpyResponse<T> GetResponse()
        {
            SpyResponse<T> rep = _response;
            Reset();
            return rep;
        }
    }
}
