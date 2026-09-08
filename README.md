# 📦 GoXela Delivery

> Sistema de gestión de entregas y logística desarrollado en C# aplicando los principios de la Programación Orientada a Objetos (POO).

Proyecto académico desarrollado para el curso de **Programación Avanzada** de la **Facultad de Ingeniería, Universidad Rafael Landívar (Campus Quetzaltenango)**.

---

## 🚀 Descripción del Proyecto
**GoXela Delivery** es una aplicación de consola diseñada para administrar de manera eficiente las operaciones de una empresa local de entregas dentro de Quetzaltenango y sus al rededores. El sistema cubre todo el ciclo de vida de un servicio: desde el registro de clientes y la asignación inteligente de repartidores y vehículos (según capacidad, peso y tipo de paquete), hasta el cálculo automático de tarifas, control de estados, gestión de incidencias y generación de reportes operativos.

---

## 🛠️ Tecnologías y Conceptos Aplicados
El proyecto fue construido en **C#** utilizando la consola como interfaz, evidenciando los siguientes pilares de la programación avanzada:
* **Programación Orientada a Objetos (POO):** Clases, objetos, constructores y métodos organizados por módulos.
* **Encapsulamiento:** Protección de atributos mediante propiedades y validaciones de datos (pesos, distancias, capacidades y estados).
* **Herencia y Sobrescritura:** Jerarquías definidas para *Personas* (Clientes, Repartidores), *Vehículos* (Bicicletas, Motocicletas, Automóviles) y *Paquetes* (Documentos, Estándares, Frágiles, Refrigerados).
* **Polimorfismo:** Implementación de comportamientos dinámicos, como el cálculo de tarifas y la validación de transporte según el tipo de paquete o vehículo.
* **Sobrecarga (Overload):** Uso de métodos y constructores sobrecargados.
* **Recursividad:** Funciones recursivas implementadas para el procesamiento de reportes y búsqueda de entregas.
* **Manejo de Excepciones y Validaciones:** Control de errores de entrada, códigos duplicados y flujos de estados incorrectos.

---

## 📋 Módulos Principales del Sistema
El menú general del sistema permite interactuar con los siguientes submódulos:
1. **Gestión de Clientes:** Registro, consulta y actualización de información.
2. **Gestión de Repartidores:** Control de disponibilidad, licencias y calificaciones.
3. **Gestión de Vehículos:** Administración de flotas (bicicletas, motos, autos) con validación de capacidad de carga.
4. **Gestión de Paquetes:** Clasificación por tipo (documentos, frágiles, refrigerados, etc.) y reglas específicas de transporte.
5. **Gestión de Entregas:** Creación de solicitudes y seguimiento estricto del flujo operativo:
   `Solicitada` ➡️ `Asignada` ➡️ `Recogida` ➡️ `En Ruta` ➡️ `Entregada` *(con opciones de cancelación, reprogramación o registro de incidencias).*
6. **Gestión de Incidencias:** Control de eventualidades imprevistas asociadas a las entregas.
7. **Reportes:** Visualización de entregas activas, finalizadas, ingresos totales, repartidores con más entregas, vehículos más utilizados, entre otros.

---

## ⚙️ Instrucciones de Ejecución
1. Clona este repositorio o descarga el código fuente:
   ```bash
   git clone [https://github.com/tu-usuario/goxela-delivery.git](https://github.com/tu-usuario/goxela-delivery.git)
