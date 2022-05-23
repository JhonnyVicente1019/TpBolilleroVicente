using System;
using System.Collections.Generic;
using System.Linq;

namespace TpBolillero.Core
{
    public class Bolillero : ICloneable
    {
        public List<byte> Adentro {get; set;}
        public List<byte> Afuera {get; set;}
        public IAzar Azar;
        public Bolillero(){}
        
        public  Bolillero(byte numeros)
        => CrearBolillas(numeros);
            
        private void CrearBolillas(byte numeros)
            { 
                Adentro = new List<byte>();
                Afuera = new List<byte>();
                for (byte bol = 0; bol < numeros; bol ++)
                {
                    Adentro.Add(bol);
                }
            }
        public void ReIngresar()
            {
                Adentro.AddRange(Afuera);
                Afuera.Clear();
            }
        public byte SacarBolilla()
        {
            byte bol = Azar.SacarBolilla(Adentro);
            Adentro.Remove(bol);
            Afuera.Add(bol);
            return bol;
        }

        public bool Jugar(List<byte> bol)
        => bol.TrueForAll(x => x == SacarBolilla());
        public long JugarN(List<byte> jugada, long Cantidad)
            {
                long Contador = 0;
                for (int i = 0; i < Cantidad; i ++)
                {
                    ReIngresar();
                    if (Jugar(jugada))
                    {
                        Contador ++;
                    }
                }
                return Contador;
            }

        public object Clone()
        {
            return new Bolillero(this);
        }
    }
}
