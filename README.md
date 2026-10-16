# Sistema_Documentacion

Aplicación de escritorio en C# y Windows Forms para registrar documentación asociada a personas, consultar documentos en stock, registrar entregas y generar listados e informes. El repositorio conserva varias copias históricas del sistema; no es un gestor web de archivos ni una biblioteca de documentación técnica.

El punto de entrada `Program.cs` abre el formulario `Principal`. Sus menús enlazan carga, búsqueda y listado de stock, entregas, administración de tipos y reportes. La capa de datos utiliza OLE DB y procedimientos almacenados.

## Organización del repositorio

| Carpeta | Contenido |
| --- | --- |
| [Sistema Registro ORIGINAL/](Sistema%20Registro%20ORIGINAL/) | Copias históricas, archivos comprimidos y versiones del programa. |
| [Sistema Registro Funciona con OLEDB/](Sistema%20Registro%20Funciona%20con%20OLEDB/) | Variante con proyecto en `PROGRAMA/DOCUMENTACION/` y acceso a datos OLE DB. |
| [Sistema Registro Funciona con OLEDB y Crystal Report/](Sistema%20Registro%20Funciona%20con%20OLEDB%20y%20Crystal%20Report/) | Variante con formularios adicionales e informes Crystal Reports. Es la referencia de las rutas siguientes, no una garantía de que sea la versión más estable. |

En la variante con Crystal Reports:

- [DOCUMENTACION/DOCUMENTACION.sln](Sistema%20Registro%20Funciona%20con%20OLEDB%20y%20Crystal%20Report/DOCUMENTACION/DOCUMENTACION.sln): solución de Visual Studio 2010; también referencia un proyecto de instalación `.vdproj`.
- [DOCUMENTACION/DOCUMENTACION/DOCUMENTACION.csproj](Sistema%20Registro%20Funciona%20con%20OLEDB%20y%20Crystal%20Report/DOCUMENTACION/DOCUMENTACION/DOCUMENTACION.csproj): aplicación WinForms, destino .NET Framework 4.0 y plataforma x86.
- [Program.cs](Sistema%20Registro%20Funciona%20con%20OLEDB%20y%20Crystal%20Report/DOCUMENTACION/DOCUMENTACION/Program.cs) y [Principal.cs](Sistema%20Registro%20Funciona%20con%20OLEDB%20y%20Crystal%20Report/DOCUMENTACION/DOCUMENTACION/Principal.cs): arranque y menú principal.
- [Formularios/](Sistema%20Registro%20Funciona%20con%20OLEDB%20y%20Crystal%20Report/DOCUMENTACION/DOCUMENTACION/Formularios/): pantallas de carga, entrega, búsqueda, modificación y reportes.
- [Clases/](Sistema%20Registro%20Funciona%20con%20OLEDB%20y%20Crystal%20Report/DOCUMENTACION/DOCUMENTACION/Clases/): modelos de personas y documentos.
- [BD/](Sistema%20Registro%20Funciona%20con%20OLEDB%20y%20Crystal%20Report/DOCUMENTACION/DOCUMENTACION/BD/): controladora de conexión y acceso a datos por entidad.
- [BD/ de la variante](Sistema%20Registro%20Funciona%20con%20OLEDB%20y%20Crystal%20Report/BD/): scripts SQL y modelos de base de datos, separados de las clases C# anteriores.

También se incluyen informes `.rpt` y `.rdlc`, datasets, ensamblados y artefactos `bin/` y `obj/`. La presencia de ejecutables o DLL no demuestra que una compilación nueva sea reproducible.

## Requisitos históricos

- **Windows**, con un entorno de desarrollo que pueda abrir proyectos WinForms de **.NET Framework 4.0**. No es un proyecto .NET moderno para ejecutar con `dotnet run` en Linux.
- Visual Studio compatible con el formato de solución 2010; la carga del instalador `.vdproj` puede requerir soporte adicional. Para estudiar el código se puede abrir directamente el `.csproj` de la aplicación.
- Referencias de la variante Crystal: `CrystalDecisions.*` versión `13.0.2000.0`, `Microsoft.ReportViewer.*` versión `10.0.0.0`, `FlashControlV71` y `MySql.Data` versión `6.4.3.0`. Deben resolverse con componentes legítimos y compatibles con **x86**; no basta con tener un SDK de .NET instalado.
- Un proveedor OLE DB de 32 bits compatible con la base elegida y una base de pruebas que implemente el esquema y los procedimientos esperados por el código.

`REGISTRO2.sql` contiene sintaxis de SQL Server, tablas como `Personas`, `Pendientes` e `Historico`, y procedimientos de carga, entrega y consulta. `REGISTRO_MYSQL.sql` corresponde a otro motor: su presencia y la referencia `MySql.Data` no implican que ambos scripts sean intercambiables ni que la variante OLE DB funcione sin adaptación sobre MySQL.

## Cómo abordar una puesta en marcha

```bash
git clone git@github.com:tunonalves/Sistema_Documentacion.git
cd Sistema_Documentacion
```

1. Elegir una variante y conservar juntas sus clases, formularios, informes y esquema; no mezclar archivos de las copias históricas por nombre.
2. Abrir el proyecto indicado en un entorno Windows aislado. Resolver referencias y mantener el destino x86 antes de intentar compilar.
3. Revisar los scripts de base de datos antes de autorizar su ejecución. Preparar exclusivamente una base vacía de laboratorio, con datos ficticios y permisos mínimos; **no importar los archivos sobre una base existente o de producción**.
4. Revisar `BD/Controladora.cs`: la conexión activa referencia un archivo `conexion.udl`. Crear una configuración local propia y ajustar su ubicación si corresponde; no reutilizar ni publicar credenciales de archivos incluidos en el repositorio.
5. Configurar también los orígenes de datos de los informes y datasets para ese laboratorio. Compilar desde el código fuente y revisar los errores del IDE antes de iniciar la aplicación.
6. Solo después de validar la conexión y las dependencias, comprobar manualmente carga, stock, entrega y reportes con datos de prueba. El formulario principal intenta conectarse al cargarse: abrir el programa no es una operación aislada de la base de datos.

No se proporciona una importación automática de SQL ni se recomienda ejecutar los binarios versionados. La preparación de la base y los componentes externos exige decisiones específicas del entorno.

## Limitaciones y seguridad

- Es un conjunto de proyectos heredados, con versiones duplicadas, rutas locales y dependencias externas; no hay un procedimiento de restauración moderno que garantice compilar desde cero.
- Los archivos de conexión y configuraciones locales pueden contener datos sensibles. Mantener configuraciones nuevas fuera del control de versiones y rotar cualquier secreto previamente publicado; no adjuntarlos a incidencias ni a capturas.
- Los registros de personas y documentación requieren protección de datos. No usar datos reales para las primeras pruebas ni distribuir volcados sin revisión.
- Las dependencias históricas, incluido el control Flash referenciado, requieren una evaluación de compatibilidad y seguridad antes de plantear uso real. Este README no recomienda exponer el sistema ni certifica su seguridad.
- No hay una suite de pruebas automatizadas identificada ni un backend independiente que se pueda levantar con un comando estándar.

## Alcance de la revisión

Se revisaron estáticamente la estructura, el proyecto, el punto de entrada, formularios, acceso a datos y declaraciones de esquema. Se comprobaron las rutas enlazadas y el formato del cambio documental. **No se compilaron ni ejecutaron aplicaciones, instaladores o SQL; no se abrió ninguna conexión a bases de datos ni se leyeron archivos de credenciales.** La funcionalidad en Windows y la generación de informes quedan pendientes de validación en un laboratorio compatible.
