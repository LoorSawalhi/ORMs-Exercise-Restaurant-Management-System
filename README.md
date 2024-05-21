# Restaurant Reservation System
Welcome to the Restaurant Reservation System repository! This project utilizes .NET Core 8.0+ to develop a comprehensive solution for managing restaurant reservations efficiently through a console application. The system is designed to facilitate the creation, updating, and deletion of reservations, alongside managing customer and restaurant data effectively.

## Project Overview
This repository houses a console application named RestaurantReservation, along with a class library RestaurantReservation.Db that contains the database context, models, and repositories necessary for data management. Our system is structured to support asynchronous operations.

## Features
The system offers a robust set of features including:

1) CRUD Operations: Create, update, and delete functionalities for handling reservations, customers, and other related entities.
2) Query Capabilities: Specialized methods to retrieve data, such as listing all managers or fetching reservations by customer.
3) Database Interactions: Utilization of Entity Framework Core for managing database views, functions, and stored procedures to encapsulate complex queries and operations.
4) Data Seeding: Initial seeding of tables to facilitate immediate testing and interaction with pre-populated data.

# Entity Relational Modeling
![Alt text](https://github.com/LoorSawalhi/ORMs-Exercise-Restaurant-Management-System/blob/main/ERD.png "Optional title")

The provided Entity-Relationship Diagram (ERD) depicts the database schema for the Restaurant Reservation System. This schema includes several interconnected tables that manage different aspects of the reservation and ordering processes in a restaurant setting:

1) Customers: Stores information about the customers such as first name, last name, email, and phone number.
2) Reservations: Connects customers to their reservations, detailing which table they reserved at a specific restaurant, the reservation date, and the party size.
3) Tables: Contains details about each table within a restaurant, including capacity and which restaurant it belongs to.
4) Restaurants: Holds information on each restaurant, such as name, address, phone number, and opening hours.
5) Employees: Manages data on restaurant employees, including their name, position, and the restaurant they work for.
6) Orders: Links to reservations, detailing orders placed under specific reservations, along with the employee who took the order and the total amount.
7) OrderItems: Connects orders to specific menu items, specifying the quantity of each item ordered.
8) MenuItems: Details the items available on the menu at each restaurant, including name, description, and price.
