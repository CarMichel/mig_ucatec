# Proyecto UCATEC – Gestión de BD II (p3-csharp-orm)

## 📌 Descripción
Este proyecto corresponde a la **Práctica 3: ORM con C# y PostgreSQL usando Entity Framework Core**.  
El objetivo fue replicar los modelos de la práctica anterior en Python/SQLAlchemy (Usuario y Materia) para comparar enfoques entre tecnologías.

## ⚙️ Configuración del Proyecto

### 1. Stack utilizado
- **.NET 9 Console App**
- **Entity Framework Core 9.0**
- **Npgsql 9.0 (PostgreSQL)**
- **Docker** para levantar la base de datos
- **dotnet-ef** como herramienta de migraciones

### 2. Dependencias en `.csproj`
```
<PackageReference Include="DotNetEnv" Version="2.5.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="9.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="9.0.0" />
<PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="9.0.0" />
```

## 🏗️ Modelos Implementados

### Usuario.cs
- Id → PK, autogenerado
- Nombre → string, NOT NULL
- Email → string, UNIQUE, NOT NULL
- Edad → int?, nullable
- CreadoEn → DateTime, NOT NULL
- ContraseñaHash → string?, nullable
- ActualizadoEn → DateTime, NOT NULL
- NumeroCelular → string?, UNIQUE, nullable

### Materia.cs
- Id → PK, autogenerado
- Nombre → string, NOT NULL, Index
- Descripcion → string?, nullable
- ContenidoMinimo → string?, nullable
- CreadoEn → DateTime, NOT NULL
- ActualizadoEn → DateTime, NOT NULL

## 🚀 Migraciones y Base de Datos

### 1. Crear migración inicial
```
dotnet ef migrations add InitialCreate
```

### 2. Aplicar migración
```
dotnet ef database update
```

### 3. Resultado en PostgreSQL
Tablas creadas:
- `Usuarios`
- `Materias`
- `__EFMigrationsHistory`

Verificado con:
```
\dt
\d "Usuarios"
\d "Materias"
```

## 📝 Inserción y Consulta de Datos

### Insertar en Usuarios
```
INSERT INTO "Usuarios" ("Nombre", "Email", "Edad", "NumeroCelular", "CreadoEn", "ActualizadoEn")
VALUES ('Carlos', 'carlos@ucatec.edu', 22, '77777777', NOW(), NOW());
```

### Consultar Usuarios
```
SELECT * FROM "Usuarios";
```

### Insertar en Materias
```
INSERT INTO "Materias" ("Nombre", "Descripcion", "CreadoEn", "ActualizadoEn")
VALUES ('Gestión BD II', 'Curso de bases de datos avanzadas', NOW(), NOW());
```

### Consultar Materias
```
SELECT * FROM "Materias";
```

## 📋 Historial de Comandos Utilizados

### 🔹 Docker y PostgreSQL
```
docker run --name contenedor_postgreSQL -e POSTGRES_PASSWORD=12345 -e POSTGRES_DB=prueba_csharp -p 3309:5432 -d postgres:latest
docker exec -it contenedor_postgreSQL psql -U postgres -d prueba_csharp
\dt
\d "Usuarios"
\d "Materias"
```

### 🔹 .NET y EF Core
```
dotnet new console -n p3-csharp-orm
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet build
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 🔹 SQL de prueba
```
INSERT INTO "Usuarios" ("Nombre", "Email", "Edad", "NumeroCelular", "CreadoEn", "ActualizadoEn")
VALUES ('Carlos', 'carlos@ucatec.edu', 22, '77777777', NOW(), NOW());

SELECT * FROM "Usuarios";

INSERT INTO "Materias" ("Nombre", "Descripcion", "CreadoEn", "ActualizadoEn")
VALUES ('Gestión BD II', 'Curso de bases de datos avanzadas', NOW(), NOW());

SELECT * FROM "Materias";
```

### 🔹 Git y GitHub
```
git init
git add .
git commit -m "Proyecto C# con EF Core y PostgreSQL"
git branch -M main
git remote add origin https://github.com/CarMichel/mig_ucatec.git
git push -u origin main
```

## 📂 Evidencia del Trabajo Realizado
- Conexión exitosa a PostgreSQL desde C# (`dotnet run` → "Conexión exitosa a PostgreSQL").  
- Migración aplicada correctamente (`InitialCreate`).  
- Tablas verificadas en PostgreSQL con `\dt` y `\d`.  
- Inserciones exitosas usando `NOW()` en columnas obligatorias.  
- Consultas SELECT mostrando registros insertados.  
- Repositorio actualizado en GitHub con la carpeta `p3-csharp-orm`.

## ✔️ Cumplimiento de la Práctica
- Configuración de proyecto en C# ✅  
- Conexión con PostgreSQL vía EF Core ✅  
- Migraciones y creación de tablas ✅  
- Inserción y consulta de datos ✅  
- Documentación y evidencia en README ✅  
- Subida al repositorio GitHub ✅  
