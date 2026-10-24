Console.WriteLine("===== MINI ATM V1 =====");
string cliente = "Francisco Correa";
string numeroCuenta = "9605554485";
decimal saldo = 32195m;
bool cuentaActiva = true;
int opcion;

do
{
    Console.WriteLine("\n===== CAJERO AUTOMÁTICO =====");
    Console.WriteLine($"Cliente: {cliente}");
    Console.WriteLine($"Cuenta: {numeroCuenta}");
    Console.WriteLine($"Estado: {(cuentaActiva ? "Activa" : "Inactiva")}");
    Console.WriteLine("\n1. Consultar saldo");
    Console.WriteLine("2. Depositar");
    Console.WriteLine("3. Retirar");
    Console.WriteLine("4. Salir");
    Console.Write("\nSeleccione una opción: ");
    if (!int.TryParse(Console.ReadLine(), out opcion))
    {
        Console.WriteLine("Seleccione una opción numérica.");
        continue;
    }
    switch (opcion)
    {
        case 1:
            Console.WriteLine($"Saldo disponible: RD${saldo:N2}");
            break;
        case 2:
            if (!cuentaActiva)
            {
                Console.WriteLine("La cuenta está inactiva.");
                break;
            }
            Console.Write("Indique el monto a depositar: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal deposito) && deposito > 0)
            {
                saldo += deposito;
                Console.WriteLine("Depósito exitoso.");
                Console.WriteLine($" Su nuevo saldo: RD${saldo:N2}");
            }
            else Console.WriteLine("Monto inválido.");
            break;
        case 3:
            if (!cuentaActiva)
            {
                Console.WriteLine("La cuenta está inactiva.");
                break;
            }
            Console.Write("Ingrese el monto a retirar: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal retiro))
                Console.WriteLine("Monto inválido.");
            else if (retiro <= 0)
                Console.WriteLine("El monto debe ser mayor que cero.");
            else if (retiro > saldo)
                Console.WriteLine("Fondos insuficientes.");
            else
            {
                saldo -= retiro;
                Console.WriteLine("Retiro exitoso.");
                Console.WriteLine($"Nuevo saldo: RD${saldo:N2}");
            }
            break;
        case 4:
            Console.WriteLine("Gracias por utilizar nuestro servicio.");
            break;
        default:
            Console.WriteLine("Opción no reconocida.");
            break;
    }
} while (opcion != 4);
