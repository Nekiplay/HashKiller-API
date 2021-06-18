# HashKiller API

**Get Password on Hash:**
```C#
HashKiller_API.HashKiller HashKiller = new HashKiller_API.HashKiller();
var result = HashKiller.Get(hash);
Console.WriteLine("Password: " + result.Password)
```
