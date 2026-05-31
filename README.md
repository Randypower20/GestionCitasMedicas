# Sistema de Gestión de Citas Médicas

## 1. Análisis del problema

La clínica actualmente gestiona citas de forma manual, lo que provoca errores como citas duplicadas, mala organización, dificultad para consultar disponibilidad y problemas en cancelaciones.

El sistema busca digitalizar este proceso para mejorar el control de pacientes, médicos y citas.

### Módulos identificados:
- Pacientes
- Médicos
- Especialidades
- Citas
- Notificaciones

### Versión actual incluye:
- Registro de pacientes
- Registro de médicos
- Registro de especialidades
- Gestión de citas (crear, consultar, cancelar)
- Envío de recordatorios

### Fuera de alcance:
- Facturación
- Historias clínicas
- Recetas médicas
- Telemedicina
- Chat médico
- Inteligencia artificial

---

## 2. Diseño orientado a objetos

### Entidades principales:
- Paciente (Id, Nombre, Teléfono, Correo)
- Médico (Id, Nombre, Especialidad)
- Especialidad (Id, Nombre)
- Cita (Id, Paciente, Médico, FechaHora, Estado)

### Servicios:
- PacienteService: registrar y consultar pacientes
- MedicoService: registrar y consultar médicos
- EspecialidadService: registrar y consultar especialidades
- CitaService: gestionar citas (crear, cancelar, reprogramar, consultar)

### Notificaciones:
- IRecordatorio (interfaz)
- EmailRecordatorio (implementación)

Permite agregar otros tipos de notificación sin modificar el sistema.

### Relaciones:
- Un paciente tiene muchas citas
- Un médico tiene muchas citas
- Una cita pertenece a un paciente y a un médico
- Un médico pertenece a una especialidad

---

## 3. Principios aplicados

- **SoC:** Separación entre entidades, servicios y notificaciones.
- **DRY:** Lógica de búsqueda y validación centralizada en servicios.
- **KISS:** Uso de listas en memoria sin complejidad innecesaria.
- **YAGNI:** No se implementaron funciones fuera del alcance (facturación, historia clínica, etc.).
- **SRP:** Cada clase tiene una única responsabilidad.
- **OCP:** Se pueden agregar nuevos tipos de recordatorios sin modificar el sistema.
- **LSP:** Las implementaciones de IRecordatorio son intercambiables.
- **ISP:** Interfaces pequeñas y específicas.
- **DIP:** El sistema depende de abstracciones, no de clases concretas.

---

## 4. Justificación técnica

- El sistema se dividió en módulos para facilitar mantenimiento.
- Las clases representan entidades reales del problema.
- Se evitó complejidad innecesaria para mantener el sistema simple.
- La repetición de código se evitó usando servicios centralizados.
- El sistema puede extenderse agregando base de datos, autenticación o nuevos tipos de notificaciones.
- El principio más difícil de aplicar fue OCP/DIP por el uso de abstracciones.
