# Library Management System (MVC Example)

This is a simple library management system built with ASP.NET Core MVC (.NET 6). It demonstrates basic CRUD operations for books and authors using in-memory lists. The UI is styled with a custom CSS file.

## Features

- **Book Management**: List, view details, create, edit, and delete books.
- **Author Management**: List, view details, create, edit, and delete authors.
- **Home Page**: Quick navigation to books and authors.
- **About Page**: Project description.
- **Responsive Design**: Modern UI with a responsive layout.

## Project Structure

- **Controllers**
  - `BookController`: Handles book operations.
  - `AuthorController`: Handles author operations.
  - `HomeController`: Home, About, Privacy pages.
- **Models**
  - `Book`: Book entity.
  - `Author`: Author entity.
- **ViewModels**
  - `BookViewModel`: Used for book views.
  - `AuthorViewModel`: Used for author views.
- **Views**
  - Book views: List, Details, Create, Edit.
  - Author views: List, Create.
  - Home views: Index, About, Privacy.
  - Shared: Layout and Footer.
- **wwwroot/css/site.css**: Custom styles for the application.

## How to Run

1. Open the solution in Visual Studio 2022.
2. Build and run the project.
3. Navigate using the top menu to manage books and authors.

## Notes

- Data is stored in static lists; changes are not persisted after restart.
- All pages are in Turkish.
- For educational/demo purposes only.