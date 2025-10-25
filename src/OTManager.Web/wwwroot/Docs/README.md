# OTManager.Wapi

OTManager.Wapi es una solución para la gestión de órdenes de trabajo, clientes, materiales, servicios y costos en entornos empresariales. El proyecto está desarrollado en .NET 9 y sigue una arquitectura limpia y modular.

## Características principales

- **Gestión de Órdenes de Trabajo**: Creación, actualización y seguimiento de órdenes de trabajo.
- **Gestión de Clientes**: Administración de información de clientes y su historial de órdenes.
- **Control de Materiales y Servicios**: Registro y control de materiales y servicios asociados a cada orden.
- **Costos y Facturación**: Cálculo y gestión de costos de materiales, servicios y mano de obra, así como generación de facturas.
- **Auditoría**: Seguimiento de cambios y acciones realizadas sobre las entidades principales.
- **API RESTful**: Exposición de endpoints seguros y documentados para integración con otros sistemas.
- **Documentación interactiva (Swagger)**: Acceso restringido a la documentación interactiva en entornos de desarrollo.
- **Unit of Work y Repositorios**: Patrón Unit of Work y repositorios para una gestión eficiente y desacoplada de la persistencia.
- **Arquitectura modular**: Separación clara entre capa de datos, lógica de negocio, API y aplicación.

## Patrones de diseño implementados

- **Unit of Work**: Para la gestión de transacciones y persistencia de datos de forma atómica.
- **Repository**: Para el acceso desacoplado a la capa de datos.
- **DTO (Data Transfer Object)**: Para la transferencia de datos entre capas y la API.
- **Dependency Injection**: Para la inyección de dependencias y facilitar el testing y la extensibilidad.
- **Controller/Endpoint**: Para la exposición de la lógica de negocio a través de una API RESTful.
- **Mapper**: Para la conversión entre entidades de dominio y DTOs.
- **Service Layer**: Para la encapsulación de la lógica de negocio y orquestación de operaciones.
- **Auditable Entity**: Para el seguimiento de cambios y auditoría en las entidades principales.

## Estructura del proyecto

- `OTManager.Data`: Acceso a datos, entidades y auditoría.
- `OTManager.Core`: Entidades de dominio y contratos.
- `OTManager.App`: Lógica de negocio y servicios de aplicación.
- `OTManager.Api`: API RESTful y documentación Swagger.

## Requisitos
- .NET 9 SDK
- SQL Server u otro proveedor compatible con Entity Framework Core

## Licencia
Este proyecto está bajo la Licencia MIT. Consulta el archivo LICENSE.txt para más detalles.