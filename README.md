# DocsSystem

**DocsSystem** is an ASP.NET Core MVC project designed to serve as a lightweight, customizable documentation system. 
It dynamically renders Markdown files and utilizes modern js libraries like `Prism.js` for code syntax highlighting, making it ideal for building comprehensive documentation portals.

## Project URL
You can access the project repository here: [DocsSystem on GitHub](https://github.com/navidfaridi/DocsSystem/tree/main).

## Features
- **Dynamic Markdown Rendering**: Read and render Markdown files on the fly.
- **Customizable Code Syntax Highlighting**: Supports syntax highlighting for various programming languages using `Prism.js`.
- **Bootstrap-based Table Styling**: Provides automatic styling for Markdown tables using Bootstrap classes.
- **Simple Structure**: Easy to configure and expand as needed.

## Installation & Setup
1. **Clone the Repository**:
   ```bash
   git clone https://github.com/navidfaridi/DocsSystem.git
   ```
2. **Navigate to the Project Directory**:
   ```bash
   cd DocsSystem
   ```
3. **Restore Dependencies**:
   ```bash
   dotnet restore
   ```
4. **Build and Run the Project**:
   ```bash
   dotnet run
   ```
5. **Access the Application**:
   Open your browser and navigate to:
   ```
   http://localhost:{port}/docs/{YourMarkdownPage}
   ```

## How to Use
- Place your Markdown files in the `wwwroot/docs` directory.
- Access them using the URL pattern: `/docs/{YourMarkdownFileName}`.
- Customize the layout and styles using the Razor Views provided in the project.

## Contribution
Feel free to fork the repository, make your changes, and submit a pull request. Suggestions and contributions are always welcome!
