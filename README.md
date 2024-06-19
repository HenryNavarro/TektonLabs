# TektonLabs
Challenge

- Se ha utilizado Clean Architecture con DDD
- Se ha utilizado SQLite para la persistencia.


=== Para ejecutar el proyecto utilizando linea de comandos ===
- 1. Situese en la carpeta: ..TektonLabs\src\TektonLabs.Challenge.API
- 2. ejecute la sentencia: dotnet run
- 3. Revise el puerto asignado y en su navegador ingrese al swagger habilitado 
                http://localhost:57679/swagger/index.html

=== Puntos Cubiertos ===

- 1.1. Crear un rest API en .net Core (última versión).

- 1.2. Documentar la API usando swagger.

- 1.3. Usar patrones (ejemplo: mediator pattern, repository pattern, cqrs, etc).
Se ha utilizado CQRD, DDD, Repository, unitofwork, Mediator, Eventos de Dominio, 

- 1.4. Aplicar principios SOLID y Clean Code.

- 1.6. Usar buenos patrones para las validaciones del Request, y además, considerar los HTTP Status Codes en cada petición realizada.
Se ha utilizado validator a nivel de middlewate de aplicación y tambien valitador a nivel de dominio.

- 1.7. Estructurar el proyecto en N-capas.

- 1.8. Agregar un archivo readme (README.md) en dónde se haga una breve

- 1.9. Subir el proyecto a github de manera pública.

- 2.1 Realizar Insert(POST), Update(PUT) y GetById(GET) de un maestro de
productos.

- 2.2. Loguear el tiempo de respuesta de cada request hecho en un archivo de
texto plano.

- 2.3. Mantener en caché(5 min) un diccionario de estados del producto
Se ha implementado con Lazy Cache.

- 2.4. Grabar la información del producto localmente usando cualquier tipo de
persistencia. Los campos mandatorios son: ProductId, Name, Status(0 o 1),
Stock, Description y Price.

- 2.5. Obtener el descuento de algun otro servicio.
- 2.5. El método GetById debe retornar un producto.


=== Puntos no cubiertos por el momento ===

- 1.5. Implementar la solución haciendo uso de TDD.
Se ha utilizado Test Unitarios



