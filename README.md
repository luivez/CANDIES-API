# CANDIES_API

Descargar o Clonar el repositorio

La carpeta WebApi es la carpeta del proyecto, favor de no cambiarla o modificarla de ninguna forma

# NECESARIO
Windows 7 o Superior

SQL Server 2012 o Superior

.Net Core SDK v2.2

Visual Code (Preferible) o IDE .Net Core de su preferencia

Extension REST CLIENT (en el caso de Visual Code) o POSTMAN

# IMPORTANTE!!!!
Antes de iniciar la aplicacion o de cualquier otra accion, debe ir al archivo "appsettings.json" y cambiar la conexion a la base de datos estableciendo el servidor al que se conectara y la base de datos que NO DEBE ESTAR CREADA ya que se creara mas adelante

OJO: Poner siempre el slash invertido doble en "appsetings.json" para que sea reconocido por el formato JSON como un unico slash invertido

# COMANDOS PARA VISUAL CODE
Los comandos para ejecutarla en Visual Code son:

<code>dotnet build</code> = construye la aplicacion

<code>dotnet ef migrations add AddCandiesToDB</code> = Crea las migraciones necesarias (Puede demorar unos segundos)

<code>dotnet ef database update</code> = Ejecuta las migraciones para crear la Base de datos (Puede demorar unos segundos)

<code>dotnet run</code> = Ejecuta el Proyecto WebAPI

# DOCUMENTACION DEL API
En la carpeta "API" del proyecto WebApi encontrara archivos con extension http con las diferentes direcciones a las cuales el API del Proyecto responde, con sus respectivos verbos http y sus "body" necesarios para la ejecucion en el caso de los metodos con verbos POST Y PUT.

Si cuenta con Visual Code debe de instalar la extencion REST CLIENT (la primera opcion) y en cada uno de los los metodos de los archivos HTTP aparecera la opcion <code>Send Request</code> a la cual solo tendra que darle click para que se ejecute el metodo

# JWT
Los unicos metodos permitidos sin JWT son los de <code>authentication</code> y <code>register</code> para los usuarios de ahi todos los metodos exigen JWT para su acceso
