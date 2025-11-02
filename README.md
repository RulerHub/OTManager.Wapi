# OTManager

OTManager.Wapi es una solución para la gestión de órdenes de trabajo, clientes, materiales, servicios y costos en entornos empresariales. El proyecto está desarrollado en .NET 9 y sigue una arquitectura limpia y modular.

Para evitar duplicar información, la documentación detallada sobre contribución, seguridad y conducta se mantiene en archivos dedicados en la raíz del repositorio:

- CONTRIBUTING.md — Pautas para contribuir, flujo de trabajo y checklist de PR.
- SECURITY.md — Pautas para reportar vulnerabilidades y prácticas mínimas de seguridad.
- Code_Of_Conduct.md — Código de conducta del proyecto.

También se incluyen plantillas de Issue y Pull Request en .github/ para estandarizar contribuciones.

## Características principales

- Gestión de Órdenes de Trabajo, Clientes, Materiales y Servicios.
- Costos y Facturación.
- Auditoría y trazabilidad de cambios.
- API RESTful con documentación (Swagger) en entornos de desarrollo.
- Arquitectura modular con Unit of Work, Repositories y Service Layer.

## Estructura del proyecto

- `OTManager.Data`: Acceso a datos, entidades y auditoría.
- `OTManager.Core`: Entidades de dominio y contratos.
- `OTManager.App`: Lógica de negocio y servicios de aplicación.
- `OTManager.Api`: API RESTful y documentación Swagger.
- `OTManager.Web`: Interfaz de usuario basada en Blazor.
- `OTManager.WebComp`: Componentes compartidos para la interfaz de usuario.

## Cómo empezar (resumen)

1. Clona el repositorio:
   ```bash
   git clone https://github.com/tu-usuario/OTManager.Wapi.git
   cd OTManager.Wapi
   ```
2. Restaura dependencias y ejecuta:
   ```bash
   dotnet restore
   dotnet run --project src/OTManager.Api/OTManager.Api.csproj
   dotnet run --project src/OTManager.Web/OTManager.Web.csproj
   ```
3. Configura la base de datos en `appsettings.json` y aplica migraciones si corresponde:
   ```bash
   dotnet ef database update --project src/OTManager.Data/OTManager.Data.csproj --startup-project src/OTManager.Api/OTManager.Api.csproj
   ```

Para información detallada sobre contribuciones, seguridad, plantillas y código de conducta revisa los archivos mencionados al inicio.

## Licencia

Este proyecto está bajo la Licencia MIT. Consulta el archivo [LICENSE.txt](./LICENSE.txt) para más detalles.