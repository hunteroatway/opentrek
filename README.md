# OpenTrek
OpenTrek is an open-source web application for finding interesting recommendations for travel destinations. OpenTrek provides users with an interactive map to display and save location-based recommendations, facts or interesting tips for countries they might be interested in travelling to or visiting. 

OpenTrek was designed and developed by Hunter Oatway (200378986) and Corey Safinuk (200375142) for our CS476 - Software Development Project class in the Winter 2021 term. 

## Software Design

OpenTrek uses the ASP.NET MVC software architecture as the basis for its design implementation. Using the Model-View-Controller (MVC) software architecture we were able to quickly scaffold new pages and features to build out the application. ASP.NET Core enabled us to quickly and efficiently link our web application to an Azure SQL database enabling for fast and efficient managment of are data.

OpenTrek uses the LocationIQ API to display and load a map for the user to interactive with. Utilizing the LocationIQ API made it fast and easy to load and display a map, as well as, pull country names and location information when the user clicked on the map. Adding additional map controls, markers and other UI features were seamless and easy using the API.

## Usage

Building and launching the web application locally is fast and easy using the .NET Core 5.0 framework. Ensure you have the .NET Core 5.0 framework installed on your machine. It can be downloaded [here](https://dotnet.microsoft.com/download/dotnet/5.0).

Once the .NET framework has been installed you can clone the repository locally using the following command on a terminal or from the Github Desktop application:
```
git clone https://github.com/hunteroatway/opentrek.git
```

Next, change into the directory where you cloned the project. You will need to add two additional configuration files which will include the LocationIQ API key and the ODBC connection string for your database. 

#### LocationIQ API Key

Loading and displaying the map requires an API key to be used in the API calls to LocationIQ. You will need to create a **config.js** files in the **~/wwwroot/js/** directory with the following variable defined:
```javascript
var config = {
    location_iq_api_key: '<your-api-key-goes-here>'
}
```

#### ODBC Connection String

Connecting to a database using ASP.NET framework requires a connection string to be defined in the **appsettings.json** file. Information on connection strings and how to use them can be found [here](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/working-with-sql?view=aspnetcore-5.0&tabs=visual-studio).

### Building the Application

Building and running the application is simple using the dotnet command-line tools. Ensure your located in the project root directory and then run the following command to build and run the application:
```
dotnet run
```


Running the applcation using the .NET framework tools, starts a local web server listenting on ports 5000 and 5001 that you can view the web application from.
