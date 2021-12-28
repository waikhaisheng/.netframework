# **.netframework**
## **netframework**
> Console Application that to name the project

## **WebApplication**
- To view Apis, `Nuget` install `Swashbuckle` for Open Api Swagger, then visit `https://localhost/swagger/ui/index` to view available apis.
![This is an image](/src/swaggerOpenApi.JPG)
- Filters/Attributes
- Exception
- Action filter
- Cors
- JWT

## **Services**
- On `UserService.cs`, `UserLogin` method uses to authenticate users.

## **Database**
- Run sql script at [here](/netframework/netframeworkDbScript.sql) to add `Tables` and `Store Procedures`.
- Add connection string on `Web.config`.
```xml
<configuration>
    <connectionStrings>
        <add name="DefaultConnection" providerName="System.Data.SqlClient" connectionString="Data Source=localhost;Initial Catalog=.DatabaseName;User Id=userid;Password=userpassword;" />
    </connectionStrings>
</configuration>
```

- User table

| Id | Email | PasswordHash | Username | Created | Updated | Deleted |
| --- | --- | --- | --- | --- | --- | --- |
| 00000000-0000-0000-0001-000000000001 | email1@mail.com | 7NcYcNGWMxapfjrDQIyYNa2M8PPBvHA1J8MCZVNPda4= | user1 | 2022-12-31 00:00:01.443 | 2022-12-31 00:00:01.443 | 0 |
| 00000000-0000-0000-0001-000000000002 | email2@mail.com | 7NcYcNGWMxapfjrDQIyYNa2M8PPBvHA1J8MCZVNPda4= | user22 | 2022-12-31 00:00:01.443 | 2022-12-31 00:00:01.443 | 0 |

## **Models**

## **Common**
- Utils
  - On `CryptographyUtil.cs`, methods uses to encrypt or decrypt input string.

<br />

# **Unit Tests**
## **UnitTestProject**
- Common
- Database
- Services
- WebApplication
## **UnitTestCleanup**
> To clean up fail cases cached test data.
<br/>

# 
<details>
<summary>For Education Resources</summary>
<p>

[LICENSE](/LICENSE), for more visit [website](https://demowebapplication-waikhaisheng.azurewebsites.net/)

```javascript
console.log("javascript debug here")
```

</p>
</details>
