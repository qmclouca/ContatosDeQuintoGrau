using ContatosDeQuintoGrau.CoreBusiness;
using System.Collections.ObjectModel;
using UseCases.Intefaces;
using UseCases.PluginsInterface;

namespace ContatosDeQuintoGrau.Views;

public partial class ContatosPage : ContentPage
{
    private readonly IViewContactUseCase _viewContactUseCase;
    private readonly IDeleteContactUseCase _deleteContactUseCase;
    private readonly IViewContactsUseCase _viewContactsUseCase;

    public ContatosPage(IViewContactUseCase viewContactUseCase, 
        IDeleteContactUseCase deleteContactUseCase,
        IViewContactsUseCase viewContactsUseCase)
    {
        InitializeComponent();
        this._viewContactUseCase = viewContactUseCase;
        this._deleteContactUseCase = deleteContactUseCase;
        this._viewContactsUseCase = viewContactsUseCase;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        SearchBar.Text = string.Empty;
        LoadContacts();
    }


    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (listContacts.SelectedItem != null)
        {
            await Shell.Current.GoToAsync($"{nameof(EditarContatosPage)}?Id={((Contato)listContacts.SelectedItem).Id}");
        }
    }

    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listContacts.SelectedItem = null;
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AdicionarContatosPage));
    }

    private async void Delete_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var contact = menuItem!.CommandParameter as Contato;
        await _deleteContactUseCase.ExecuteAsync(contact!);
        LoadContacts();
    }

    private async void LoadContacts()
    {
        var contacts = new ObservableCollection<Contato>(await _viewContactsUseCase.ExecuteAsync(string.Empty));
        listContacts.ItemsSource = contacts;
    }

    private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        var contacts = new ObservableCollection<Contato>(await _viewContactsUseCase.ExecuteAsync(((SearchBar)sender!).Text));
        listContacts.ItemsSource = contacts;
    }
    private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
    {
        var contacts = new ObservableCollection<Contato>(await _viewContactsUseCase.ExecuteAsync(((SearchBar)sender!).Text));
        listContacts.ItemsSource = contacts;
    }
}