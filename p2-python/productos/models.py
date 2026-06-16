from django.db import models

# Create your models here.
class Producto(models.Model):
    nombre = models.CharField(max_length=100)
    precio = models.DecimalField(max_digits=10, decimal_places=2, null=True)
    stock = models.IntegerField(default=0)
    ubicacion = models.CharField(max_length=150, null=True)
    categoria = models.CharField(max_length=50, null=True)


    def __str__(self):
        return self.nombre