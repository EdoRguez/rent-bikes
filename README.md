# Rent Bikes

Rent bikes es un sistema el cual nos permite rentar bicicletas. Este mismo está diseñado usando los principales principios y diseños más usados a la hora de la creación de un sistema. Se pueden encontrar los siguientes principios y patrones de diseños:
- Repository Pattern
- Creational Pattern
- Structural Pattern
- KISS
- SOLID
- DRY

Adicionalmente el sistema tiene el siguiente diagrama de base de datos el cual sigue todos los estandares y los principios fundamentales a la hora de realizar un diseño de base de datos.

![alt text](https://i.imgur.com/Yb0moOu.png)

## Comenzando 🚀

Estas instrucciones te permitirán obtener una copia del proyecto en funcionamiento en tu máquina local para propósitos de desarrollo y pruebas.


### Pre-requisitos 📋

Que cosas necesitas para su instalación

```
- Angular 13
- .NET 5
- Microsoft SQL Server
```

### Instalación 🔧

Primero que nada debemos configurar los proyectos. Los siguientes pasos deben de llevarse a cabo para poder utilizar el proyecto.

**- Proyecto APIRentBikes**

1. Descargar o clonar el repositorio.

2. Abrir el proyecto en Visual Studio 2019.

3. Modificar el connection string del archivo appsettings.Development.json y appsettings.Production.json para que lea tu servidor de SQL Server local. Actualmente el servidor que aparece es el de mi máquina local personal.

```
"ConnectionStrings": {
    "DefaultConnection": "Server=DESKTOP-THA70A1\\SQLSERVER;Database=RentBikesDB;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
```

4. Utilizar el siguiente comando usando el "package manager console" para que Entity Framework cree la base de datos, modelos y tablas automaticamente.

```
update-database
```

**- Proyecto AngularRentBikes**

1. Descargar o clonar el repositorio.

2. Abrir el CMD.

3. Ingresar a la ruta principal donde está descargado el proyecto de Angular a través del CMD y colocar el siguiente comando para restaurar todos los paquetes instalados.

```
npm install
```

4. En el CMD ingresar el siguiente comando para iniciar al proyecto.

```
ng s -o
```

## Ejecutando las pruebas ⚙️

Antes de iniciar las pruebas por favor asgúrate de haber realizar los pasos anteriores y de estar corriendo los dos (2) proyectos.

Adicionalmente asegúrate que el proyecto de Angular en el archivo **environment.ts** (desarrollo) y **environment.prod.ts** (producción) la variable **API_URL** tenga la indicada que está corriendo tu API.

**- URL de la API**

![alt text](https://i.imgur.com/xeH5Xsx.png)


**- Misma URL de la API pero agregandole /api**

![alt text](https://i.imgur.com/iBgLvpU.png)


Una vez que tengamos estas verificaciones validadas y los proyectos corriendo prodremos dirigirnos al proyecto de Angular.

**- Página Inicial**

![alt text](https://i.imgur.com/Go7Y8Mx.png)


**- Renta de bicicleta**

![alt text](https://i.imgur.com/p1rp07F.png)


**- Datos guardados en la tabla y el el status de la bicicletas cambiarion**

![alt text](https://i.imgur.com/iIxRsZg.png)


Para finalizar si es necesario realizar Unit Tests para la validación de datos y para tener certeza de que el código realizado está funcionando correctamente se pueden realizar los siguientes pasos:

1. Ir a Visual Studio 2019

2. Ubicarse en el proyecto APIRentBikesTests y darle click derecho.

![alt text](https://i.imgur.com/bBoq8Fa.png)

3. Click en run tests y esperar los resultados de las pruebas.

![alt text](https://i.imgur.com/rjwgC4w.png)

## Construido con 🛠️

* [Angular 13](https://angular.io/) - Framework utilizado
* [.NET 5](https://dotnet.microsoft.com/download) - Framework utilizado
* [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) - Base de datos
* [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) - ORM
* [Visual Studio 2019](https://visualstudio.microsoft.com/es/launch/) - IDE
* [Visual Studio Code](https://code.visualstudio.com/) - Editor de texto
* [xUnit](https://xunit.net/) - Herramienta de tests


## Autores ✒️

* **Eduardo Rodríguez** - *Autor* - [edorguez](https://github.com/edorguez)

