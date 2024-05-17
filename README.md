# Photolabs C# Backend API

This is a recreation of the backend server from the photolabs repository.  The intent was to recreate the exising functionality using C# and entity such that the frontend of photolabs could be run on this backend server.

https://github.com/MikeDragert/photolabs

# Setup

This was created in Visual Studio 2022.
- Open the solution in visual studio
- Modify the connection string in appsettings.json to the proper settings for your database
  - Note this was tested with a PostgreSQL database
- Run the database migrations
- Update the URL in the appsettings.json to your machines IP address
- Then run with F5 or with the debug menu

- Note: you will then want to clone the original photolabs project and review the readme to run the frontend.
  - https://github.com/MikeDragert/photolabs
  - Special Note:  for the frontend, you will need to modify package.json "proxy" to the IP address of your machine

# Dependencies

- Visual Studio 2022
- C# .NET 7.0
- Entity

