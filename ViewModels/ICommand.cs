using System.Threading.Tasks;
using Xamarin.Forms;
using RpgApi.Models.Enums;

public class ICommand
{

    public async Task ObterClasses()
    {
      try
      {
            listaTiposClasse = new ObservableCollection<TipoClasse>();
            listaTiposClasse.add(new TipoClasse() { Id = 1, Descricao = "Cavaleiro"});
            listaTiposClasse.add(new TipoClasse() { Id = 2, Descricao = "Mago"});
            listaTiposClasse.add(new TipoClasse() { Id = 3, Descricao = "Clerigo"});
            OnPropertyChanged(nameof(listaTiposClasse));
        }
       catch (Exception ex)
       {
           await Application.Current.MainPage
               .DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerExecption, "Ok");
      }
    }   

    public async Task SalvarPersonagem()
    {

    }
}