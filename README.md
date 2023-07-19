# grupomok-overtime-tracking
## Configuración de la Base de Datos

1. Primero, asegúrate de tener una copia de seguridad de la base de datos. Si aún no la tienes, puedes encontrar el archivo de copia de seguridad en el repositorio de github  `GrupoMok.OvertimeTracking.Infrastructure/GrupoMokDatabase.bak`. 

2. Luego, configura la variable de entorno `__DB_CONNECTION_STRING__` con la cadena de conexión adecuada para tu base de datos.

   - En Windows, sigue estos pasos:
      a. Abre el menú Inicio y busca "Variables de entorno".
      b. Selecciona "Editar las variables de entorno del sistema".
      c. Haz clic en el botón "Variables de entorno".
      d. En la sección "Variables del sistema", haz clic en "Nuevo".
      e. En "Nombre de la variable", escribe `__DB_CONNECTION_STRING__`.
      f. En "Valor de la variable", pega la cadena de conexión de tu base de datos.
      g. Haz clic en "Aceptar" para guardar los cambios.

3. ¡Listo! Ahora la variable de entorno `__DB_CONNECTION_STRING__` está configurada y lista para ser utilizada en tu proyecto.


db_connection_string = os.environ.get('__DB_CONNECTION_STRING__')
# Usa db_connection_string para conectarte a la base de datos



