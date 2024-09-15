# Welcome to MasterDegree 👋
<p>
  <img alt="Version" src="https://img.shields.io/badge/version-1.0.0-blue.svg?cacheSeconds=2592000" />
  <img src="https://img.shields.io/badge/SQL%20Server-2019-yellow" />
  <img src="https://img.shields.io/badge/ASP.Net-4.7.2-%23790c91" />
  <a href="https://github.com/JoeGitHubPro/MasterDegree/blob/master/MasterDegreeAPIDecomntation.xlsx" target="_blank">
    <img alt="Documentation" src="https://img.shields.io/badge/documentation-yes-brightgreen.svg" />
  </a>
  <a href="https://github.com/kefranabg/readme-md-generator/graphs/commit-activity" target="_blank">
    <img alt="Maintenance" src="https://img.shields.io/badge/Maintained%3F-yes-green.svg" />
  </a>
  <a href="https://github.com/kefranabg/readme-md-generator/blob/master/LICENSE" target="_blank">
    <img alt="License: ASP.Net" src="https://img.shields.io/github/license/JoeGitHubPro/MasterDegree" />
  </a>

</p>
> Master Degree regestration system 

### 🏠 [Homepage](https://github.com/JoeGitHubPro/MasterDegree)
## Documentation

<div>
	
Click button to get Decomntation sheet or vist home page after deploy
	
[<kbd> <br> Decomntation <br> </kbd>][KBD]



</div>

[KBD]: [Types/KBD.md](https://github.com/JoeGitHubPro/MasterDegree/blob/master/MasterDegreeAPIDecomntation.xlsx)

## Prerequisites

- windows OS 
- .Net Framework 
- SQL Server

## Deploy DataBase

```sh
Run SQL file at this location [https://github.com/JoeGitHubPro/MasterDegree/blob/master/MasterDegreeDBSQLQuery.sql] on database server
```

## Deploy

```sh
Go to  Web.config file , then change connectionStrings 
1- put database server name in "Data Source" 
2- put database name in "Initial Catalog"
3- put server site username in "User Id"
4- put server site password in "password"

do those steps twice for "DefaultConnection" and "MasterDegreeEntities1"
```



## Web.config edition part

```sh

 <connectionStrings>
	  <add name="DefaultConnection" connectionString="Data Source=DESKTOP-T4OMHBE\SQLEXPRESS;Initial Catalog=MasterDegree;User Id=sa;Password=123456789" providerName="System.Data.SqlClient" />
    <add name="MasterDegreeEntities1" connectionString="metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=DESKTOP-T4OMHBE\SQLEXPRESS;initial catalog=MasterDegree;integrated security=True;multipleactiveresultsets=True;application name=EntityFramework&quot;" providerName="System.Data.EntityClient" />
    </connectionStrings>
```

## Author

👤 **Youssef Mohamed Ali Mohamed**

* Website: https://joegithubpro.github.io/Profile/
* Twitter: [Y\_mohamed\_Ali](https://x.com/Y_mohamed_Ali)
* Github: [@JoeGitHubPro](https://github.com/JoeGitHubPro)
* LinkedIn: [youssef-mohamed-ali](https://linkedin.com/in/https:\/\/www.linkedin.com\/in\/youssef-mohamed-ali)

## 🤝 Contributing

Contributions, issues and feature requests are welcome!<br />

## Show your support

Give a ⭐️ if this project helped you!

## 📝 License

Copyright © 2023 [Youssef Mohamed Ali Mohamed](https://github.com/JoeGitHubPro).<br />
This project is Proprietary licensed.

