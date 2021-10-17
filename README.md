# vfedorov
Федоров Валерий / Цветков Сергей

# How to run
## Build merchandise service container image
From the root of the solution folder run `docker build -f ./src/OzonEdu.MerchandiseApi/Dockerfile -t "merchandise-service:latest" .`
This specific [Dockerfile](src/OzonEdu.MerchandiseApi/Dockerfile) location (inside the project folder) was selected for compatibility with Visual Studio (so the project can be started in the container directly from VS for debugging) 

## Run multi-container using docker compose
From the root of the solution folder run `docker compose -f ./deploy/docker-compose.yml up -d` or simply go to the [deploy](deploy) folder and run `docker compose up -d`
