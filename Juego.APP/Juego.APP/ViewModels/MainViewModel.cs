using System;
using Xamarin.Forms;


namespace Juego.APP.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        #region Fields
        private double creditos;
        private int numero_1;
        private int numero_2;
        private int numero_3;
        #endregion


        #region Property
        public double Creditos
        {
            get { return this.creditos; }
            set { this.SetValue(ref this.creditos, value); }
        }

        public int Numero1
        {
            get { return this.numero_1; }
            set { this.SetValue(ref this.numero_1, value); }
        }

        public int Numero2
        {
            get { return this.numero_2; }
            set { this.SetValue(ref this.numero_2, value); }
        }

        public int Numero3
        {
            get { return this.numero_3; }
            set { this.SetValue(ref this.numero_3, value); }
        }
        #endregion




        public Command RecargaCommand { get; set; }

        public async void RecargaClicked(Object obj)
        {
           var creditos = await Application.Current.MainPage.DisplayPromptAsync("Creditos", "Ingrese sus creditos.", initialValue: "999.999.999", maxLength: 99999999, keyboard: Keyboard.Numeric);
            Creditos = Double.Parse(creditos);
        }

        public Command JugarCommand { get; set; }
        public async void JugarClicked(Object obj)
        {

            var creditos = this.Creditos;
            var apuesta = 5000;
            var num1 = this.Numero1;
            var num2 = this.Numero2;
            var num3 = this.Numero3;
            
            Random rnd = new Random();

            var aleatorio1 = rnd.Next(1,12);
           
            var aleatorio2 = rnd.Next(1,12);
          
            var aleatorio3 = rnd.Next(12);

            var resultado = $"Numero 1 = {aleatorio1}  " +
                            $"Numero 2 = {aleatorio2}  " +
                            $"Numero 3 = {aleatorio3}  ";

            if (creditos >= apuesta)
            {

                if ((num1 == aleatorio1) && (num2 == aleatorio2) && (num3 == aleatorio3))
                {
                    await Application.Current.MainPage.DisplayAlert("Ganaste 5000 el premio mayor acertaste los 3 numeros:", resultado, "Cerrar");
                    Creditos = creditos + apuesta;
                }
                else if (((num1 == aleatorio1) && (num2 == aleatorio2)) || ((num1 == aleatorio1) && (num3 == aleatorio3)))
                {
                    await Application.Current.MainPage.DisplayAlert("Ganaste 2500 la mitad del premio acertaste 2 numeros:", resultado, "Cerrar");
                    Creditos = creditos + (apuesta / 2);
                }
                else if (((num2 == aleatorio2) && (num1 == aleatorio1)) || ((num2 == aleatorio2) && (num3 == aleatorio3)))
                {
                    await Application.Current.MainPage.DisplayAlert("Ganaste 2500 la mitad del premio acertaste 2 numeros:", resultado, "Cerrar");
                    Creditos = creditos + (apuesta / 2);

                }
                else if (((num3 == aleatorio3) && (num1 == aleatorio1)) || ((num3 == aleatorio3) && (num2 == aleatorio2)))
                {
                    await Application.Current.MainPage.DisplayAlert("Ganaste 2500 la mitad del premio acertaste 2 numeros:", resultado, "Cerrar");
                    Creditos = creditos + (apuesta / 2);
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Perdiste, ¡Penalizado con 5.000 creidtos.", resultado, "Cerrar");
                    Creditos = creditos - apuesta;
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Recarga te has quedado sin credito", "No tienes los suficientes creditos para jugar", "Cerrar");
            }

        }

        public MainViewModel()
        {
            this.JugarCommand = new Command(this.JugarClicked);
            this.RecargaCommand = new Command(this.RecargaClicked);
        }

    }
}
