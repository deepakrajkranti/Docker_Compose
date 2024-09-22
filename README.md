# Learning

# ECommerce API

This project is an ECommerce API built with ASP.NET Core. It includes Docker support for easy deployment and database management.

## Prerequisites

- [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
- [Docker](https://www.docker.com/get-started)
- [Docker Compose](https://docs.docker.com/compose/install/)

## Getting Started

### Clone the Repository# ECommerce API

This project is an ECommerce API built with ASP.NET Core. It includes Docker support for easy deployment and database management.

## Prerequisites

- [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
- [Docker](https://www.docker.com/get-started)
- [Docker Compose](https://docs.docker.com/compose/install/)

## Getting Started

### Clone the Repository

   https://github.com/deepakrajkranti/Docker_Compose.git


### Build and Run with Docker Compose

1. **Build and Run Containers**:
   
       docker-compose up --build


2. **Apply Database Migrations**:

    After the containers are up and running, apply the database migrations:

        docker-compose exec learning bash /app/init-db.sh



### Project Structure

- **Learning**: Contains the ASP.NET Core project.
- **init-db.sh**: Shell script to initialize the database and apply migrations.
- **create-database.sql**: SQL script to create the database.

### API Endpoints

- **POST /api/products**: Create a new product.
  - **Request Body**:
      {
        "id": 1,
         "name": "Product Name",
         "description": "Product Description",
         "price": 100.0
      }

  - **Responses**:
    - `201 Created`: When the product is successfully created.
    - `400 BadRequest`: When the request body is invalid.
    - `500 InternalServerError`: When there is an error creating the product.

### Environment Variables

- **ConnectionStrings__LearningContext**: Connection string for the database.

### Docker Configuration

- **Dockerfile**: Defines the Docker image for the ASP.NET Core application.
- **docker-compose.yml**: Defines the services and their configurations.

### Troubleshooting

- **Database Connection Issues**: Ensure that the SQL Server container is running and accessible.
- **Migrations Not Applied**: Check the logs for any errors during the execution of `init-db.sh`.

### Contributing

Feel free to submit issues or pull requests. For major changes, please open an issue first to discuss what you would like to change.

### License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.



   
