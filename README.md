# TrabajoFinalPOO
Trabajo de practica final de POO
Título de proyecto software:
1. IntroducciónSe le solicita que desarrolle un programa orientado a objetos utilizando los conceptos abordados en laasignatura. 
El mismo tiene como objetivo observar cómo aplica los temas abordados en su elaboración.
2. ObjetivosDesarrollar un programa que le permita a una institución comercial administrar los cobros pendientes quedeben realizarse a los clientes de la empresa.
Nos informan que existen dos tipos de cobros. Los normales y los especiales. Cuando se genera un cobro sele asigna al cliente seleccionado en la Grilla 1.
Todos se identifican por un código, fecha de vencimiento, elimporte a cobrar y el cliente a quien se le cobró.
De los clientes mantenemos un legajo y el nombre. Loscobros cuando se realizan después de la fecha de vencimiento abonan, si son normales un 10% adicional ylos especiales un 20% adicional. 
Los importes calculados por retraso se realizan al momento de recepcionarel pago y deben visualizarse discriminados además del total abonado.No se aceptan pagos parciales.
Al momento que un cliente paga (botón pagar), se le debe informar en un MessageBox:Importe a pagarEl recargo si correspondeEl total (importe a pagar más el recargo si corresponde)Una vez aceptado el MessageBox el cobro se da por pagado y cancela la deuda. 
Si el importe total a pagar damás de 10.000 pesos se debe desencadenar un evento que informe sobre esta situación.
También nos informan que un cliente no puede tener pendientes más de dos importes al cobro.Nos solicitan:1. En la Grilla 1, poder realizar el ABM de los clientes.
4. En la Grilla 2, los cobros pendientes del cliente seleccionado en la Grilla 1. Al dar de alta un cobrosiempre se asigna al cliente seleccionado en la grilla 1. Los cobros una vez dados de alta no sepueden borrar ni modificar y no pueden existir cobros que no correspondan a un cliente.
5. En la Grilla 3, los cobros pagados del cliente seleccionado en la Grilla 1 (usar LinQ)
6. (Opcional) En la Grilla 4, los cobros pagados del cliente seleccionado en la Grilla 1 ordenados porimporte total de mayor a menor y viceversa. (utilizar IComparable y radioButtons paraseleccionar el criterio).
7. (Opcional) En la Grilla 5, los cobros pagados solo con los siguientes datos (Nombre del cliente,Importe total cancelado). (Usar LinQ y tipos anónimos)Todas las grillas deben estar en el mismo formulario. No utilizar controles de tipo menú.
Validar todos los datos para que no existan datos repetidos (p.e. legajos, códigos etc)
Utilizar Try ... Catch para administrar las excepciones del sistema.Observe la usabilidad (fácil de utilizar por el usuario, cantidad de clic para una operación, suma claridad en loque el usuario debe realizar para utilizar en sistema)
