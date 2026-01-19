Redarbor Inventory API - Prueba Técnica Senior
Este proyecto consiste en una API RESTful para la gestión de productos, categorías y movimientos de inventario, desarrollada bajo una arquitectura limpia y siguiendo principios de Clean Code y SOLID.
🛠️ Tecnologías Utilizadas
Lenguaje: C# / .NET 6.0.
Persistencia: Dapper (Operaciones de lectura/escritura).
Base de Datos: SQL Server 2022 (Dockerizado).
Autenticación: JWT (JSON Web Token).
Documentación: Swagger UI.
🚀 Instrucciones de Despliegue (Docker)
Para levantar el entorno completo (API + Base de Datos), siga estos pasos desde la raíz del proyecto:
 1. Construir y levantar contenedores:
	docker-compose up --build
 2. Acceder a la API:
	Swagger UI: http://localhost:5000/swagger.	
🗄️ Configuración de Base de Datos
El proyecto incluye un script de inicialización automática en sql-scripts/init-db.sql. Siguiendo los requerimientos técnicos:
Se gestionan tablas para Products, Categories y InventoryMovements.
Nota: No se utilizan llaves foráneas (Foreign Keys) por diseño solicitado en la prueba.
Si por configuración del motor la base de datos no se crea automáticamente, puede conectarse mediante SSMS a localhost,1433 (User: sa, Pass: ChallengeNetHitg!2026) y ejecutar el script manualmente.
🔐 Autenticación
Para probar los endpoints protegidos:
Use el endpoint /api/Auth/login con las credenciales configuradas (ej. Héctor).
Copie el token del cuerpo de la respuesta.
En Swagger, haga clic en Authorize y pegue el token con el formato: Bearer [su_token].
