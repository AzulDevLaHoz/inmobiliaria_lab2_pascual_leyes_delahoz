# inmboiliarialab2_pascual_leyes_delahoz
Sistema de Gestión Inmobiliaria
Proyecto desarrollado en ASP.NET Core MVC con C# y MySQL / MariaDB (vía XAMPP), destinado a la administración integral de inmuebles, propietarios e inquilinos.

Integrantes del Equipo
Patricio Pascual

Azul De La Hoz

Leandro Leyes

Juan Clavero

Estado del Proyecto e Implementación
El sistema cuenta con la arquitectura base y el flujo completo de ABM / CRUD (Alta, Baja y Modificación) totalmente funcional para los siguientes módulos:

Propietarios: Registro de datos personales, edición de información y borrado de registros.

Inquilinos: Gestión completa de los inquilinos asociados al sistema inmobiliario.

Requisitos Previos
.NET SDK (Versión 8.0 o superior).

XAMPP Control Panel (Con el servicio de MySQL habilitado).

DBeaver o phpMyAdmin (Para la administración visual de la base de datos).

Configuración e Instalación de la Base de Datos

Iniciar el servicio de MySQL:

Abre el XAMPP Control Panel.

Haz clic en Start en el módulo MySQL hasta que el indicador se ponga en verde (puerto 3306).

Ejecutar el Script de la Base de Datos:

Abre tu cliente de base de datos preferido (DBeaver o phpMyAdmin).

Ejecuta el script .sql incluido en el proyecto (Dentro de la carpeta DataBase en contraras el archivo inmobiliaria_lab2.sql). No es necesario crear la base de datos previamente, ya que el script incluye la instrucción CREATE DATABASE automáticamente.

Verificar Cadena de Conexión:

El archivo appsettings.json en la raíz del proyecto ya está configurado con las credenciales locales de XAMPP y el nombre de la base de datos:

JSON
"ConnectionStrings": {
  "MySql": "Server=localhost;User=root;Password=;Database=inmobiliaria_lab2"
}
Ejecución de la Aplicación
Abrir el proyecto:
Navega desde la terminal hasta la carpeta raíz del proyecto.

Acceso desde el navegador:
Una vez iniciada la aplicación, ingresa a la URL que indica la consola (por ejemplo, http://localhost:5253).