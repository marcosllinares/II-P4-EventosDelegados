# 📋 Instrucciones para Ejercicio 3

## 🎯 Objetivo
Crear una escena con humanoides Tipo1 y Tipo2, escudos Tipo1 y Tipo2, donde:
- **Cubo toca Humanoide Tipo2** → Humanoides Tipo1 van a escudo Tipo1 seleccionado
- **Cubo toca Humanoide Tipo1** → Humanoides Tipo1 van a escudos Tipo2 más cercanos
- **Humanoide toca Escudo** → Cambia de color

---

## 🏗️ Configuración de la Escena

### 1. TAGS necesarios en Unity
Ve a `Edit > Project Settings > Tags and Layers` y crea estos tags:
- `Tipo1`
- `Tipo2`
- `EscudoTipo1`
- `EscudoTipo2`

---

### 2. CUBO (Notificador)
1. Crea/selecciona el cubo en la escena
2. Añade el componente **`Notificador`**
3. Asegúrate de que tiene un **Rigidbody** (para detectar colisiones)
4. Asegúrate de que tiene un **Collider**

---

### 3. HUMANOIDES TIPO 1
Para cada humanoide rojo/guerrero:

#### A. Configuración básica:
1. Asigna el **Tag: `Tipo1`**
2. Añade **Collider** (para que el cubo pueda colisionar con él)
3. Añade **Rigidbody** (marca "Is Kinematic" si no quieres que se caiga)

#### B. Script `Respuesta`:
1. Añade el componente **`Respuesta`**
2. En el Inspector:
   - **Notificador**: Arrastra el GameObject del Cubo
   - **Escudo Tipo1 Seleccionado**: Arrastra un escudo específico Tipo1
   - **Tag Escudos Tipo2**: Debe ser `EscudoTipo2` (ya viene por defecto)
   - **Velocidad**: Ajusta según prefieras (ej: 3)

#### C. Script `CambioColorAlTocarEscudo`:
1. Añade el componente **`CambioColorAlTocarEscudo`**
2. En el Inspector:
   - **Tag Escudos**: `EscudoTipo2` (para cambiar al tocar escudos Tipo2)
   - **Nuevo Color**: Elige el color que quieras (ej: amarillo)

---

### 4. HUMANOIDES TIPO 2
Para cada humanoide verde/mago:

1. Asigna el **Tag: `Tipo2`**
2. Añade **Collider**
3. Añade **Rigidbody** (marca "Is Kinematic" si no quieres que se caiga)
4. **NO necesitan** scripts adicionales (solo sirven como "gatillo" para el evento)

---

### 5. ESCUDOS TIPO 1
Para cada escudo Tipo1:

1. Asigna el **Tag: `EscudoTipo1`**
2. Añade **Collider**
3. Opcionalmente **Rigidbody** si quieres que sea físico
4. **NO necesitan** scripts

---

### 6. ESCUDOS TIPO 2
Para cada escudo Tipo2:

1. Asigna el **Tag: `EscudoTipo2`**
2. Añade **Collider**
3. Opcionalmente **Rigidbody** si quieres que sea físico
4. **NO necesitan** scripts

---

## 🎮 Cómo funciona

### Evento 1: Cubo toca Humanoide Tipo2
```
Cubo colisiona con Tipo2
  ↓
Notificador.OnColisionConTipo2 se dispara
  ↓
Todos los Tipo1 se mueven hacia el escudo Tipo1 seleccionado
```

### Evento 2: Cubo toca Humanoide Tipo1
```
Cubo colisiona con Tipo1
  ↓
Notificador.OnColisionConTipo1 se dispara
  ↓
Todos los Tipo1 buscan el escudo Tipo2 más cercano y van hacia él
```

### Evento 3: Humanoide toca Escudo
```
Humanoide colisiona con escudo
  ↓
CambioColorAlTocarEscudo detecta la colisión
  ↓
El humanoide cambia de color
```

---

## ✅ Checklist Final

- [ ] Tags creados: Tipo1, Tipo2, EscudoTipo1, EscudoTipo2
- [ ] Cubo tiene componente `Notificador` + Rigidbody + Collider
- [ ] Humanoides Tipo1 tienen:
  - Tag `Tipo1`
  - Componente `Respuesta` con Notificador asignado
  - Componente `CambioColorAlTocarEscudo`
  - Collider + Rigidbody
- [ ] Humanoides Tipo2 tienen:
  - Tag `Tipo2`
  - Collider + Rigidbody
- [ ] Escudos Tipo1 tienen Tag `EscudoTipo1` + Collider
- [ ] Escudos Tipo2 tienen Tag `EscudoTipo2` + Collider
- [ ] En cada `Respuesta` está asignado el GameObject del Cubo en "Notificador"
- [ ] En cada `Respuesta` está asignado un escudo específico en "Escudo Tipo1 Seleccionado"

---

## 🐛 Troubleshooting

**Error: NullReferenceException en Respuesta.Start**
- Verifica que has arrastrado el Cubo al campo "Notificador" en TODOS los humanoides Tipo1

**Los humanoides no se mueven:**
- Verifica que el cubo tiene Rigidbody
- Verifica que los tags están bien asignados
- Mira los logs en la consola para ver si se disparan los eventos

**No cambia de color al tocar escudo:**
- Verifica que el escudo tiene el tag correcto
- Verifica que ambos tienen Colliders
- El componente necesita un Renderer en el humanoide

---

## 📝 Notas

- Los **Tipo2 no se mueven** en este ejercicio (solo sirven como gatillo)
- Solo los **Tipo1 responden** a los eventos y se mueven
- Puedes tener **múltiples escudos** de cada tipo
- Los humanoides buscan el escudo Tipo2 **más cercano** automáticamente
