namespace ContatosDeQuintoGrau.Views.Controls;

public partial class Contatos : ContentView
{
    public event EventHandler<string> OnError;
    public event EventHandler<EventArgs> OnSave;
    public event EventHandler<EventArgs> OnCancel;
    public Contatos()
	{
		InitializeComponent();
	}

    public string Name
    {
        get
        {
            return entryName.Text;
        }
        set
        {
            entryName.Text = value;
        }
    }

    public string Email
    {
        get
        {
            return entryEmail.Text;
        }
        set
        {
            entryEmail.Text = value;
        }
    }
    
    public string Phone
    {
        get
        {
            return entryPhone.Text;
        }
        set
        {
            entryPhone.Text = value;
        }
    }

    public string Address
    {
        get
        {
            return entryAddress.Text;
        }
        set
        {
            entryAddress.Text = value;
        }
    }

    private void btnSave_Clicked(object sender, EventArgs e)
    {
        if(nameValidator.IsNotValid)
        {
            OnError?.Invoke(this, "Nome é obrigatório");
            return;
        }
        if(emailValidator.IsNotValid)
        {
            foreach (var error in emailValidator.Errors!)
            {
                OnError?.Invoke(this, error.ToString());
            }
            return;
        }
        OnSave?.Invoke(sender, e);       
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        OnCancel?.Invoke(sender, e);       
    }
}