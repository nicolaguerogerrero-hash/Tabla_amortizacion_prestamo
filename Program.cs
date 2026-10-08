using Spectre.Console;

decimal montoPrestamo = AnsiConsole.Ask<decimal>("Ingresa el monto del préstamo: ");
decimal interesAnual = AnsiConsole.Ask<decimal>("Ingresa el interés anual: ");
int plazoPrestamo = AnsiConsole.Ask<int>("Indica el plazo del préstamo: ");

var tabla = new Table();

tabla.AddColumn("No.");
tabla.AddColumn("Pago de couta");
tabla.AddColumn("Interés a pagar");
tabla.AddColumn("Abono a capital");
tabla.AddColumn("Saldo");

decimal interesMensual = interesAnual / 12 / 100;
// interesMensual = interesMensual / 100;

decimal divArriba = (decimal)Math.Pow(1 + (double)interesMensual, plazoPrestamo);
decimal divAbajo = (decimal)Math.Pow(1 + (double)interesMensual, plazoPrestamo) - 1;

decimal coutaFija = montoPrestamo * interesMensual * (divArriba / divAbajo);

decimal saldo = montoPrestamo;

for (int i = 1; i <= plazoPrestamo; i++)
{
   decimal interesPagar = saldo * interesMensual;
   decimal abonoCapital = coutaFija - interesPagar;
   saldo = saldo - abonoCapital;

  tabla.AddRow($"{i}", $"{coutaFija:C2}", $"{interesPagar:C2}", $"{abonoCapital:C2}", $"{saldo:C2}");

  // TODO: Terminar de completar la tabla
}


AnsiConsole.Write(tabla);