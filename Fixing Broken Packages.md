If running the project causes build failure try the following things.

1. Go to Tools

2. NuGet Packager Manager -> Package Manager Console

3. Enter: Update-Package -reinstall automapper

4. Enter: Update-Package -reinstall Microsoft.AspNet.WebApi.WebHost

5. Go to bin folder, make sure all files are included (if the file is a silhouette right click and hit "include in project")

6. Make sure files in App_Start are included

7. Make sure files in Views/Results and Views/Survey are included
