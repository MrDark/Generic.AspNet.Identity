README
===================
Generic implementation of ASP.NET Identity which can be used to quickly add support for exotic database systems or ORM libraries.

I created this as an in-between solution to use ASP.NET Identity in combination with **LLBLGen**. If someone has better ideas on how to do this, feel free to let me know.

How To Use
--------------
Create `IdentityUser<TKey>` implementation. This will be the User class you use throughout your application.
```
public class MyUser : IdentityUser<int>
{
	#region IdentityUser Implementation

    public override int Id { get; }

    public override string UserName { get; set; }

    #endregion
}
```
Create `IDbContext<TUser, TKey>` implementation in which you drop all your database logic. 
```
public class MyDbContext : IDbContext<MyUser, int>
{
    public MyUser Create(MyUser user)
    {
	    return null;
    }

    public MyUser Delete(MyUser user)
    {
  	    return null;
    }

    public MyUser FindById(int userId)
    {
	    return null;
    }

    public MyUser FindByName(string userName)
    {
	    return null;
    }

    public MyUser Update(MyUser user)
    {
	    return null;
    }
}
```

Now we're ready to initialize a new UserManager.
```
new UserManager<MyUser, int>(new UserStore<MyUser, int>(new MyDbContext()))
```