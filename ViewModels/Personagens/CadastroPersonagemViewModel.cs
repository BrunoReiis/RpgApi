using AppRpgHas.Servicos.Personagens;
using Xamarim.Forms;

public class CadastroPersonagemViewModel : BasicViewModel
{
    private PersonagemService pService;
    public CadastroPersonagemViewModel()
    {
        string token = "";
        pService = new PersonagemService(token);

        _ = ObterClasses();
    }

    private TipoClasse tipoClasseSelecionado;

    public TipoClasse tipoClasseSelecionado
    {
        get {return tipoClasseSelecionado;}
        set
        {
            if (value != null)
            {
                tipoClasseSelecionado = value;
                OnProPertyChanged();
            }
        }
    }

    private int id
    {
        get => id;
        set
        {
            id = value;
            OnProPertyChanged();
        }
    }

    private string nome
     {
        get => nome;
        set
        {
            nome = value;
            OnProPertyChanged();
        }
    }
    
    private int pontosVida
     {
        get => pontosVida;
        set
        {
            pontosVida = value;
            OnProPertyChanged();
        }
    }
    
    private int forca
     {
        get => forca;
        set
        {
            forca = value;
            OnProPertyChanged();
        }
    }
    
    private int defesa
     {
        get => defesa;
        set
        {
            defesa = value;
            OnProPertyChanged();
        }
    }
    
    private int inteligencia
     {
        get => inteligencia;
        set
        {
            inteligencia = value;
            OnProPertyChanged();
        }
    }
    
    private int disputas
     {
        get => disputas;
        set
        {
            disputas = value;
            OnProPertyChanged();
        }
    }
    
    private int vitorias
     {
        get => vitorias;
        set
        {
            vitorias = value;
            OnProPertyChanged();
        }
    }
    
    private int derrotas
     {
        get => derrotas;
        set
        {
            derrotas = value;
            OnProPertyChanged();
        }
    }
    
}