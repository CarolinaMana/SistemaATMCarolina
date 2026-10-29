namespace SistemaATMCarolina
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal saldo = 10000.00m;
            bool cuentaActiva = true;
            int opcion = 0;

            do
            {
                MostrarMenu();
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            ConsultarSaldo(saldo);
                            break;
                        case 2:
                            saldo = ProcesarDeposito(saldo, cuentaActiva);
                            break;
                        case 3:
                            saldo = ProcesarRetiro(saldo, cuentaActiva);
                            break;
                        case 4:
                            Console.WriteLine("\n¡Gracias por utilizar nuestros servicios financieros! Hasta luego.");
                            break;
                        default:
                            Console.WriteLine("\n❌ Opción inválida. Por favor, intente de nuevo.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\n❌ Entrada inválida. Por favor, ingrese un número.");
                }

                if (opcion != 4)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 4);
        }

        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("               MINI ATM                 ");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Consultar Saldo");
            Console.WriteLine("2. Depositar Fondos");
            Console.WriteLine("3. Retirar Fondos");
            Console.WriteLine("4. Salir");
            Console.WriteLine("========================================");
            Console.Write("Seleccione una opción: ");
        }

        static void ConsultarSaldo(decimal saldoActual)
        {
            Console.WriteLine($"\n💰 Saldo Actual: RD${saldoActual:N2}");
        }

        static bool CuentaEstaActiva(bool estado)
        {
            return estado;
        }

        static bool LeerMonto(string mensaje, out decimal monto)
        {
            Console.Write(mensaje);
            return decimal.TryParse(Console.ReadLine(), out monto);
        }

        static decimal ProcesarDeposito(decimal saldoActual, bool estadoCuenta)
        {
            if (!CuentaEstaActiva(estadoCuenta))
            {
                Console.WriteLine("\n❌ Transacción rechazada. La cuenta está inactiva.");
                return saldoActual;
            }

            decimal monto;
            if (LeerMonto("\nIngrese el monto a depositar: RD$", out monto))
            {
                return Depositar(saldoActual, monto);
            }

            Console.WriteLine("\n❌ Monto ingresado inválido.");
            return saldoActual;
        }

        static decimal Depositar(decimal saldo, decimal monto)
        {
            if (monto <= 0)
            {
                Console.WriteLine("\n❌ Error: El monto del depósito debe ser mayor a cero.");
                return saldo;
            }

            decimal nuevoSaldo = saldo + monto;
            Console.WriteLine($"\n✅ ¡Depósito exitoso! RD${monto:N2} agregados a su cuenta.");
            return nuevoSaldo;
        }

        static decimal ProcesarRetiro(decimal saldoActual, bool estadoCuenta)
        {
            if (!CuentaEstaActiva(estadoCuenta))
            {
                Console.WriteLine("\n❌ Transacción rechazada. La cuenta está inactiva.");
                return saldoActual;
            }

            decimal monto;
            if (LeerMonto("\nIngrese el monto a retirar: RD$", out monto))
            {
                return Retirar(saldoActual, monto);
            }

            Console.WriteLine("\n❌ Monto ingresado inválido.");
            return saldoActual;
        }

        static decimal Retirar(decimal saldo, decimal monto)
        {
            if (monto <= 0)
            {
                Console.WriteLine("\n❌ Error: El monto del retiro debe ser mayor a cero.");
                return saldo;
            }

            if (monto > saldo)
            {
                Console.WriteLine("\n❌ Error: Fondos insuficientes.");
                return saldo;
            }

            decimal nuevoSaldo = saldo - monto;
            Console.WriteLine($"\n✅ ¡Retiro exitoso! RD${monto:N2} descontados de su cuenta.");
            return nuevoSaldo;
        }
    }
}
