\# TP1\_Prg1 — Prototipo 3D de Parkour



Prototipo de videojuego en 3D desarrollado en Unity para una práctica de programación. El personaje recorre un escenario de plataformas esquivando obstáculos, obtiene un potenciador de salto, recoge un objeto y lo transporta hasta la zona de meta para ganar.



\## Descripción del Proyecto



El juego consiste en un circuito de parkour 3D en el que el jugador debe demostrar su habilidad de control sobre plataformas fijas y móviles.



Navegación: Inicio desde el menú principal hasta las pantallas de victoria o derrota.

Plataformas y Obstáculos: Desplazamiento por el mapa esquivando piedras que caen periódicamente.

Power-Up: Obtención de un aumento temporal en la capacidad de salto para alcanzar zonas altas.

Objetivo: Recoger la caja interactiva, transportarla por el escenario y soltarla dentro de la zona de meta para ganar.



\## Versión de Unity y Requisitos



Unity: Unity 6.3 LTS (`6000.3.22f1`)

Pipeline: Universal Render Pipeline (URP)

Input: Input System estándar y legacy de C#

Herramientas: Unity Hub y Visual Studio o VS Code



\## Controles del Juego



\-W, A, S, D / Flechas: Moverse (calculado según la dirección de la cámara)

\-Shift Izquierdo: Correr

\-Espacio: Saltar y doble salto

\-E:Recoger el objeto (estando cerca)

\-G: Soltar el objeto

\-Clic Derecho + Mouse: Girar la cámara libremente

\-Z / X: Girar la cámara desde el teclado



\## Mecánicas e Implementación Técnica



\-Movimiento de Personaje (`PlayerMovement.cs`): Control por físicas mediante Rigidbody en `FixedUpdate()`, rotación congelada para evitar caídas y detección de suelo precisa con Raycast.

\-Plataformas Móviles: Movimiento entre dos puntos con pausas controladas mediante `Invoke()`.

\-Spawner de Obstáculos: Instanciación periódica de piedras con `InvokeRepeating()` y limpieza de memoria con `Destroy()`.

\-Recoger y Soltar (`PickUpObject.cs`): Adopción de la caja como hijo del personaje con `SetParent()`, desactivando sus físicas mientras se carga y restaurándolas al soltarla con la tecla G.

\-Power-Up de Salto (`PowerUpJump.cs`): Multiplicador temporal de la fuerza de salto gestionado por Corrutinas (`IEnumerator` y `yield return new WaitForSeconds`), incluyendo tiempo de duración y recarga.

\-Zona de Meta (`GoalZone.cs`): Trigger que detecta cuando el objeto con etiqueta `Box` es depositado en la zona, cambiando el color del material y activando la pantalla de victoria.

\-Gestión de UI (`GestorUI.cs` / `MenuInicio.cs` / `MenuVictoria.cs`): Control centralizado de pantallas de interfaz, inicio y reinicio.





\## Estructura del Repositorio



Assets/Materials: Materiales y colores de la escena.

Assets/Prefabs: Prefabs de piedras, cajas y plataformas.

Assets/Scenes: Escenas del proyecto (`MenuInicial`, `tp1\_pv`).

Assets/Scripts: Scripts de movimiento, interacción, mecánicas e interfaz.

Packages: Dependencias de paquetes de Unity.

ProjectSettings:Configuración global del proyecto.



\## Captura

!\[Escenario](Screenshots/escenario.png)



