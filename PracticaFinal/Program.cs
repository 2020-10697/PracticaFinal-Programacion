using System;


namespace SISTEMA_CALCULADORA_DE_PRÉSTAMOS
{
    class PRESTAMOS
    {

        private float PAGO, Intereses_Pagado, Capital_Pagado, Monto_Del_Prestamo_En_RD, Tasa_Interes_Anual, Tasa_Interes_Mensual, SUELDO, NO_APLICA; 
        private  int FILA, PLAZO, i;
        
        public void Datos_recibidos()
        {
            Console.Write("INTRODUZCA SU SUELDO: ");
            float.TryParse(Console.ReadLine(), out SUELDO);
            Console.Write("INTRODUCE EL MONTO DEL PRESTAMO A SOLICIAR EN RD: ");
            float.TryParse(Console.ReadLine(), out Monto_Del_Prestamo_En_RD);
            Console.Write("INTRODUCE LA TASA DE INTERES CON LA QUE DESEAS PAGAR: ");
            float.TryParse(Console.ReadLine(), out Tasa_Interes_Anual);
            Console.Write("INTRODUCE EL PLASO DE MESES EN EL QUE DESEA PAGAR: ");
            int.TryParse(Console.ReadLine(), out PLAZO);
        }
        public void Ecuacion() 
        {
            //Calculo del interes mensual
            Tasa_Interes_Mensual = (Tasa_Interes_Anual / 100) / 12;
            

            //Calculo de la cuota mensual
            PAGO = Tasa_Interes_Mensual + 1;
            PAGO = (float)Math.Pow(PAGO, PLAZO);
            PAGO = PAGO - 1;
            PAGO = Tasa_Interes_Mensual / PAGO;
            PAGO = Tasa_Interes_Mensual + PAGO;
            PAGO = Monto_Del_Prestamo_En_RD * PAGO;
            NO_APLICA = PAGO * 100 / SUELDO;
        }
        public void Vista_de_tabla()
        {

            if (NO_APLICA <= 30)
            {
                Console.WriteLine();
                FILA = 1;
                Console.WriteLine();
                Console.WriteLine();
                Console.Write(" Numero de pago \t");
                Console.Write("Pago \t\t");
                Console.Write("Intereses Pagados \t\t");
                Console.Write("Capital Pagado \t\t");
                Console.Write("Monto del prestamo \t");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("\t0");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t{0}", Monto_Del_Prestamo_En_RD);

                for (i = 1; i <= PLAZO; i++)
                {


                    Console.Write("\t{0}\t\t", FILA);


                    Console.Write("{0}\t", PAGO);


                    Intereses_Pagado = Tasa_Interes_Mensual * Monto_Del_Prestamo_En_RD;
                    Console.Write("{0}\t\t", Intereses_Pagado);


                    Capital_Pagado = PAGO - Intereses_Pagado;
                    Console.Write("\t{0}\t", Capital_Pagado);


                    Monto_Del_Prestamo_En_RD = Monto_Del_Prestamo_En_RD - Capital_Pagado;
                    Console.WriteLine("\t{0}\t", Monto_Del_Prestamo_En_RD);

                    
                    FILA = FILA + 1;
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine();

                }
            
            
            }
            else
            {
                Console.WriteLine("NO APLICA PARA EL PRESTAMO");
            }

        }

        private static void Main(string[] args)
        {
            PRESTAMOS Presta = new PRESTAMOS();
            Presta.Datos_recibidos();
            Presta.Ecuacion();
            Presta.Vista_de_tabla();

            Console.ReadLine();
        }
    }
}