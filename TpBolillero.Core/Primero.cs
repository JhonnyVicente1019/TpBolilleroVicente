using System.Collections.Generic;

namespace TpBolillero.Core
{
    public class Primero : IAzar
    {
        public byte SacarBolilla(List<byte> bol) => bol[0];       
    }
}