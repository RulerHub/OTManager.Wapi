Security
========

Este documento describe el proceso y pautas esenciales para reportar vulnerabilidades y las prácticas mínimas de seguridad que el proyecto debe seguir.

1. Reporte de vulnerabilidades
------------------------------
- No publiques vulnerabilidades en Issues públicas.
- Para reportes confidenciales, utiliza la sección "Security Advisories" de GitHub o contacta a los mantenedores por correo electrónico: adrianmesasacasas@outlok.com.
- Incluye en el reporte: resumen, pasos para reproducir, impacto potencial, versión afectada, y mitigaciones temporales si existen.

2. Respuesta a incidentes
-------------------------
- Los mantenedores confirmarán recepción en un plazo máximo de 72 horas.
- Se evaluará la severidad y se priorizará la corrección.
- Se coordinará la divulgación responsable y se publicará un advisory público una vez exista parche disponible.

3. Prácticas recomendadas de desarrollo
---------------------------------------
- No incluir secretos en el repositorio (claves, contraseñas, tokens). Usa archivos de configuración locales y variables de entorno.
- Añadir un archivo .gitignore apropiado para evitar subir archivos sensibles.
- Usar HTTPS y TLS para comunicaciones en producción.
- Validar y sanitizar todas las entradas de usuarios (servidor y cliente).
- Limitar exposición de información sensible en errores y logs.
- Implementar autenticación y autorización robusta (p. ej. JWT con expiración, refresh tokens controlados, y verificación de scopes/roles).
- Proteger endpoints administrativos y documentación (Swagger) en entornos no-privados.
- Usar cifrado para datos sensibles en reposo y en tránsito cuando sea necesario.

4. Gestión de dependencias
--------------------------
- Mantener dependencias actualizadas y aplicar parches de seguridad.
- Ejecutar análisis de vulnerabilidades en dependencias (p. ej. `dotnet list package --vulnerable` o herramientas como Dependabot).

5. Pruebas y validaciones
-------------------------
- Incluir pruebas de seguridad automatizadas cuando sea posible (análisis estático, escaneo de dependencias, pruebas de penetración en etapas de CI).
- Revisar entradas y límites para evitar inyección SQL, XSS, CSRF, etc.

6. Política de divulgación
--------------------------
- Se seguirá una divulgación responsable: notificar a los mantenedores, permitir un periodo razonable para parche, luego divulgar públicamente los detalles.

7. Contacto
-----------
- Reportes de seguridad: adrianmesasacasas@outlok.com
- Si no se proporciona un correo, usa GitHub "Security Advisories".

Gracias por ayudar a mantener la seguridad del proyecto.