# PruebaTecnica
Pasos para ejecucion de la solucion(Ticket)
1. Unas vez abierta la solucion, en Tickets se encuentra el archivo appsettings.json en donde se debera actualizar la cadena de conexion de la base de datos.
2. cuando ya este actualizada la cadena de conexion a la base de datos, en la Consola del Administrador de Paquetes(Ticket.DataAccess) ejecutar el comando "EntityFrameworkCore\Update-Database" Este comando es para generar la base de datos SQL server de forma local. 
3. De esta forma ya se puede poner a ejecutar o correr el proyecto, una vez este en ejecucion en este aparecera con una url de documentacion(Swagger) para de esta forma poder hacer las respectivas reviciones y pruebas
