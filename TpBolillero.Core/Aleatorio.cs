using System;
using System.Collections.Generic;
using System.Linq;

namespace TpBolillero.Core
{
    public class Aleatorio : IAzar
    {
        private Random r = new Random();
        
        public byte SacarBolilla(List<byte> bol);
        

        
    }
}