using System;
namespace ArtWorkPromotion.PCL.Models
{
    /// <summary>
    ///     Returned after every user operation on the database
    /// </summary>
    public class UserManagerResponse
    {
        public UserManagerResponse(string message)
        {
            Message = message;
        }

        public UserManagerResponse()
        {

        }

        /// <summary>
        ///     Message with info about the operation carried out on the user in the database
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///     Token Returned from the operation if any e.g. after LogIn 
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        ///     Whether the operation was successful or not
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        ///     A list of errors that might have occurred during the operation
        /// </summary>
        public IEnumerable<string> Errors { get; set; }

        /// <summary>
        ///     Expiry date of the Toke
        /// </summary>
        public DateTime? ExpireDate { get; set; }

        /// <summary>
        /// ID of a particular user
        /// </summary>
        public Guid UserId { get; set; }
    }
}

