using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace TpBolillero.Core
{
    public class Simulacion
    {
        public long SimularSinHilos(Bolillero clon, List<byte> jugadas, long cantidad)
        {
            return clon.JugarN(jugadas, cantidad);
        }
        public long SimularConHilos(Bolillero clon, List<byte> jugadas, long cantidad, long hilos)
        {
            Task<long>[]tareas = new Task<long>[hilos];
            for(long i = 0 ; i < cantidad; i++)
            {
                var nuevoBolillero = (Bolillero)clon.Clone();
                tareas[i] = Task.Run(() => SimularSinHilos(clon, jugadas, hilos));
            }
            var division = hilos / cantidad;
            Task<long>.WaitAll(tareas);
            return tareas.Sum(x => x.Result);
        }
    }
}