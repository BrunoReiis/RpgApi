using AppRpgEtec.Models;
using System.Collections.ObjectModel;

public class TipoClasse
{
    public int Id {get; set;}
    public string Descricao {get; set;}

    private ObservableCollection<TipoClasse> listaTiposClasse;
    public ObservableCollection<TipoClasse> listaTiposClasse
    {
        get {return listaTiposClasse;}
        set
        {
            if (value != null)
            {
                listaTiposClasse = value;
                OnProPertyChanged();
            }
        }
    }
}