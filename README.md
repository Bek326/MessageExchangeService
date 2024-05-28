message-exchange-service
message-exchange-service is a .NET 8.0 application designed to facilitate message exchange between clients. This Docker image contains everything needed to run the service including a PostgreSQL database.

Requirements
Docker 20.10.0 or later
Docker Compose 1.27.0 or later
Installation and Usage
Using Docker
Pull the image from Docker Hub:
docker pull bek326/messageexchangeservice:latestdocker run -d -p 8080:80 --name messageexchangeservice bek326/messageexchangeservice:latest
