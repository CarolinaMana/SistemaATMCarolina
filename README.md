# Sistema de Cajero Automático (ATM)

Este proyecto consiste en la evolución estructurada del Mini ATM de consola desarrollado en C#. El objetivo principal es la reorganización lógica mediante métodos reutilizables con responsabilidades bien delimitadas, aplicando de forma estricta los conceptos de paso de parámetros, argumentos por referencia y valores de retorno.

## Estructura de Métodos Implementados
- MostrarMenu(): Controla y limpia de forma exclusiva la visualización de opciones en pantalla.
- ConsultarSaldo(decimal): Recibe el estado financiero actual del ciclo de sesión y lo imprime con formato legible.
- CuentaEstaActiva(bool): Valida de forma segura las condiciones lógicas de acceso de la cuenta en memoria.
- LeerMonto(string, out decimal): Centraliza de manera segura la captura del teclado y conversión de caracteres numéricos.
- Depositar(decimal, decimal) / Retirar(decimal, decimal): Ejecutan las operaciones aritméticas de negocio devolviendo los saldos resultantes actualizados.

## Pseudocódigo del Algoritmo
```text
Algoritmo SistemaATM
    Definir saldo Como Decimal
    Definir cuentaActiva Como Logico
    Definir opcion Como Entero
    saldo <- 10000.00
    cuentaActiva <- Verdadero
    opcion <- 0
    Hacer
        Invocación MostrarMenu()
        Leer opcion
        Segun opcion Hacer
            1: Invocación ConsultarSaldo(saldo)
            2: saldo <- Invocación ProcesarDeposito(saldo, cuentaActiva)
            3: saldo <- Invocación ProcesarRetiro(saldo, cuentaActiva)
            4: Escribir "Thank you for using our ATM services. Goodbye!"
            De Otro Modo: Escribir "Invalid option."
        FinSegun
    Mientras Que opcion != 4
FinAlgoritmo
```

## Matriz de Trazabilidad (RF -> RN -> CU -> CP)

| Requerimiento Funcional (RF) | Regla de Negocio (RN) | Caso de Uso (CU) | Caso de Prueba (CP) |
| :--- | :--- | :--- | :--- |
| RF-01, RF-02, RF-09, RF-10 | RN-08, RN-09 | CU-04, CU-05 | CP-07, CP-08 |
| RF-03, RF-11, RF-15 | RN-10 | CU-01 | CP-01 |
| RF-04, RF-06, RF-07, RF-12, RF-13, RF-14, RF-15 | RN-01, RN-02, RN-05, RN-07 | CU-02 | CP-02, CP-04, CP-06, CP-09, CP-10 |
| RF-05, RF-06, RF-07, RF-08, RF-12, RF-13, RF-14, RF-15 | RN-01, RN-03, RN-04, RN-06, RN-07 | CU-03 | CP-03, CP-05, CP-06, CP-09, CP-10 |

## Instrucciones para Compilación y Ejecución
1. Asegúrese de contar con el entorno de desarrollo oficial de .NET SDK instalado en su equipo.
2. Abra su terminal o consola de comandos preferida en el directorio raíz donde se ubican los archivos fuente.
3. Ejecute las siguientes sentencias nativas del sistema:
   ```bash
   dotnet build
   dotnet run
   ```
