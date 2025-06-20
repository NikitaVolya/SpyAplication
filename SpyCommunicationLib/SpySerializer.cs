
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace SpyCommunicationLib
{
    /// <summary>
    /// Provides methods for serializing and deserializing SpyMessage and SpyResponse objects.
    /// </summary>
    public class SpySerializer
    {
        /// <summary>
        /// Internal representation of a message for deserialization.
        /// </summary>
        private record MessageRecord(MessageAction Action, Sender Sender, Dictionary<string, string> Options);

        /// <summary>
        /// Serializes a SpyMessage to a JSON string.
        /// </summary>
        /// <param name="message">The message to serialize.</param>
        /// <returns>JSON string representation of the message.</returns>
        public static string SerializeMessage(SpyMessage message)
        {
            return JsonSerializer.Serialize(message,
            new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
        }

        /// <summary>
        /// Deserializes a JSON string into a SpyMessage object.
        /// </summary>
        /// <param name="json">The JSON string to deserialize.</param>
        /// <returns>The deserialized SpyMessage, or null if input is invalid.</returns>
        public static SpyMessage? DeserializeMessage(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            MessageRecord record;
            try
            {
                record = JsonSerializer.Deserialize<MessageRecord>(json);
            } catch
            {
                return null;
            }

            SpyMessage message = new SpyMessage
            {
                Action = record.Action,
                Sender = record.Sender
            };
            foreach (var option in record.Options)
            {
                message[option.Key] = option.Value;
            }
            return message;
        }

        /// <summary>
        /// Serializes a SpyResponse to a JSON string.
        /// </summary>
        /// <typeparam name="T">Type of the response content.</typeparam>
        /// <param name="response">The response to serialize.</param>
        /// <returns>JSON string representation of the response.</returns>
        public static string SerializeResponse<T>(SpyResponse<T> response) where T : class
        {
            if (response == null)
                throw new ArgumentNullException(nameof(response), "Response cannot be null");
            return JsonSerializer.Serialize(response, new JsonSerializerOptions { IncludeFields = true });
        }

        /// <summary>
        /// Deserializes a JSON string into a SpyResponse with object content.
        /// </summary>
        /// <param name="json">The JSON string to deserialize.</param>
        /// <returns>The deserialized SpyResponse, or null if input is invalid.</returns>
        public static SpyResponse<object>? DeserializeResponse(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                throw new ArgumentException("JSON string cannot be null or empty", nameof(json));
            }
            return JsonSerializer.Deserialize<SpyResponse<object>>(json);
        }

        /// <summary>
        /// Deserializes a JSON string into a typed SpyResponse.
        /// </summary>
        /// <typeparam name="T">Expected type of the response content.</typeparam>
        /// <param name="json">The JSON string to deserialize.</param>
        /// <returns>The deserialized SpyResponse, or null if input is invalid.</returns>
        public static SpyResponse<T>? DeserializeResponse<T>(string json) where T : class
        {
            if (string.IsNullOrEmpty(json))
            {
                throw new ArgumentException("JSON string cannot be null or empty", nameof(json));
            }
            return JsonSerializer.Deserialize<SpyResponse<T>>(json);
        }
    }
}
