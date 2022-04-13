namespace TpBolillero.Core
{
    public interface IAzar
    {
        byte SacarBolilla(List<byte> bol);
        int bol {get; set;}    
    }
}