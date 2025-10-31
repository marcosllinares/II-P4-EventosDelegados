# Interfaces Inteligentes - Práctica 4 - Eventos y Delgados

**Autor:** Marcos Llinares Montes (alu0100972443)

## Ejercicios

versión unity: 6000.0.58f2

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notificador : MonoBehaviour
{
   
    public delegate void mensaje();
    public event mensaje OnMiEvento;
    public int contador;
```


```csharp
// Start is called before the first frame update
    void Start()
    {
        contador = 0;
    }
 // Update is called once per frame
    void Update()
    {
        contador = contador + 1;
        if (contador % 1000 == 0) {
            OnMiEvento();
        }
    }
}
```


```csharp
public class Respuesta : MonoBehaviour
{
    public Notificador notificador;
    // Start is called before the first frame update
    void Start()
    {
        notificador.OnMiEvento += miRespuesta;
    }
    // Update is called once per frame
    void Update()
    {
		
    }
    void miRespuesta(){
        Debug.Log("Soy el cilindro");
        Debug.Log(notificador.contador);
    }
}
```

---
```csharp
using UnityEngine;

public class Notificador : MonoBehaviour
{
    // Delegados para los diferentes tipos de colisión
    public delegate void ColisionConTipo1();
    public delegate void ColisionConTipo2();
    
    // Eventos
    public event ColisionConTipo1 OnColisionConTipo1;
    public event ColisionConTipo2 OnColisionConTipo2;
    
    private void OnCollisionEnter(Collision collision)
    {
        // Si colisiona con un humanoide Tipo1
        if (collision.collider.CompareTag("Tipo1"))
        {
            OnColisionConTipo1?.Invoke();
            Debug.Log("[Notificador] Colisión con Tipo1 → Tipo1 va hacia escudos Tipo2");
        }
        // Si colisiona con un humanoide Tipo2
        else if (collision.collider.CompareTag("Tipo2"))
        {
            OnColisionConTipo2?.Invoke();
            Debug.Log("[Notificador] Colisión con Tipo2 → Tipo1 va hacia escudo seleccionado Tipo1");
        }
    }
}
```


----

### Ejercicio 1

![a](https://imgur.com/pgmf081.gif)


### Ejercicio 2


![a](https://imgur.com/Gej0geb.gif)

### Ejercicio 3

![a](https://imgur.com/k84ggRD.gif)

![](https://i.imgur.com/NM4HdT5.png)


### Ejercicio 4

![a](https://imgur.com/v5VlGuc.gif)


### Ejercicio 6

![a](https://imgur.com/lkDpiXA.gif)

![](https://i.imgur.com/PE5zIWz.png)
![](https://i.imgur.com/X8qi8gv.png)

