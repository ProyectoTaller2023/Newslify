# Newslify
➡ Aplicacion de noticias usando .NET ABP Framework para el backend y Angular en frontend. 

# Requerimientos funcionales

### General
El usuario podrá registrarse en la aplicación 💹
El usuario podrá ingresar a la aplicación mediante datos identificatorios del mismo.💹

### Funcionalidad administrativa
El usuario podrá establecer diferentes datos de la cuenta, siendo uno de ellos el idioma preferido de las noticias visualizadas.💹

### Funcionalidad operativa  
La funcionalidad operativa tiene como objetivo mostrar al usuario noticias agrupadas en listas.  
El usuario podrá buscar un tema puntual y agregar la noticia a una lista para su posterior lectura.  
La aplicación deberá visualizar notoriamente las noticias leídas de las no.   
Se podrán crear listas de temas con múltiples niveles de agrupamiento.   

### Alertas de nuevas noticias.
El usuario podrá crear una alerta sobre si una búsqueda de un tema no trajo resultados o sobre una lista si aparecen nuevas noticias.   
Al configurarse las alertas el sistema buscará periódicamente dichas alertas y notificará al usuario de resultados exitosos.

Las alertas generadas se deberán manifestar de dos maneras diferentes:
Se deberá mostrar en un área de notificación en el panel de lectura, la información de las alertas de la última semana.   
Se deberá enviar un mail al usuario manifestando la situación.

### Monitoreo
El usuario podrá acceder al panel de monitoreo de la API en donde se visualizarán datos de accesos realizados a la API como ser cantidad de accesos, tiempos promedio de acceso, cantidad de errores, etc.   
La aplicación deberá contener una bitácora de monitoreo (archivo de log), que permita hacer diagnósticos ante la ocurrencia de errores.
