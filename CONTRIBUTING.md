CONTRIBUTING
===========

Gracias por tu interés en contribuir a OTManager.Wapi. Este documento proporciona las pautas esenciales para colaborar en este proyecto de software libre. Para evitar duplicar información, las secciones sobre seguridad y conducta se encuentran en SECURITY.md y Code_Of_Conduct.md respectivamente.

1. Resumen
---------
OTManager.Wapi es un proyecto en .NET 9 (API y Blazor) que utiliza Entity Framework Core para persistencia. Intentamos mantener contribuciones claras, probadas y acordes con las reglas de estilo del proyecto.

2. Código de conducta
---------------------
Revisa `Code_Of_Conduct.md` para las normas de comportamiento y cómo reportar incumplimientos.

3. Cómo reportar un bug
-----------------------
- Abre una Issue nueva usando la plantilla "Bug report" (usa 'New issue' -> seleccionar plantilla).
- Incluye pasos para reproducir, comportamiento esperado, comportamiento real, versión de .NET (debe ser .NET 9), sistema operativo, y logs relevantes.

4. Cómo proponer una característica
----------------------------------
- Abre una Issue usando la plantilla "Feature request" describiendo el caso de uso y la solución propuesta.

5. Flujo de trabajo para contribuir (fork & PR)
-----------------------------------------------
1. Haz fork del repositorio y clona tu fork:
   ```bash
   git clone https://github.com/tu-usuario/OTManager.Wapi.git
   cd OTManager.Wapi
   ```
2. Crea una rama para tu trabajo (nombres sugeridos):
   - feature/<descripcion>
   - fix/<descripcion>
   - docs/<descripcion>

   ```bash
   git checkout -b feature/mi-nueva-funcionalidad
   ```
3. Asegúrate de que tu rama esté actualizada con la rama principal upstream:
   ```bash
   git remote add upstream https://github.com/organizacion/OTManager.Wapi.git
   git fetch upstream
   git rebase upstream/main
   ```
4. Realiza cambios pequeños y con commits atómicos.
5. Ejecuta pruebas y formatea el código (ver sección herramientas).
6. Publica tu rama y abre un Pull Request usando la plantilla PR disponible.

6. Requisitos y herramientas para el desarrollo
----------------------------------------------
- .NET 9 SDK instalado
- SQL Server (o proveedor EF Core compatible) para ejecutar migraciones locales
- dotnet-ef (si trabajas con migraciones):
  ```bash
  dotnet tool install --global dotnet-ef
  ```

7. Ejecutar el proyecto localmente
---------------------------------
- Restaurar dependencias:
  ```bash
  dotnet restore
  ```
- Aplicar migraciones (si corresponde):
  ```bash
  dotnet ef database update --project src/OTManager.Data/OTManager.Data.csproj --startup-project src/OTManager.Api/OTManager.Api.csproj
  ```
- Ejecutar la API y la UI:
  ```bash
  dotnet run --project src/OTManager.Api/OTManager.Api.csproj
  dotnet run --project src/OTManager.Web/OTManager.Web.csproj
  ```

8. Estilo de código y linters
----------------------------
- Sigue las reglas de C# y .editorconfig del repositorio (si existe).
- Usa dotnet format para formatear tu código antes de subirlo:
  ```bash
  dotnet tool restore
  dotnet format
  ```

9. Pruebas
----------
- Añade/actualiza pruebas unitarias para cualquier cambio en la lógica de negocio.
- Ejecuta todas las pruebas antes de abrir PR:
  ```bash
  dotnet test
  ```

10. Convenciones de commits
---------------------------
Usa mensajes claros y preferiblemente el estándar "Conventional Commits":
- feat: Nueva funcionalidad
- fix: Corrección de bug
- docs: Cambios en documentación
- style: Formateo, espacios, punto y coma
- refactor: Refactorización sin cambiar comportamiento
- test: Añadir/ajustar pruebas
- chore: Cambios en build o herramientas

11. Proceso de Pull Request
---------------------------
- Crea PR contra la rama main (o la rama de desarrollo si el proyecto la usa).
- Usa la plantilla de PR ubicada en `.github/PULL_REQUEST_TEMPLATE.md`.
- Describe qué hace el cambio, por qué es necesario y cómo probarlo.

Checklist sugerida para PRs (ver plantilla):
- [ ] El código compila y pasa las pruebas locales
- [ ] Agregado/actualizado tests
- [ ] Documentación actualizada si aplica
- [ ] Se formateó el código
- [ ] No incluye secretos en el commit

12. Seguridad
-------------
Revisa `SECURITY.md` para el proceso de reporte de vulnerabilidades y prácticas de seguridad.

13. Contacto
-----------
Si tienes dudas sobre cómo contribuir, abre una Issue etiquetada como "help wanted" o contacta a los mantenedores.
