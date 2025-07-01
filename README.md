AdminGastosApp
AdminGastosApp es una aplicación multiplataforma (iOS, Android, Windows) desarrollada con .NET MAUI para la gestión y control de gastos personales. Permite registrar gastos con categorías personalizables, visualizar un resumen mensual y agregar nuevas categorías según necesidad.

Características principales
Registro de gastos con descripción, monto, fecha y categoría.

Categorías predeterminadas y posibilidad de agregar categorías nuevas.

Visualización del resumen de gastos agrupados por categoría en un gráfico circular.

UI moderna con botones flotantes para agregar gastos y categorías.

Navegación sencilla entre páginas principales: listado de gastos, resumen y agregar categorías.

Manejo dinámico de temas claros y oscuros (colores del gráfico adaptativos).

Base de datos SQLite para almacenamiento local de datos.

Estructura del proyecto
Models: Definición de las clases Gasto y Categoria.

Services: DatabaseService para acceso y manipulación de la base de datos SQLite.

ViewModels:

GastosViewModel: carga y muestra gastos del mes actual.

AgregarGastoViewModel: gestión del formulario para agregar un nuevo gasto.

AgregarCategoriaViewModel: permite crear nuevas categorías.

Views:

MainPage: listado de gastos con botón flotante para agregar.

ResumenPage: visualización gráfica de gastos por categoría.

AgregarGastoPage: formulario para registrar un gasto.

AgregarCategoriaPage: formulario para crear nuevas categorías.

Tecnologías utilizadas
.NET MAUI para desarrollo multiplataforma.

SQLite para almacenamiento local.

CommunityToolkit.MVVM para patrón MVVM y comandos.

SkiaSharp para gráficos (PieChart).

Microsoft.Maui.Controls para UI.

Instrucciones para ejecutar el proyecto
Clonar el repositorio.

Abrir el proyecto en Visual Studio 2022 (asegúrate de tener el workload .NET MAUI instalado).

Restaurar paquetes NuGet.

Compilar y ejecutar en el emulador o dispositivo de tu elección (iOS, Android, Windows).

Usa el botón flotante en MainPage para agregar gastos o navegar a resumen y categorías.

Cómo contribuir
Si quieres mejorar esta aplicación:

Haz un fork del repositorio.

Crea una rama para tu funcionalidad: git checkout -b feature/nueva-funcionalidad.

Realiza tus cambios y confirma los commits.

Envía un pull request describiendo tus mejoras.

Licencia
Este proyecto está bajo la licencia MIT.
