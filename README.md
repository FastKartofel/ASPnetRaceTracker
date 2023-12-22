# RaceTrackingAPI

## Overview

RaceTrackingAPI is an ASP.NET Core Web API designed to manage and coordinate race-related data, including race events, cars, and their associations. It leverages Entity Framework Core for robust data handling and interactions with a Microsoft SQL Server database.

## Features

- **Race Management**: Create and manage race events, including date, track name, and difficulty level.
- **Car Tracking**: Handle car data, including models, descriptions, and manufacturers.
- **Race-Car Assignments**: Associate cars with specific races, including driver confirmation status.
- **Data Retrieval**: Retrieve detailed information about races and cars, including relational data between entities.

## Getting Started

### Prerequisites

- .NET Core SDK (version compatible with ASP.NET Core 5/6)
- Microsoft SQL Server
- Entity Framework Core

### Database Setup

- The project employs a Code-First approach with Entity Framework Core, allowing for a database schema to be generated from code.
- To apply the database schema, run Entity Framework Core migrations.
