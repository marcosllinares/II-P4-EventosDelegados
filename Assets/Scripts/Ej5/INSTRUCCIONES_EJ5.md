# 📋 Instrucciones para Ejercicio 5

## 🎯 Objetivo
Implementar mecánica de recolección de escudos que actualicen la puntuación del jugador:
- **Escudo Tipo1** → +5 puntos
- **Escudo Tipo2** → +10 puntos
- Mostrar puntuación en consola

---

## 🏗️ Configuración de la Escena

### 1. TAGS necesarios
Asegúrate de tener estos tags:
- `Player` (para el jugador que recoge escudos)
- `EscudoTipo1`
- `EscudoTipo2`

---

### 2. GESTOR DE JUEGO (GameObject vacío)

Crea un GameObject vacío llamado "GameManager" o "GestorJuego":

#### A. Script `Notificador5`:
1. Añade el componente **`Notificador5`**
2. No requiere configuración adicional

#### B. Script `GestorPuntuacion5`:
1. Añade el componente **`GestorPuntuacion5`**
2. En el Inspector:
   - **Notificador**: Arrastra el mismo GameObject (que tiene Notificador5)

---

### 3. JUGADOR

Configura el objeto del jugador (humanoide, cubo, etc.):

1. Asigna el **Tag: `Player`**
2. Añade un **Collider** (puede ser trigger o normal)
3. Si quieres controlar el jugador, añade un controlador de movimiento

**Importante**: El jugador debe poder moverse para recoger escudos. Puedes usar:
- Un script de movimiento simple
- El script `PlayerController` que ya tienes
- Controles manuales arrastrándolo en la escena

---

### 4. ESCUDOS TIPO 1

Para cada escudo Tipo1:

1. Asigna el **Tag: `EscudoTipo1`**
2. Añade el componente **`Escudo5`**
3. Configura el **Collider**:
   - Marca **"Is Trigger"** ✓ (recomendado)
   - O déjalo como collider normal (también funciona)
4. En el componente `Escudo5`:
   - **Puntos Al Recoger**: Se configura automáticamente a 5
   - **Tipo Escudo**: Se configura automáticamente a "Tipo1"

---

### 5. ESCUDOS TIPO 2

Para cada escudo Tipo2:

1. Asigna el **Tag: `EscudoTipo2`**
2. Añade el componente **`Escudo5`**
3. Configura el **Collider**:
   - Marca **"Is Trigger"** ✓ (recomendado)
   - O déjalo como collider normal (también funciona)
4. En el componente `Escudo5`:
   - **Puntos Al Recoger**: Se configura automáticamente a 10
   - **Tipo Escudo**: Se configura automáticamente a "Tipo2"

---

## 🎮 Cómo funciona

### Flujo de recolección:

```
Jugador toca escudo
  ↓
Escudo5 detecta colisión/trigger con "Player"
  ↓
Escudo5 notifica a Notificador5 con los puntos
  ↓
Notificador5 dispara evento OnEscudoRecogido
  ↓
GestorPuntuacion5 recibe el evento y suma puntos
  ↓
Se muestra la puntuación en consola
  ↓
El escudo se destruye
```

---

## 📊 Ejemplo de salida en consola

```
[GestorPuntuacion5] Sistema de puntuación inicializado
[Notificador5] Escudo Tipo1 recogido → +5 puntos
★★★ PUNTUACIÓN ACTUAL: 5 puntos ★★★
[Shield_Type1] Escudo Tipo1 destruido

[Notificador5] Escudo Tipo2 recogido → +10 puntos
★★★ PUNTUACIÓN ACTUAL: 15 puntos ★★★
[Shield_Type2] Escudo Tipo2 destruido

[Notificador5] Escudo Tipo1 recogido → +5 puntos
★★★ PUNTUACIÓN ACTUAL: 20 puntos ★★★
[Shield_Type1_2] Escudo Tipo1 destruido
```

---

## ✅ Checklist de configuración

- [ ] Tag `Player` creado y asignado al jugador
- [ ] Tags `EscudoTipo1` y `EscudoTipo2` creados
- [ ] GameObject "GameManager" con componentes:
  - [ ] `Notificador5`
  - [ ] `GestorPuntuacion5` con referencia a Notificador5
- [ ] Jugador tiene:
  - [ ] Tag `Player`
  - [ ] Collider
  - [ ] Script de movimiento (opcional pero recomendado)
- [ ] Escudos Tipo1 tienen:
  - [ ] Tag `EscudoTipo1`
  - [ ] Componente `Escudo5`
  - [ ] Collider con "Is Trigger" marcado
- [ ] Escudos Tipo2 tienen:
  - [ ] Tag `EscudoTipo2`
  - [ ] Componente `Escudo5`
  - [ ] Collider con "Is Trigger" marcado

---

## 🐛 Troubleshooting

**No se recogen los escudos:**
- Verifica que el jugador tiene el tag `Player`
- Verifica que los escudos tienen colliders con "Is Trigger" marcado
- Verifica que el jugador tiene un collider (o Rigidbody si no es trigger)

**No se muestra la puntuación:**
- Verifica que el `GestorPuntuacion5` tiene asignado el `Notificador5`
- Mira la consola de Unity para ver los logs

**Error: No se encontró Notificador5:**
- Asegúrate de que hay un GameObject con el componente `Notificador5` en la escena

**Los escudos no se destruyen:**
- Verifica que el componente `Escudo5` está en los escudos
- Verifica que la colisión se está detectando (mira los logs)

---

## 🎨 Mejoras opcionales

Para hacer el ejercicio más completo, puedes:

1. **Añadir UI de puntuación** (canvas con texto)
2. **Efectos de sonido** al recoger escudos
3. **Partículas** cuando se recoge un escudo
4. **Diferentes colores** para escudos Tipo1 (azul) y Tipo2 (dorado)
5. **Límite de tiempo** para recoger escudos
6. **Combo multiplier** si recoges varios seguidos

---

## 📝 Notas importantes

- Los escudos se **destruyen automáticamente** al ser recogidos
- Cada escudo solo puede ser recogido **una vez**
- El sistema usa el **patrón Observer** (delegado + evento)
- Los puntos se configuran automáticamente según el tag del escudo
- Funciona con **Trigger** (recomendado) o **Collision** normal
