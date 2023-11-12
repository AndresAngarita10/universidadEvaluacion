# Universidad

Este proyecto proporciona una API que permite gestionar el apartado de la administración de una universidad incluyendo los docentes, alumnos, asignaturas, grados, creditos y cursos

## Características 🌟

- Registro de usuarios.
- CRUD completo para cada entidad.
- Vista de las consultas requeridas.

## Desarrollo de los Endpoints requeridos⌨️

## 1. Devuelve un listado con el primer apellido, segundo apellido y el nombre de todos los alumnos. El listado deberá estar ordenado alfabéticamente de menor a mayor por el primer apellido, segundo apellido y nombre.

	    http://localhost:5272/api/persona/consulta1
     ![image](https://github.com/AndresAngarita10/universidadEvaluacion/assets/106509898/e8859758-1458-4603-a7d8-49f816af42f5)


## 2. Averigua el nombre y los dos apellidos de los alumnos que **no** han dado de alta su número de teléfono en la base de datos.

	    http://localhost:5272/api/persona/consulta2
     ![image](https://github.com/AndresAngarita10/universidadEvaluacion/assets/106509898/c83aa08f-a538-45d0-9e20-c5eca7cacff7)


## 3. Devuelve el listado de los alumnos que nacieron en `1999`.

	    http://localhost:5272/api/persona/consulta3
     ![image](https://github.com/AndresAngarita10/universidadEvaluacion/assets/106509898/48612e3a-7cda-44db-b4ef-ebda06a73fb9)


## 4. Devuelve el listado de `profesores` que **no** han dado de alta su número de teléfono en la base de datos y además su nif termina en `K`.

	    http://localhost:5272/api/persona/consulta4
     ![image](https://github.com/AndresAngarita10/universidadEvaluacion/assets/106509898/7675eec0-4a4e-4eed-a9f8-df208587a293)


## 5. Devuelve el listado de las asignaturas que se imparten en el primer cuatrimestre, en el tercer curso del grado que tiene el identificador `7`.

	    http://localhost:5272/api/asignatura/consulta5
     ![image](https://github.com/AndresAngarita10/universidadEvaluacion/assets/106509898/1017435c-92dd-43fa-a67b-e67d28b99c25)


## 6. Devuelve un listado con los datos de todas las **alumnas** que se han matriculado alguna vez en el `Grado en Ingeniería Informática (Plan 2015)`.

	    http://localhost:5272/api/persona/consulta6
     ![image](https://github.com/AndresAngarita10/universidadEvaluacion/assets/106509898/02582401-f0c2-42fa-bf10-5c4a10ab52e9)


## 7. Devuelve un listado con todas las asignaturas ofertadas en el `Grado en Ingeniería Informática (Plan 2015)`.

	    http://localhost:5272/api/persona/consulta7
     ![image](https://github.com/AndresAngarita10/universidadEvaluacion/assets/106509898/d3e67c1f-3d85-4c27-bb2d-d926c35381c0)


## 8. Devuelve un listado de los `profesores` junto con el nombre del `departamento` al que están vinculados. El listado debe devolver cuatro columnas, `primer apellido, segundo apellido, nombre y nombre del departamento.` El resultado estará ordenado alfabéticamente de menor a mayor por los `apellidos y el nombre.`

	    http://localhost:5272/api/persona/consulta8
     ![image](https://github.com/AndresAngarita10/universidadEvaluacion/assets/106509898/49898415-692a-460e-8173-9f6db59bc220)


## 9. Devuelve un listado con el nombre de las asignaturas, año de inicio y año de fin del curso escolar del alumno con nif `26902806M`.

	    http://localhost:5272/api/asignatura/consulta9
     ![image](https://github.com/AndresAngarita10/universidadEvaluacion/assets/106509898/28577062-b0c9-4d7d-9881-7f71f5d784ca)


## 10. Devuelve un listado con el nombre de todos los departamentos que tienen profesores que imparten alguna asignatura en el `Grado en Ingeniería Informática (Plan 2015)`.

 	    http://localhost:5272/api/profesor/consulta10
      ![image](https://github.com/AndresAngarita10/universidadEvaluacion/assets/106509898/46eed404-607c-42dc-900a-aafd4113eb84)


## 11. Devuelve un listado con todos los alumnos que se han matriculado en alguna asignatura durante el curso escolar 2018/2019.

 	    http://localhost:5272/api/persona/consulta11
      ![image](https://github.com/AndresAngarita10/universidadEvaluacion/assets/106509898/7bad807b-326a-4029-a005-b50df8594aef)


## 12. Devuelve un listado con los nombres de **todos** los profesores y los departamentos que tienen vinculados. El listado también debe mostrar aquellos profesores que no tienen ningún departamento asociado. El listado debe devolver cuatro columnas, nombre del departamento, primer apellido, segundo apellido y nombre del profesor. El resultado estará ordenado alfabéticamente de menor a mayor por el nombre del departamento, apellidos y el nombre.

 	    http://localhost:5272/api/persona/consulta12
      ![image](https://github.com/AndresAngarita10/universidadEvaluacion/assets/106509898/8ebb5ab3-6d02-4055-9e5f-913b8a44abab)


## 13. Devuelve un listado con los profesores que no están asociados a un departamento.Devuelve un listado con los departamentos que no tienen profesores asociados.

 	    http://localhost:5272/api/departamento/consulta13
      ![image](https://github.com/AndresAngarita10/universidadEvaluacion/assets/106509898/1a2a340c-662f-40a0-af52-265b9da31f69)


## 14. Devuelve un listado con los profesores que no imparten ninguna asignatura.

 	    http://localhost:5272/api/profesor/consulta14
      ![image](https://github.com/AndresAngarita10/universidadEvaluacion/assets/106509898/c0c907a6-7caf-4e54-a50c-a200eeeaa609)


## 15. Devuelve un listado con las asignaturas que no tienen un profesor asignado.

 	    http://localhost:5272/api/asignatura/consulta15
      ![image](https://github.com/AndresAngarita10/universidadEvaluacion/assets/106509898/ef1fbbff-21da-4542-8e9e-7c28ddbbfbc9)


## 16. Devuelve un listado con todos los departamentos que tienen alguna asignatura que no se haya impartido en ningún curso escolar. El resultado debe mostrar el nombre del departamento y el nombre de la asignatura que no se haya impartido nunca.

 	    http://localhost:5272/api/asignatura/consulta16
      ![image](https://github.com/AndresAngarita10/universidadEvaluacion/assets/106509898/0b0aeb91-cb21-4f6a-8151-ba69e00772dc)


## 17. Devuelve el número total de **alumnas** que hay.

 	    http://localhost:5272/api/persona/consulta17
      ![image](https://github.com/AndresAngarita10/universidadEvaluacion/assets/106509898/266933c9-0db4-49ac-a136-781fd090f497)


## 18. Calcula cuántos alumnos nacieron en `1999`.

 	    http://localhost:5272/api/persona/consulta18
      ![image](https://github.com/AndresAngarita10/universidadEvaluacion/assets/106509898/81510163-020b-42df-bda5-2d58ba4e377f)


## 19. Calcula cuántos profesores hay en cada departamento. El resultado sólo debe mostrar dos columnas, una con el nombre del departamento y otra con el número de profesores que hay en ese departamento. El resultado sólo debe incluir los departamentos que tienen profesores asociados y deberá estar ordenado de mayor a menor por el número de profesores.

 	    http://localhost:5272/api/persona/consulta19
      ![image](https://github.com/AndresAngarita10/universidadEvaluacion/assets/106509898/1e3d540d-6cf4-4012-95ac-d6b5c599501c)


## 20. Devuelve un listado con todos los departamentos y el número de profesores que hay en cada uno de ellos. Tenga en cuenta que pueden existir departamentos que no tienen profesores asociados. Estos departamentos también tienen que aparecer en el listado.

 	    http://localhost:5272/api/departamento/consulta20
      ![image](https://github.com/AndresAngarita10/universidadEvaluacion/assets/106509898/85f6700c-f884-4cea-a480-682abf6e62f9)


## 21. Devuelve un listado con el nombre de todos los grados existentes en la base de datos y el número de asignaturas que tiene cada uno. Tenga en cuenta que pueden existir grados que no tienen asignaturas asociadas. Estos grados también tienen que aparecer en el listado. El resultado deberá estar ordenado de mayor a menor por el número de asignaturas.

 	    http://localhost:5272/api/grado/consulta21
      ![image](https://github.com/AndresAngarita10/universidadEvaluacion/assets/106509898/0825aacf-7cc7-4161-8a1d-90eb250156fd)


## 22. Devuelve un listado con el nombre de todos los grados existentes en la base de datos y el número de asignaturas que tiene cada uno, de los grados que tengan más de `40` asignaturas asociadas.

 	    http://localhost:5272/api/grado/consulta22
      ![image](https://github.com/AndresAngarita10/universidadEvaluacion/assets/106509898/301ba8d8-d610-4d40-a588-2f8cf98b0e15)


## 23. Devuelve un listado que muestre el nombre de los grados y la suma del número total de créditos que hay para cada tipo de asignatura. El resultado debe tener tres columnas: nombre del grado, tipo de asignatura y la suma de los créditos de todas las asignaturas que hay de ese tipo. Ordene el resultado de mayor a menor por el número total de crédidos.

 	    http://localhost:5272/api/grado/consulta23
      ![image](https://github.com/AndresAngarita10/universidadEvaluacion/assets/106509898/e927293c-a6b7-417a-b83a-b6f033bcbb70)


## 24. Devuelve un listado que muestre cuántos alumnos se han matriculado de alguna asignatura en cada uno de los cursos escolares. El resultado deberá mostrar dos columnas, una columna con el año de inicio del curso escolar y otra con el número de alumnos matriculados.

 	    http://localhost:5272/api/matricula/consulta24
      ![image](https://github.com/AndresAngarita10/universidadEvaluacion/assets/106509898/12e3fc71-36e2-4e31-8b17-b93fba50a31d)


## 25. Devuelve un listado con el número de asignaturas que imparte cada profesor. El listado debe tener en cuenta aquellos profesores que no imparten ninguna asignatura. El resultado mostrará cinco columnas: id, nombre, primer apellido, segundo apellido y número de asignaturas. El resultado estará ordenado de mayor a menor por el número de asignaturas.

 	    http://localhost:5272/api/persona/consulta25
      ![image](https://github.com/AndresAngarita10/universidadEvaluacion/assets/106509898/1eebe6ec-de0c-4092-9b7f-bc1691d73e56)


## 26. Devuelve todos los datos del alumno más joven.

 	    http://localhost:5272/api/persona/consulta26
      ![image](https://github.com/AndresAngarita10/universidadEvaluacion/assets/106509898/e6f2965d-cfe6-49cf-9dff-ce6ee380174a)


## 27. Devuelve un listado con los profesores que no están asociados a un departamento.

 	    http://localhost:5272/api/persona/consulta27
      ![image](https://github.com/AndresAngarita10/universidadEvaluacion/assets/106509898/c6f6d409-12d4-4ded-a6d7-0589389eb4a3)


## 28. Devuelve un listado con los departamentos que no tienen profesores asociados.

 	    http://localhost:5272/api/persona/consulta28
      ![image](https://github.com/AndresAngarita10/universidadEvaluacion/assets/106509898/7252797a-afff-4101-a039-ffe27a18c9c4)


## 29. Devuelve un listado con los profesores que tienen un departamento asociado y que no imparten ninguna asignatura.

 	    http://localhost:5272/api/persona/consulta29
      ![image](https://github.com/AndresAngarita10/universidadEvaluacion/assets/106509898/d92d2341-56c3-408f-bead-af9e306b4ce7)


## 30. Devuelve un listado con las asignaturas que no tienen un profesor asignado.

 	    http://localhost:5272/api/asignatura/consulta30
      ![image](https://github.com/AndresAngarita10/universidadEvaluacion/assets/106509898/38d4db24-4d92-45ea-98dd-abf0fbb25d99)


## 31. Devuelve un listado con todos los departamentos que no han impartido asignaturas en ningún curso escolar.

 	    http://localhost:5272/api/departamento/consulta31
      ![image](https://github.com/AndresAngarita10/universidadEvaluacion/assets/106509898/ce6add01-3cc0-4724-bff7-c10e003f6e0f)



## Desarrollo ⌨️
Este proyecto utiliza varias tecnologías y patrones, incluidos:

Entity Framework Core para la ORM.
Patrón Repository y Unit of Work para la gestión de datos.
AutoMapper para el mapeo entre entidades y DTOs.

## Agradecimientos 

A todas las librerías y herramientas utilizadas en este proyecto.

