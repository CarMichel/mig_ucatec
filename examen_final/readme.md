# Examen Final — Gestión y Manejo de Base de Datos II

## 📋 Objetivo
- Crear un contenedor con un RDBMS (PostgreSQL) y definir dos tablas.
- Crear un contenedor con MongoDB e insertar 10 documentos.
- Gestionar todo desde un único archivo `docker-compose.yml`.
- Documentar con capturas de pantalla.

---

## 🚀 Paso 1 — Levantar contenedores con Docker Compose
Comando ejecutado:
```powershell
docker compose up -d
```

Como me salio error, entonces debo limpiar el entorno, incluyendo los datos persistentes. Para ello ejecuto el siguiente comando:

```powershell
docker compose down -v
```
y vuelvo a levantar nuevamente:

```powershell
docker compose up -d
```

Resultado:
![Contenedores activos](imagenes/imagen1.png)

---

## 🗄️ Paso 2 — Base de datos relacional en PostgreSQL

### Conexión al contenedor
```powershell
docker exec -it examen_postgres psql -U admin -d examen_db
```

### Creación de tablas
```
CREATE TABLE clientes (
  id SERIAL PRIMARY KEY,
  nombre VARCHAR(50),
  correo VARCHAR(50)
);

CREATE TABLE pedidos (
  id SERIAL PRIMARY KEY,
  cliente_id INT REFERENCES clientes(id),
  producto VARCHAR(50),
  cantidad INT
);
```
Resultado:
![Tablas creadas](imagenes/imagen2.png)


### Verificación de tablas
```
\dt
```

Resultado:
![Tablas creadas](imagenes/imagen3.png)


### Inserción de registros de prueba
```
INSERT INTO clientes (nombre, correo) VALUES ('Carlos', 'carlos@ucatec.edu');
INSERT INTO pedidos (cliente_id, producto, cantidad) VALUES (1, 'Laptop', 2);
SELECT * FROM clientes;
SELECT * FROM pedidos;
```

Resultado:
![Registros en PostgreSQL](imagenes/imagen4.png)

---

## 🍃 Paso 3 — Base de datos NoSQL en MongoDB

### Conexión al contenedor
```
docker exec -it examen_mongo mongosh -u root -p mongo_secret_pass
```

### Selección de base y creación de colección
```
use examen_mongo
db.registros.insertMany([
  { nombre: "Registro1", valor: 10 },
  { nombre: "Registro2", valor: 20 },
  { nombre: "Registro3", valor: 30 },
  { nombre: "Registro4", valor: 40 },
  { nombre: "Registro5", valor: 50 },
  { nombre: "Registro6", valor: 60 },
  { nombre: "Registro7", valor: 70 },
  { nombre: "Registro8", valor: 80 },
  { nombre: "Registro9", valor: 90 },
  { nombre: "Registro10", valor: 100 }
])
```
Resultado:
![Documentos en MongoDB](imagenes/imagen5.png)


### Verificación de documentos
```
show collections
db.registros.find().pretty()
```

Resultado:
![Documentos en MongoDB](imagenes/imagen6.png)

---

## 📋 Conclusión
- Se levantaron correctamente los contenedores de PostgreSQL y MongoDB.
- Se creó la base `examen_db` con dos tablas (`clientes`, `pedidos`) y registros de prueba.
- Se creó la base `examen_mongo` con la colección `registros` y 10 documentos.
- Todo fue gestionado desde un único archivo `docker-compose.yml`.

---
