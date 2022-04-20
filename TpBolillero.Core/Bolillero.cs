using System;
using System.Collections.Generic;

namespace TpBolillero.Core
{
    public class Bolillero 
    {
        private List<byte> Adentro {get; set;}
        private List<byte> Afuera {get; set;}
        private IAzar Azar;
        public Bolillero(IAzar azar)
            {
                Adentro = new List<byte>();
                Afuera = new List<byte>();
                azar = Azar;
            }
        
        public  Bolillero(IAzar Azar, byte numeros)
        => CrearBolillas(numeros);
            
        private void CrearBolillas(byte numeros)
            {
    
            }
        public void ReIngresar()
            {

            }
        public byte SacarBolillas()
        {
            var bol = Azar.SacarBolilla(Adentro);
            Adentro.Add(bol);
            Afuera.Remove(bol);
            return bol;
        }

        public bool Jugar(List<byte> bol)
        => bol.TrueForAll(x => x == SacarBolillas());
        public long JugarN(List<byte> jugada, int Cantidad)
            {
                long Contador = 0;
                for (int i = 0; i < Cantidad; i ++)
                {
                    if (Jugar(jugada))
                    {
                        Contador ++;
                    }
                }
                return Contador;
            }
    }
}





