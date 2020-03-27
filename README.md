```bash

cd src/Quakes.Api

dapr run --app-id quakes-api --app-port 5000 --port 3500 dotnet run



cd src/ServiceTracker.Ui

dotnet run

http://localhost:8080



dapr run --app-id service-tracker-ui --app-port 8080 --port 3500 dotnet run

```