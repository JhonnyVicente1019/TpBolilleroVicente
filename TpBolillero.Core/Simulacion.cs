using System;
using System.Collections.Generic;

namespace TpBolillero.Core
{
    public class Simulacion
    {
        public long simularSinHilos(Bolillero clon, List<byte> jugadas, long cantidad)
        {
            return clon.JugarN(jugadas, cantidad);
        }
        public long simularConHilos(Bolillero clon, List<byte> jugadas, long cantidad, long hilos)
        {
            Task<long>{}tareas = new Task<long>{hilos};
        }
    }
}