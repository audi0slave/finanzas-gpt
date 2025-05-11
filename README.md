# Configuración

Para usar el programa es necesario crear un archivo App.config en el directorio raiz de la solución el cual contiene la cadena de conexión a la base de datos.

## Archivo App.config
El código que debe ir en ese archivo es el siguiente:

```
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
	<connectionStrings>
		<add name="MySQL" connectionString="Server=localhost;Database=finanzas;User=TuUsuario;Password=TuPassword;" providerName="MySql.Data.MySqlClient" />
	</connectionStrings>
</configuration>
```

### Configuración de cadena de conexión.
Hay que reemplazar el valor "TuUsuario" y "TuPassword" de la cadena de conexión por los usuarios y contraseñas que tengas configurado en tu base de datos.

