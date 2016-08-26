# CORS.Net-HttpModule
Http Module for enabling multiple specific domains with Cross-origin resource sharing. It also allows for specific verbs and whether or not to accept credentials for each site enabled. To Add this to your project you just need to build the solution and add the assembly to the bin folder of the IIS directory for the site. Then you need add the following to the web config

```xml
<configuration>
  <configSections>
    <section name="cors" type="CORS.net_HttpModule.Congifuration.CorsConfig, CorsModule" requirePermission="false"/>
    <!-- other customer config sections -->
  </configSections>
  <cors>
    <sites>
      <site url="http://AllowedOrigin.com" verbs="GET,PUT,POST,DELETE,HEAD,PATCH,OPTIONS" />
      <site url="http://AllowedOrigin2.com" verbs="GET" allowCredentials="true" />
    </sites>
  </cors>
  <system.webServer>
    <modules>
      <add name="CorsModule" type="CORS.net_HttpModule.CorsModule, CorsModule" preCondition="managedHandler"/>
    </modules>
  </system.webServer>
  <!-- Other sections -->
<configuration>

