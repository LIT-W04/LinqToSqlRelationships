## Linq to Sql Relationships Info
When using Linq to Sql, there are a two steps that are important to remember to do to your web project.

First, in your Web Project, make sure to add a reference to System.Data.Linq.
Second, in your Web.config file, you'll find this: 

```
<compilation debug="true" targetFramework="4.6.1" />
```

Replace that with this:

```
    <compilation debug="true" targetFramework="4.6.1">
      <assemblies>
        <add assembly="System.Data.Linq, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"/>
      </assemblies>
    </compilation>
```    