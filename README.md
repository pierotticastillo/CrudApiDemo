# CrudApiDemo - API REST en .NET 10

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

🎯 Una API REST completa para gestión de productos construida con .NET 10, Entity Framework Core y Swagger.

## 🚀 Cómo ejecutar el proyecto

### Requisitos previos
- [.NET 10.0 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) o VS Code
- [SQL Server LocalDB](https://learn.microsoft.com/es-es/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver16)

### Configuración inicial

1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/pierotticastillo/CrudApiDemo.git
   cd CrudApiDemo
   ```

2. **Restaurar paquetes NuGet**
   ```bash
   dotnet restore
   ```

3. **Configurar la base de datos**

   Ejecutar las migraciones de Entity Framework:
   ```bash
   dotnet ef migrations add Initial
   dotnet ef database update
   ```

   O desde la Consola del Administrador de Paquetes en Visual Studio:
   ```bash
   Add-Migration Initial
   Update-Database
   ```

4. **Ejecutar la aplicación**
   ```bash
   dotnet run
   ```

## 📱 Endpoints de la API

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET | `/api/productos` | Obtener todos los productos |
| GET | `/api/productos/{id}` | Obtener un producto por ID |
| POST | `/api/productos` | Crear un nuevo producto |
| PUT | `/api/productos/{id}` | Actualizar un producto |
| DELETE | `/api/productos/{id}` | Eliminar un producto |

## 📖 Documentación de la API

La API incluye documentación interactiva con Swagger. Después de ejecutar la aplicación, visita:

👉 [https://localhost:5001/swagger/index.html](https://localhost:5001/swagger/index.html)

## 📬 Colección para Postman / Bruno

El proyecto incluye una colección lista para importar en [Postman](https://www.postman.com/) o [Bruno](https://www.usebruno.com/):

📁 [`CrudApiDemo.postman_collection.json`](CrudApiDemo.postman_collection.json)

Contiene todos los endpoints preconfigurados con variables de entorno (`baseUrl`). Solo importa el archivo y comienza a probar.

## 🛠 Tecnologías utilizadas

- **.NET 10** - Framework principal
- **Entity Framework Core** - ORM para acceso a datos
- **SQL Server LocalDB** - Base de datos de desarrollo
- **Swagger/OpenAPI** - Documentación de API
- **Minimal APIs** - Enfoque moderno para endpoints

## 📂 Estructura del proyecto

```
CrudApiDemo/
├── Models/               # Modelos de datos
│   ├── AppDbContext.cs   # Contexto de base de datos
│   └── Producto.cs       # Modelo de producto
├── Migrations/           # Migraciones de EF Core
├── Properties/           # Archivos de propiedades
├── appsettings.json      # Configuración
├── Program.cs            # Configuración y endpoints
├── CrudApiDemo.postman_collection.json  # Colección para Postman/Bruno
├── LICENSE               # Licencia MIT
└── README.md             # Este archivo
```

## 🔧 Comandos útiles

- **Crear nueva migración**:
  ```bash
  dotnet ef migrations add NombreDeLaMigracion
  ```

- **Aplicar migraciones pendientes**:
  ```bash
  dotnet ef database update
  ```

- **Revertir última migración**:
  ```bash
  dotnet ef database update LastGoodMigration
  ```

## 📝 Notas adicionales

- La base de datos se configura automáticamente al ejecutar las migraciones
- El proyecto usa inyección de dependencias para el DbContext
- Todos los endpoints devuelven respuestas HTTP apropiadas
- La API está lista para producción con manejo básico de errores

## 📄 Licencia

Este proyecto está bajo la licencia MIT. Consulta el archivo [`LICENSE`](LICENSE) para más detalles.


