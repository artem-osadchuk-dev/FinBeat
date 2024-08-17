# Sorted Data API Service

## Task Description

The task is to implement a web service using ASP.NET Core that logs information about incoming requests and responses to a database. The service consists of two main API methods implemented according to REST principles.

### Method 1: Save Data to the Database

This method is designed to save data to the database.

- **Input**: A JSON array in the format:
    ```json
    [
        { "1": "value1" },
        { "5": "value2" },
        { "10": "value32" }
        ...
    ]
    ```
- **Processing**: The input JSON is transformed into an object with the following structure:
    - `code`: An integer representing the code.
    - `value`: A string representing the value.
  
  The resulting array is sorted by the `code` field and saved in the database. The table structure is as follows:
    - `OrderNumber`: A sequential order number.
    - `Code`: The code value.
    - `Value`: The corresponding value.

  Before saving the new data, the existing table entries are cleared.

### Method 2: Retrieve Data from the Database

This method retrieves data from the database and returns it to the client in JSON format.

- **Output**: A JSON array containing:
    - `OrderNumber`: The sequential order number.
    - `Code`: The code value.
    - `Value`: The corresponding value.

  The method also includes the ability to filter the returned data based on various fields.

## Project Structure

The project is organized into several layers to ensure clean architecture principles:

- **Domain Layer**: Contains core business entities and interfaces.
- **Infrastructure Layer**: Handles data persistence, including database configuration and repository implementations.
- **Application Layer**: Contains the business logic and service classes, which coordinate the interaction between the Domain Layer and the Infrastructure Layer.
- **API Layer**: Exposes the API endpoints and handles the web requests.

## Logging

Both requests and responses are logged into the database for monitoring and auditing purposes. Logs include information such as the HTTP method, URL, headers, body, status code, and timestamp.

## Reason for Database Separation
In this project, I've implemented a separation of concerns by utilizing two distinct databases:

### Data Storage Database
This database is dedicated to storing and managing the primary business data required for the application's functionality. It ensures that the core operations of the application are isolated from any auxiliary processes, maintaining optimal performance and security.

### Logging Database
This database is specifically used to log and track all incoming requests and outgoing responses. By separating the logging data from the main business data, we reduce the risk of performance degradation and allow for more specialized database optimizations and maintenance practices. This separation also enhances security by limiting access to sensitive business data while still allowing for detailed logging and monitoring.

The separation of these databases helps in maintaining a clear boundary between business logic and operational logging, which leads to easier scaling, improved security, and better management of each database's workload.

## Installation and Setup

To run the project locally:

1. **Clone the repository**:
    ```bash
    https://github.com/artem-osadchuk-dev/FinBeat.git
    ```
2. **Navigate to the project directory**:
    ```
    cd FinBeat\
    ```
3. **Set up the Docker environment**:
    Make sure you have Docker installed. The project uses Docker Compose to set up the PostgreSQL database.
    ```bash
    docker-compose -f ./src/docker-compose.yml up
    ```

## Usage

Once the service is running, you can interact with it using any API client (e.g., Postman, Curl).

- **Save Data**: Send a POST request to `/api/sorteddata` with a JSON body containing the data to be saved.
- **Retrieve Data**: Send a GET request to `/api/sorteddata` with optional query parameters to filter the results.

## Testing

The project includes unit tests to ensure the correctness of the functionality. Run the tests using:
```bash
dotnet test
```