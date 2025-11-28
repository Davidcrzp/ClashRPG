<p align="center">
  <h1>Clash Royale RPG</h1>
  <h3>by: Supersell team</h3>
</p>

## Contenido
- [Instrucciones de ejecución](#instrucciones-de-ejecución)
- [Requisitos previos](#Requisitos)
- [Clash RPG](#Clash-RPG)
- [Descripción del código](#descripción-del-código)
- [Equipo](#equipo)
- [Acuerdo de extensión](#ACUERDO-DE-EXENCIÓN-DE-RESPONSABILIDAD-Y-DESLINDE-LEGAL)

---

## Instrucciones de ejecución

1. Clona el repositorio en tu equipo local:
    ```bash
    git clone https://github.com/Davidcrzp/ClashRPG.git
    ```
2. Accede al directorio del proyecto:
    ```bash
    cd ClashRPG
    ```
3. Ejecuta el archivo principal del proyecto:
    ```bash
    dotnet run
    ```
4. Crea un perfil o inicia sesión si ya tienes uno dentro del juego. Esto te será de utilidad para guardar tu progreso y comenzar tu experiencia dentro de nuestro maravillosamente hermoso juego de rol

---

## Requisitos
- .NET 6.0 o superior
- MongoDB y SQL Server configurados localmente o acceso remoto
- Sistema operativo: Windows, Linux o MacOS

---
## Clash RPG

### Personajes
Presetamos la maravillosa aventura de El Caballero, El Mini pekka y El Mago. El sistema de personajes permite al jugador seleccionar entre 3 diferentes personajes provenientes del juego de "Clash Royale". Los personajes están diseñados para ofrecer estilos de juego variados y mejoran conforme avanzan durante la partida.

### Mapas
El juego cuenta con distintos mapas, cada uno con su propia estética y estructura. Los mapas pueden contener obstáculos, ítems especiales y distintas rutas estratégicas. La selección de mapas influye en la experiencia y las mecánicas de juego.

### Bosses
Los bosses son enemigos especiales con mayor dificultad y habilidades únicas. Se enfrentan al jugador en diferentes etapas y requieren estrategias específicas para ser derrotados. Cada boss está ambientado según el mapa en el que aparece. Un boss nunca viene solo, así que prepárate para enfrentarlo junto a sus molestos minions

### Logros
El juego también contiene un sistemade logros. ¡Anímate a explorar los distintos mapas, a recolectar y usar todos los diferentes objetos y derrota a todos, demuestrales quien manda y derrota a los molestos goblins!.

### Sistema de combate
El sistema de combate está basado en los típicos y característicos combates por turnos. El estilo de pelea dependerá de tu personaje, permitiendote usar el maná de distintes formas para dejar fuera de combate a cualquier monstruo que se te oponga en el camino

---

## Descripción del código

### Arquitectura del proyecto
El proyecto sigue una arquitectura por capas (Presentación, Lógica, Datos), facilitando la escalabilidad y el mantenimiento del código. Cada módulo está separado en carpetas que permiten ubicar fácilmente las funcionalidades principales y secundarias.

### Lógica de batalla
La lógica de combate se encuentra en el módulo `BattleManager`. Allí se procesan los turnos, ataques, defensas y efectos especiales de habilidades de cada personaje usando algoritmos de prioridad y cálculos de daño personalizados.

### Gestión de usuarios
El módulo `UserService` gestiona el registro de nuevos jugadores, inicio de sesión, recuperación de contraseñas y actualización de perfiles. Los usuarios pueden personalizar su perfil y ver su progreso dentro del juego.

### Inventario y sistema de ítems
Cada jugador cuenta con un inventario gestionado mediante MongoDB, permitiendo equipar, usar y combinar diferentes items que afectan atributos y batallas. El sistema de ítems está diseñado para ser ampliable y flexible.

### Sistema de logros
Cuando un jugador cumple las condiciones de un logro, este se registra automáticamente en la base y se muestra una notificación dentro del juego. Los logros motivan la exploración y el dominio de los mapas y habilidades.

### Gestión de logs y errores
Los errores del sistema y las acciones relevantes del usuario se almacenan en una tabla SQL para su posterior revisión y depuración. Esto permite mantener un registro de incidentes y resolver problemas rápidamente.

### Interfaz de usuario (UI)
La interfaz gráfica está desarrollada usando WinForms/WPF (según versión), permitiendo interacción intuitiva, menús navegables y efectos visuales dinámicos adaptados a la temática de Clash Royale.

### Sistema de guardado y carga
El progreso del jugador se guarda automáticamente tras cada partida, permitiendo reanudar el juego en cualquier momento. Se utiliza MongoDB para datos dinámicos y SQL para datos estructurados.

### Configuración y personalización
Los ajustes del juego pueden modificarse en el archivo `appsettings.json`, incluyendo idioma, nivel de dificultad, calidad gráfica y preferencias de sonido.

### Algoritmo de generación de mapas
Los mapas se crean usando un algoritmo de generación procedural, garantizando variedad y desafíos únicos en cada partida. Además, existen mapas prefijados para modos específicos de juego.

### Conexión a MongoDB
La conexión a MongoDB se utiliza para almacenar datos dinámicos del juego, como el progreso de los jugadores, inventarios y estadísticas. Se utiliza la biblioteca oficial de MongoDB para C#, estableciendo la conexión en el archivo de configuración y accediendo a la base mediante objetos de tipo colección.

### Conexión a SQL
El sistema de base de datos SQL se utiliza para gestionar información estructurada y persistente, como el registro de usuarios y logs históricos. La conexión se establece usando Entity Framework y cadenas de conexión en el archivo de configuración, permitiendo operaciones CRUD y consultas seguras sobre las tablas definidas.

---
## Equipo
* **[Dante Leonel Iñiguez Vega](https://github.com/Dantedndln)**
* **[Dario Jimenez Guzman](https://github.com/dariusjmz)**
* **[David Cruz Perez](https://github.com/Davidcrzp)**
* **[Erick Rafael Lopez Silva](https://github.com/ericklopezrs)**
* **[Luis Fernando Martinez Moncayo](https://github.com/Fernandomtz07)**
* **[Juan Manuel Padilla Ledezma](https://github.com/JM-ux9)**
* **[Luis Angel Rodrigez Larios](https://github.com/LuisAngel-23300740)**
* **[Luis Carlos Fuentes Esparza](https://github.com/ChaRex344)**
* **[Paulo Gael Venegas Becerra](https://github.com/PauloVenegas)**


---

# ACUERDO DE EXENCIÓN DE RESPONSABILIDAD Y DESLINDE LEGAL
## PROYECTO ACADÉMICO - CLASH RPG

### DECLARACIÓN DE USO NO COMERCIAL Y FINES EDUCATIVOS

Por medio del presente documento, los participantes del equipo de desarrollo del proyecto "CLASH RPG" declaramos y acordamos:

#### 1. NATURALEZA ACADÉMICA DEL PROYECTO
Este proyecto denominado "CLASH RPG" es desarrollado exclusivamente con **fines educativos y académicos**, como parte de un ejercicio de aprendizaje en:
- Desarrollo de software
- Diseño de bases de datos
- Gestión de proyectos tecnológicos
- Implementación de sistemas de juego

#### 2. RECONOCIMIENTO DE PROPIEDAD INTELECTUAL
Reconocemos expresamente que:
- "CLASH ROYALE" es una marca registrada propiedad de Supercell Oy
- Todos los personajes, nombres, diseños y elementos distintivos relacionados con Clash Royale son propiedad intelectual de sus legítimos dueños
- Este proyecto no tiene afiliación, asociación, autorización ni respaldo de Supercell Oy

#### 3. ALCANCE DEL USO
El proyecto se limita a:
- **Uso interno** dentro del ámbito académico
- **Demonstración educativa** sin distribución pública
- **Pruebas técnicas** sin ánimo de lucro
- **Desarrollo de habilidades** sin replicación comercial

#### 4. DESLINDE DE RESPONSABILIDAD
Cada miembro del equipo participante declara bajo su propia responsabilidad:

**"Comprendo que este proyecto utiliza referencias a una marca registrada con propósitos puramente educativos. Me comprometo a:**

a) No distribuir, publicar o comercializar este proyecto
b) No afirmar ni sugerir afiliación con Supercell Oy
c) Utilizar el proyecto únicamente en contextos académicos
d) Eliminar cualquier contenido protegido si se solicita legalmente
e) Asumir responsabilidad personal por cualquier uso indebido

**Eximo a mis compañeros de equipo, institución educativa y asesores de cualquier responsabilidad derivada de mi uso personal o inapropiado de este material."**

#### 5. DECLARACIÓN DE BUENA FE
Actuamos de buena fe creyendo que nuestro uso califica como "fair use" o uso justo bajo:
- Propósitos educativos y de investigación
- Transformación del contenido original
- Ausencia de impacto comercial
- Reconocimiento de la propiedad original

#### 6. COMPROMISOS ESPECÍFICOS
Nos comprometemos a:
- Incluir esta declaración en toda documentación del proyecto
- No monetizar directa o indirectamente el proyecto
- Limitar el acceso al código fuente al ámbito académico
- Cesar inmediatamente el desarrollo si recibimos notificación de Supercell Oy

#### 7. DISTRIBUCIÓN DE RESPONSABILIDADES
Cada miembro del equipo es responsable individualmente de:
- Su conducta respecto al uso del proyecto
- Cualquier acción que exceda los límites académicos
- Las consecuencias de compartir el proyecto fuera del contexto educativo

### FIRMAS DE LOS PARTICIPANTES

Yo, _________________________, miembro del equipo de desarrollo, he leído y comprendido completamente este acuerdo y acepto sus términos y condiciones.

**Nombre:** _________________________
**ID Estudiante:** _________________________
**Fecha:** _________________________
**Firma:** _________________________

---

### TESTIGO ACADÉMICO

**Tutor/Profesor:** _________________________
**Asignatura:** _________________________
**Institución:** _________________________
**Fecha:** _________________________
**Firma:** _________________________

---

*Este documento tiene validez durante toda la duración del proyecto y hasta su disposición final.*
*Versión 1.0 - Fines exclusivamente académicos*
---
- link directo al producto de referencia: [Clash Royale - Página Oficial](https://store.supercell.com/es/clashroyale)
