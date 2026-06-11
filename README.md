# Proyecto UCATEC - Django + MySQL + ORM

## 📌 Configuración del entorno
- Contenedor Docker: `mig_python_ucatec`
- Puerto: `3310`
- Base de datos: `ventas_db`
- Usuario: `ucatec_user`
- Password: `Password123!`

## 📌 Pasos realizados
1. Creación del proyecto Django:
   ``` powershell
   django-admin startproject ventas_ucatec
   ```

2. Creación de la aplicación productos:
    ``` powershell
    python manage.py startapp productos
    ```

3. Configuración de settings.py para conexión MySQL.

4. Activación de entorno virtual e instalación de dependencias:
    ``` powershell
    pip install django mysqlclient
    ```
## 📌 Configuración en settings.py

Archivo: `ventas_ucatec/settings.py`

Cambios realizados en la sección DATABASES:

```python
DATABASES = {
    'default': {
        'ENGINE': 'django.db.backends.mysql',
        'NAME': 'ventas_db',
        'USER': 'ucatec_user',
        'PASSWORD': 'Password123!',
        'HOST': 'localhost',
        'PORT': '3310',
    }
}
```

## 📌 Migraciones realizadas
- Migración 1: Creación de tabla productos con campos nombre, precio, stock.

    Archivo: `productos/models.py`
    ```python
    from django.db import models

    class Producto(models.Model):
        nombre = models.CharField(max_length=100)
        precio = models.DecimalField(max_digits=10, decimal_places=2, null=True)
        stock = models.IntegerField(default=0)

        def __str__(self):
            return self.nombre
    ```

    Comandos:
    ``` powershell
    python manage.py makemigrations
    python manage.py migrate
    ```

- Migración 2: Se añadió campo ubicacion.

    Archivo: `productos/models.py`
    ```python
    from django.db import models

    class Producto(models.Model):
        nombre = models.CharField(max_length=100)
        precio = models.DecimalField(max_digits=10, decimal_places=2, null=True)
        stock = models.IntegerField(default=0)
        ubicacion = models.CharField(max_length=150, null=True)

        def __str__(self):
            return self.nombre
    ```

    Comandos:
    ``` powershell
    python manage.py makemigrations
    python manage.py migrate
    ```

- Migración 3: Se añadió campo categoria.

    Archivo: `productos/models.py`
    ```python
    from django.db import models

    class Producto(models.Model):
        nombre = models.CharField(max_length=100)
        precio = models.DecimalField(max_digits=10, decimal_places=2, null=True)
        stock = models.IntegerField(default=0)
        ubicacion = models.CharField(max_length=150, null=True)
        categoria = models.CharField(max_length=50, null=True)

        def __str__(self):
            return self.nombre
    ```

    Comandos:
    ``` powershell
    python manage.py makemigrations
    python manage.py migrate
    ```

## 📌 Verificación en MySQL

comandos ejecutados:
    ``` powershell
    docker exec -it mig_python_ucatec mysql -uucatec_user -p ventas_db
    ```

Dentro de MySQL:
    ``` SQL
    SHOW TABLES;
    DESCRIBE productos_producto;
    ```

Resultado final:
    ``` Code
    id, nombre, precio, stock, ubicacion, categoria
    ```



## 📌 Historial de comandos utilizados durante la practica
### Docker y MySQL
``` powershell
docker pull mysql:latest
docker run -d --name mig_python_ucatec -e MYSQL_ROOT_PASSWORD=Password123! -e MYSQL_DATABASE=ventas_db -e MYSQL_USER=ucatec_user -e MYSQL_PASSWORD=Password123! -p 3310:3306 mysql:latest
docker exec -it mig_python_ucatec mysql -uucatec_user -p ventas_db
```

### Django y entorno
``` powershell
pip install django mysqlclient
django-admin startproject ventas_ucatec
cd ventas_ucatec
python manage.py startapp productos
```

### Migraciones
``` powershell
python manage.py makemigrations
python manage.py migrate
```

### Verificacion en MySQL
``` powershell
docker exec -it mig_python_ucatec mysql -uucatec_user -p ventas_db
SHOW TABLES;
DESCRIBE productos_producto;
```

### Git y GitHub
``` powershell
cd C:\UCATEC\gest_BD_II\ventas_ucatec
git init
git add .
git commit -m "proyecto django con 3 migraciones"
git branch -M main
git remote add origin https://github.com/CarMichel/mig_ucatec.git
git push -u origin main
```
