# Sistema de Gestión de Infracciones de Tránsito DIGESETT

## Descripción General
El Sistema de Gestión de Infracciones de Tránsito DIGESETT es una aplicación web integral diseñada para gestionar infracciones de tránsito y rastrear el rendimiento de los agentes. Está construido utilizando Blazor Server y Entity Framework Core.

## Características
- **Diseño Modular**: El sistema está dividido en diferentes módulos, cada uno atendiendo a funcionalidades específicas.
- **Autenticación**: Inicio de sesión seguro para agentes y personal de oficina utilizando sus credenciales.
- **Navegación Dinámica**: Barra de navegación interactiva que se adapta según el módulo seleccionado.
- **Interfaz de Usuario Responsiva**: Construida con Bootstrap para una interfaz de usuario moderna y responsiva.

## Módulos
### 1. Módulo de Agentes
- **Registro de Multas**: Registrar nuevas infracciones de tránsito.
- **Mapa de Multas**: Ver infracciones en un mapa.
- **Comisiones**: Revisar comisiones basadas en infracciones.

### 2. Módulo de Oficina Central
- **Gestionar Multas**: Ver y gestionar infracciones, marcarlas como pagadas o perdonadas.
- **Reporte de Ingresos**: Generar informes de ingresos por mes y año.
- **Mapa de Multas**: Ver todas las infracciones en un mapa para un período seleccionado.
- **Gestionar Agentes**: Agregar, editar y desactivar agentes.

## Funcionalidades Pendientes para el Módulo 2
- **Gestionar Multas**: Traer las multas creadas por el agente y permitir editar su estado.
- **Reporte de Ingresos**: Ver el reporte de ingresos en base a las comisiones ganadas por el agente.
- **Gestionar Agentes**: Agregar, editar y desactivar agentes.


## Tecnologías Utilizadas
- Blazor Server
- Entity Framework Core
- Bootstrap
- BCrypt.Net para el hash de contraseñas

## Contribuciones
¡Las contribuciones son bienvenidas! Por favor, bifurca el repositorio y envía una solicitud de extracción para cualquier mejora.

.