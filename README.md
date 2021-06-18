# HashKiller-API

**Create API Client:**
```C#
HashKiller_API.HashKiller HashKiller = new HashKiller_API.HashKiller();
```

```C#
**Get Password on Hash**
var result = HashKiller.Get(hash);
Console.WriteLine("Password: " + result.Password);
``` 
