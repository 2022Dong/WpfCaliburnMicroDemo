using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WpfCaliburnMicroDemo.Models;

namespace WpfCaliburnMicroDemo.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private string _firstName = "Tim";
        private string _lastName;
        private string _fullName;
        private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();  // Inialised.
        private PersonModel _selectedPerson;

        public ShellViewModel()
        {
            People.Add(new PersonModel { FirstName = "Tim", LastName = "Corey" });
            People.Add(new PersonModel { FirstName = "Bill", LastName = "Jones" });
            People.Add(new PersonModel { FirstName = "Sue", LastName = "Storm" });
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                //NotifyOfPropertyChange(nameof(FirstName));
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => FullName);
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
            }
        }
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        public BindableCollection<PersonModel> People
        {
            get { return _people; }
            set { _people = value; }
        }

        public PersonModel SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
            }
        }

        // turn into property, match up FirstNmae <=> firstName ... by using Casing diff.
        public bool CanClearText(string firstName, string lastName) //=> !String.IsNullOrWhiteSpace(firstName) || !String.IsNullOrWhiteSpace(newLastName);
        {
            //return !String.IsNullOrWhiteSpace(firstName) || !String.IsNullOrWhiteSpace(lastName);
            if (String.IsNullOrWhiteSpace(firstName) && String.IsNullOrWhiteSpace(lastName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void ClearText(string firstName, string lastName)
        {
            FirstName = "";
            LastName = "";
        }

        //public async Task LoadPageOne()
        //{
        //    await ActivateItemAsync(new FirstChildViewModel());
        //}

        //public async Task LoadPageTwo()
        //{
        //    await ActivateItemAsync(new SecondChildViewModel());
        //}

        protected async override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadPageOne();
        }


        public async Task LoadPageOne()
        {
            var viewmodel = IoC.Get<FirstChildViewModel>();
            await ActivateItemAsync(viewmodel, new CancellationToken());
        }
    }
}
