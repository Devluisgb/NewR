using SegundoModulo.Models;

namespace SegundoModulo.Services;

public interface IPruebaServices{
    //definición de un metodo sin lógica
    void AgregarNuevoObjeto(Prueba model, List<Prueba> lstPrueba);
    
    }
    public class PruebaSevices : IPruebaServices
    {
        public void AgregarNuevoObjeto(Prueba model, List<Prueba> lstPrueba)
        {
            model.Id = lstPrueba.Count + 1;
            lstPrueba.Add(model);
        }
    }

    public class PruebaServices : IPruebaServices
    {
        public void AgregarNuevoObjeto(Prueba model, List<Prueba> lstPrueba)
        {
            model.Descripcion = "nuevaDescripcion";
            lstPrueba.Where(x => x.Id == model.Id).FirstOrDefault().Descripcion = model.Descripcion;
        }
    }
