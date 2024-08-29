using System.Globalization;
namespace tarea2
{ 
//interface de mensaje
public interface IMensaje
{
        public void Leermensaje();
        public string Texto();
        public void SetTexto(string valor);
}
//clase base mensaje
public class Mensaje : IMensaje
{
    String texto;
    public Mensaje(string mensaje)
    {
        this.texto = mensaje;
    }
    public void Leermensaje()
    {
        Console.WriteLine(texto);
    }
    public string Texto()
    {
         return texto;
    }
    public void SetTexto(string valor)
        {
            this.texto=valor;
        }
}
//clase abstracta de decorador
public abstract class DecoradorMensajes : IMensaje
{
    public IMensaje _mensaje;
    public DecoradorMensajes(IMensaje mensaje){   
        _mensaje = mensaje;
    }
    public virtual void Leermensaje()
    {
            _mensaje.Leermensaje();
    }
    public string Texto()
        {
            return _mensaje.Texto();
        }
    public void SetTexto(string valor) {
            _mensaje.SetTexto(valor);
        }
}
public class MensajeEncriptado : DecoradorMensajes //decorador que encripta el mensaje para simplicidad solo cambia el texto entregado al primer mensaje
{
        public string aux;

    public MensajeEncriptado(IMensaje mensaje) : base(mensaje){
            string encriptado = "encriptado";
            mensaje.SetTexto((encriptado));
        }
    public override void  Leermensaje()
        {
            Console.WriteLine(_mensaje.Texto());
        }
}
public class MensajeComprimido : DecoradorMensajes //decorador que comprime  el mensaje para simplicidad solo lo parte a la mitad
    { 

     public MensajeComprimido(IMensaje mensaje) : base(mensaje)
     {
            //encuentra la mitad del texto original, parte el String y lo remplaza.
            string original = mensaje.Texto();
            int mitad = original.Length / 2;
            string comprimido=original.Substring(0, mitad);
            mensaje.SetTexto((comprimido));
     }
     public override void Leermensaje()
     {
            Console.WriteLine(_mensaje.Texto());
     }
}
    public class MensajeFirmado : DecoradorMensajes //decorador que firma  el mensaje para simplicidad le agrega algo al final del texto.
    {

        public MensajeFirmado(IMensaje mensaje) : base(mensaje)
        {

        }
        public override void Leermensaje()
        {
            Console.WriteLine(_mensaje.Texto()+" "+" Y además esta firmado");
        }
    }
    class Program
{
    static void Main(string[] args)
    {
            string test = "testeo";
            IMensaje prueba= new Mensaje(test);
            prueba.Leermensaje();
            prueba= new MensajeEncriptado(prueba);
            prueba.Leermensaje();
            prueba = new MensajeComprimido(prueba);
            prueba.Leermensaje();
            prueba =new MensajeFirmado(prueba);
            prueba.Leermensaje();
    }
 }
}

