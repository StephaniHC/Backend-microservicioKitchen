[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/52Oc7Ap-)
# 📦 Microservicio "Cocina"

## **Descripción General**  
El microservicio **"Cocina"** gestiona la preparación de recetas, los paquetes asociados, ingredientes utilizados y el administrador de cocina. Está compuesto por entidades, agregados y objetos de valor que organizan la información de forma eficiente.



## **Componentes Principales**  

El diagrama se compone de las siguientes entidades y objetos de valor:

### 📌 **Package**  
- **Descripción**: Representa un paquete con información básica y detalles importantes encapsulados en `Label`.  
- **Atributos**:  
  - `id`: Identificador único del paquete.  
  - `status`: Estado del paquete.  
- **Label** (*Value Object*):  
  - `BatchCode`, `ProductionDate`, `ExpirationDate`, `detail`, `PatientId`, `Address`.  

### 📌 **PreparedRecipe**  
- **Descripción**: Representa una receta preparada con fecha y estado. Es un **agregado** que une recetas y el administrador de cocina.  
- **Atributos**:  
  - `id`: Identificador único.  
  - `date`: Fecha de la preparación.  
  - `status`: Estado (activo o inactivo).  

### 📌 **Recipe**  
- **Descripción**: Representa una receta con un nombre y tiempo de preparación.  
- **Atributos**:  
  - `id`: Identificador único.  
  - `name`: Nombre de la receta.  
  - `PreparationTime`: Tiempo requerido para su preparación.  

### 📌 **IngredientRecipe**  
- **Descripción**: Detalla los ingredientes de una receta específica.  
- **Atributos**:  
  - `id`: Identificador único.  
  - `quantity`: Cantidad del ingrediente.  
  - `MeasureUnit`: Unidad de medida.  

### 📌 **Ingredient** (*Value Object*)  
- **Descripción**: Representa un ingrediente con su nombre.  
- **Atributos**:  
  - `name`: Nombre del ingrediente.  

### 📌 **KitchenManager**  
- **Descripción**: Representa al gestor de cocina responsable de la preparación de recetas.  
- **Atributos**:  
  - `id`: Identificador único.  
  - `name`: Nombre del gestor.  
  - `shift`: Turno de trabajo.  

---

## **Funcionalidades del Microservicio**  

### 🔹 **Gestión de Paquete**  
- **Crear un Paquete**:  
  Registrar un paquete con su estado y los detalles de la etiqueta asociada.  
- **Leer un Paquete**:  
  Consultar el `id`, `status` y los datos de la etiqueta.

### 🔹 **Gestión de Recetas Preparadas**  
- **Crear una Receta Preparada**:  
  Guardar una receta preparada con fecha, estado y recetas asociadas.  
- **Leer una Receta Preparada**:  
  Obtener detalles del `id`, fecha y lista de recetas asociadas.

### 🔹 **Gestión de Recetas**  
- **Crear una Receta**:  
  Registrar una receta con su nombre y tiempo de preparación.  
- **Leer una Receta**:  
  Mostrar los detalles de la receta junto con sus ingredientes.

### 🔹 **Gestión de Ingredientes**  
- **Crear un Ingrediente**:  
  Asociar un ingrediente a una receta con su cantidad y unidad de medida.  
- **Leer Ingredientes**:  
  Mostrar los ingredientes utilizados en una receta específica.

### 🔹 **Gestión del KitchenManager**  
- **Crear un KitchenManager**:  
  Registrar los datos del gestor de cocina (nombre y turno).  
- **Leer un KitchenManager**:  
  Consultar la información del gestor.

---
