using appPhone.Models;
using appPhone.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace appPhone.ViewModels
{
    public class PhoneBookViewModel:BaseViewModel
    {
        #region Atributes
        private ApiService apiService;
        private ObservableCollection<Phone> phones;
        #endregion

        #region Properties
       public ObservableCollection<Phone> Phones
        {
            get { return this.phones; }
            set { SetValue(ref this.phones, value); }
        }
        #endregion

        #region Constructor
        public PhoneBookViewModel()
        {
            this.apiService = new ApiService();
            this.LoadPhones();
        }
        #endregion

        #region Methods
        private async void LoadPhones()
        {
            var connection = await apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                   "404 Bad Connection",
                   connection.Message,
                   "Accept"
                   );
                return;
            }

            var response = await apiService.GetList<Phone>(
                "https://localhost:44360/",
                "api/",
                "Phones"
                );

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Phone Service Error",
                    response.Message,
                    "Accept"
                    ); 
                return;
            }

            MainViewModel main = MainViewModel.GetInstance();
            main.ListPhone =(List<Phone>) response.Result;

            this.Phones = new ObservableCollection<Phone>(ToPhoneCollect()); 
        }

        private IEnumerable<Phone> ToPhoneCollect()
        {
            ObservableCollection<Phone> collection = new ObservableCollection<Phone>();
            MainViewModel main = MainViewModel.GetInstance();
            foreach (var lista in main.ListPhone)
            {
                Phone phone = new Phone();
                phone.PersonID = lista.PersonID;
                phone.FirstName = lista.FirstName;
                phone.LastName = lista.LastName;
                phone.Blood_Type = lista.Blood_Type;
                phone.Question_Donator = lista.Question_Donator;
                phone.Allergies = lista.Allergies;
                collection.Add(phone);
            }

            return (collection);
        }
        #endregion

    }
}   