# HashKiller-API

**Create API Client:**
```C#
HashKiller_API.HashKiller HashKiller = new HashKiller_API.HashKiller();
```

**Get Password on Hash**
```C#
var result = HashKiller.Get(hash);
Console.WriteLine("Password: " + result.Password);
``` 
