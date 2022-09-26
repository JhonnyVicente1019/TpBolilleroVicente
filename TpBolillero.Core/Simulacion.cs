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
        public async Task<long> SimularConHilosAsync(Bolillero clon, List<byte> jugadas, long cantidad, long hilos)
        {
            Task<long>[] tareas = new Task<long>[hilos];
            for(long i = 0; i < cantidad; i++)
            {
                var nuevoBolillero = (Bolillero)clon.Clone();
                tareas[i] = Task.Run(() => SimularSinHilos(nuevoBolillero, jugadas, hilos));
            }
            var Division = hilos/cantidad;
            await Task<long>.WhenAll(tareas);
            return tareas.Sum(x => x.Result);
        }
        public async Task<long> SimularParallelAsync(Bolillero bolillero, List<byte> jugadas, long cantidadSimulacion, long cantidadHilos)
        {
            long [] resultado = new long [cantidadSimulacion];
            await Task.Run(() => 
                Parallel.For(0, cantidadHilos, 
                i =>
                {
                    var nuevoBolillero = (Bolillero)bolillero.Clone();
                    resultado [i] = SimularSinHilos(nuevoBolillero, jugadas, cantidadSimulacion / cantidadHilos);
                }
                )
            );
            return resultado.Sum();
        }
    }
}