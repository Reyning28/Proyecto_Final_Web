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
- **Reporte de Ingresos**: Generar informes de ingresos por mes y año.
- **Mapa de Multas**: Ver todas las infracciones en un mapa para un período seleccionado.
- **Gestionar Agentes**: Agregar, editar y desactivar agentes.

### 3. Módulo Administrativo
- **Gestionar Conceptos de Multas**: Añadir, editar y eliminar conceptos de multas que pueden ser asignados a infracciones.
- **Gestión de Usuarios**: (Pendiente) Implementar lógica para la gestión de usuarios.
- **Autenticación**: (Pendiente) Añadir autenticación para acceder al módulo administrativo.

## Funcionalidades Pendientes para el Módulo 2
- **Gestionar Agentes**: Agregar, editar y desactivar agentes.

## Funcionalidades Pendientes para el Módulo 3
- Implementar autenticación para el acceso al módulo.
- Desarrollar la lógica para la gestión de usuarios.

## Tecnologías Utilizadas
- Blazor Server
- Entity Framework Core
- Bootstrap
- BCrypt.Net para el hash de contraseñas

## contra 
- 123456