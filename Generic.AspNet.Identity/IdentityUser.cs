using Microsoft.AspNet.Identity;

namespace Generic.AspNet.Identity
{
    public abstract class IdentityUser<TKey> : IUser<TKey>
    {
        public abstract TKey Id { get; }
        public abstract string UserName { get; set; }
    }
}
