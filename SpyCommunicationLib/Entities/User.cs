
namespace SpyCommunicationLib.Entities
{
    /// <summary>
    /// Represents a user entity with an ID and username.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the unique identifier of the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public string Username { get; set; }
    }
}
