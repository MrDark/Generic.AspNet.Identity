using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Generic.AspNet.Identity
{
    public class UserStore<TUser, TKey> : IUserStore<TUser, TKey> where TUser : IdentityUser<TKey>
    {
        private bool isDisposed;
        private IDbContext<TUser, TKey> Context { get; set; }

        public UserStore(IDbContext<TUser, TKey> context)
        {
            this.Context = context;
        }

        #region Dispose Implementation

        public void Dispose()
        {
            this.isDisposed = true;
        }

        private void ThrowIfDisposed()
        {
            if (this.isDisposed)
                throw new ObjectDisposedException(this.GetType().Name);
        }

        private void CheckDisposed(TUser user)
        {
            ThrowIfDisposed();
            if (user == null)
                throw new ArgumentNullException("user");
        }

        #endregion

        #region IUserStore Implementation

        public Task CreateAsync(TUser user)
        {
            CheckDisposed(user);

            return Task.FromResult(this.Context.Create(user));
        }

        public Task UpdateAsync(TUser user)
        {
            CheckDisposed(user);

            return Task.FromResult(this.Context.Update(user));
        }

        public Task DeleteAsync(TUser user)
        {
            CheckDisposed(user);

            return Task.FromResult(this.Context.Delete(user));
        }

        public Task<TUser> FindByIdAsync(TKey userId)
        {
            ThrowIfDisposed();

            return Task.FromResult(this.Context.FindById(userId));
        }

        public Task<TUser> FindByNameAsync(string userName)
        {
            ThrowIfDisposed();

            return Task.FromResult(this.Context.FindByName(userName));
        }

        #endregion
    }
}
