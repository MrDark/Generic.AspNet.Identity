namespace Generic.AspNet.Identity
{
    public interface IDbContext<TUser, in TKey> where TUser : IdentityUser<TKey>
    {
        /// <summary>
        /// Create a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        TUser Create(TUser user);

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        TUser Delete(TUser user);

        /// <summary>
        /// Find a user by Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        TUser FindById(TKey userId);

        /// <summary>
        /// Find a user by name
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        TUser FindByName(string userName);

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        TUser Update(TUser user);
    }
}
