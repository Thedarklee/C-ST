using OcCine.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OcCine.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string correo;
        private string clave;
        private string validacion;

        public String Correo {
            get => correo;
            set {
                if (correo != value) { 
                    correo = value;

                    OnPropertyChanged(nameof(Correo));
                }
            
            }
        
        }
        public String Clave
        {
            get => clave;
            set
            {
                if (clave != value)
                {
                    clave = value;

                    OnPropertyChanged(nameof(Clave));
                }

            }

        }

        public String Validacion
        {
            get => validacion;
            set
            {
                if (validacion != value)
                {
                    validacion = value;

                    OnPropertyChanged(nameof(Validacion));
                }

            }

        }
        private async void OnAcceder() {
            if (Correo == "root" && Clave == "12345")
            {
                await Application.Current.MainPage.Navigation.PushAsync(new MuestraOc());
            }
            else {

                Validacion = "USuario o Contraseña Invalidos";
            }
        
        }

        private async void AccederRen() {
            await Application.Current.MainPage.Navigation.PushAsync(new RenPage());
        }
        public ICommand IrRen { get; }
        public ICommand EventoAcceso { get; }
        
        public LoginViewModel() {
            EventoAcceso = new Command(OnAcceder);
        }

        public RenPagina()
        {
            IrRen = new Command(AccederRen);
        }
        protected virtual void OnPropertyChanged(string propertyName) { 
        
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
