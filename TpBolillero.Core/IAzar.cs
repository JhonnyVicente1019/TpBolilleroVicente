using System.Collections.Generic;

namespace TpBolillero.Core
{
    public interface IAzar
    {
        byte SacarBolilla(List<byte> bol);   
    }
}