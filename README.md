# ProcessRUS_Challenge

## Authentication and Authorization Web API with JWT Token
This is a sample ASP.NET Core Web API project that demonstrates authentication and authorization using the Identity framework with an in-app database. Users can log in to the application using their credentials and obtain a JWT token for authorized access.


## Features
- Authentication and Authorization using Identity framework
- JWT (JSON Web Token) based authentication
- In-app SQLite database for storing user information
- Three pre-configured Identity users: FrontOffice, BackOffice, and Admin
- AccessController with a Get method to retrieve an array of fruit types


## Getting Started


### Prerequisites
.NET 6 SDK or later


### Installation
Clone this repository to your local machine.
Open the project in your preferred IDE or text editor by clicking the ProcessR_Challenge.sln file in the root folder.


## Database Setup
This project uses an in-app SQLite database to store user information. To create the database and apply the initial migrations, run the following command in the terminal or Package Manager Console:

'dotnet ef database update'


### Running the Application
To run the Web API application, use the following command:

'dotnet run'

The application will start on https://localhost:2323 by default.



### Endpoints

##### AuthAPIController Endpoints

- POST /api/auth/register

Description: Register a new user with the application.
Request Body: { "Email": "user@example.com", "Password": "password" }
Response: 200 OK on success.


- POST /api/auth/assignRole

Description: Assign roles to new users.
Request Body: { "Email": "user@example.com", "Password": "password", "Role" : "admin" }
Response: 200 OK on success.


- POST /api/auth/login

Description: Log in with user credentials and get the JWT token.
Request Body: { "Email": "user@example.com", "Password": "password" }
Response: 200 OK with the JWT token on successful login.


##### AccessController Endpoints

- GET /api/access

Description: Get an array of fruit types.
Authorization: Bearer JWT_TOKEN (required for accessing the endpoint)
Response: 200 OK with an array of fruit types.


### Pre-configured Identity Users
The application comes with three pre-configured Identity users:

FrontOffice: User role - "User"

- Username: frontoffice@processrus.com
- Password: Website@1234



BackOffice: User role - "User"

- Username: backoffice@processrus.com
- Password: Website@1234


Admin: User role - "Admin"

- Username: admin@processrus.com
- Password: Website@1234


### Authorization

To access the /api/access endpoint, use the JWT token obtained after successful login in the "Authorization" header as follows:

'Authorization: Bearer YOUR_JWT_TOKEN'

N/B : Only the Admin and Backoffice accounts have access to the /api/access endpoint.


### Additional Notes
This is a sample project and should not be used in production as-is. Make sure to implement proper security measures and validation for a production environment.

Remember to keep sensitive information like database connection strings and JWT secret keys secure and out of version control.

Feel free to explore and extend the functionality of this Web API according to your project requirements.


### License
This project is licensed under the MIT License.

Thank you for checking out this project! If you have any questions or feedback, please feel free to create an issue or contact me. Happy coding!
