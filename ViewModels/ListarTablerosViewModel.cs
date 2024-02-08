using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_Kumbhal.Models;

namespace tl2_tp10_2023_Kumbhal.ViewModels;

public class ListarTablerosViewModel{
    public List<Tablero>? listadoTableros;
    public ListarTablerosViewModel(List<Tablero> listado){
        listadoTableros = listado;
    }
}