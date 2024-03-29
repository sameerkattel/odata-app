﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generation date: 09/26/21 10:26:55 PM
namespace Microsoft.OData.SampleService.Models.TripPin
{
    /// <summary>
    /// There are no comments for PersonSingle in the schema.
    /// </summary>
    [global::Microsoft.OData.Client.OriginalNameAttribute("PersonSingle")]
    public partial class PersonSingle : global::Microsoft.OData.Client.DataServiceQuerySingle<Person>
    {
        /// <summary>
        /// Initialize a new PersonSingle object.
        /// </summary>
        public PersonSingle(global::Microsoft.OData.Client.DataServiceContext context, string path)
            : base(context, path) {}

        /// <summary>
        /// Initialize a new PersonSingle object.
        /// </summary>
        public PersonSingle(global::Microsoft.OData.Client.DataServiceContext context, string path, bool isComposable)
            : base(context, path, isComposable) {}

        /// <summary>
        /// Initialize a new PersonSingle object.
        /// </summary>
        public PersonSingle(global::Microsoft.OData.Client.DataServiceQuerySingle<Person> query)
            : base(query) {}

        /// <summary>
        /// There are no comments for Friends in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        [global::Microsoft.OData.Client.OriginalNameAttribute("Friends")]
        public virtual global::Microsoft.OData.Client.DataServiceQuery<global::Microsoft.OData.SampleService.Models.TripPin.Person> Friends
        {
            get
            {
                if (!this.IsComposable)
                {
                    throw new global::System.NotSupportedException("The previous function is not composable.");
                }
                if ((this._Friends == null))
                {
                    this._Friends = Context.CreateQuery<global::Microsoft.OData.SampleService.Models.TripPin.Person>(GetPath("Friends"));
                }
                return this._Friends;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private global::Microsoft.OData.Client.DataServiceQuery<global::Microsoft.OData.SampleService.Models.TripPin.Person> _Friends;
        /// <summary>
        /// There are no comments for Trips in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        [global::Microsoft.OData.Client.OriginalNameAttribute("Trips")]
        public virtual global::Microsoft.OData.Client.DataServiceQuery<global::Microsoft.OData.SampleService.Models.TripPin.Trip> Trips
        {
            get
            {
                if (!this.IsComposable)
                {
                    throw new global::System.NotSupportedException("The previous function is not composable.");
                }
                if ((this._Trips == null))
                {
                    this._Trips = Context.CreateQuery<global::Microsoft.OData.SampleService.Models.TripPin.Trip>(GetPath("Trips"));
                }
                return this._Trips;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private global::Microsoft.OData.Client.DataServiceQuery<global::Microsoft.OData.SampleService.Models.TripPin.Trip> _Trips;
        /// <summary>
        /// There are no comments for Photo in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        [global::Microsoft.OData.Client.OriginalNameAttribute("Photo")]
        public virtual global::Microsoft.OData.SampleService.Models.TripPin.PhotoSingle Photo
        {
            get
            {
                if (!this.IsComposable)
                {
                    throw new global::System.NotSupportedException("The previous function is not composable.");
                }
                if ((this._Photo == null))
                {
                    this._Photo = new global::Microsoft.OData.SampleService.Models.TripPin.PhotoSingle(this.Context, GetPath("Photo"));
                }
                return this._Photo;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private global::Microsoft.OData.SampleService.Models.TripPin.PhotoSingle _Photo;
    }
    /// <summary>
    /// There are no comments for Person in the schema.
    /// </summary>
    /// <KeyProperties>
    /// UserName
    /// </KeyProperties>
    [global::Microsoft.OData.Client.Key("UserName")]
    [global::Microsoft.OData.Client.OriginalNameAttribute("Person")]
    public partial class Person : global::Microsoft.OData.Client.BaseEntityType, global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new Person object.
        /// </summary>
        /// <param name="userName">Initial value of UserName.</param>
        /// <param name="firstName">Initial value of FirstName.</param>
        /// <param name="lastName">Initial value of LastName.</param>
        /// <param name="concurrency">Initial value of Concurrency.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        public static Person CreatePerson(string userName, string firstName, string lastName, long concurrency)
        {
            Person person = new Person();
            person.UserName = userName;
            person.FirstName = firstName;
            person.LastName = lastName;
            person.Concurrency = concurrency;
            return person;
        }
        /// <summary>
        /// There are no comments for Property UserName in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("UserName")]
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessage = "UserName is required.")]
        public virtual string UserName
        {
            get
            {
                return this._UserName;
            }
            set
            {
                this.OnUserNameChanging(value);
                this._UserName = value;
                this.OnUserNameChanged();
                this.OnPropertyChanged("UserName");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private string _UserName;
        partial void OnUserNameChanging(string value);
        partial void OnUserNameChanged();
        /// <summary>
        /// There are no comments for Property FirstName in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("FirstName")]
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessage = "FirstName is required.")]
        public virtual string FirstName
        {
            get
            {
                return this._FirstName;
            }
            set
            {
                this.OnFirstNameChanging(value);
                this._FirstName = value;
                this.OnFirstNameChanged();
                this.OnPropertyChanged("FirstName");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private string _FirstName;
        partial void OnFirstNameChanging(string value);
        partial void OnFirstNameChanged();
        /// <summary>
        /// There are no comments for Property LastName in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("LastName")]
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessage = "LastName is required.")]
        public virtual string LastName
        {
            get
            {
                return this._LastName;
            }
            set
            {
                this.OnLastNameChanging(value);
                this._LastName = value;
                this.OnLastNameChanged();
                this.OnPropertyChanged("LastName");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private string _LastName;
        partial void OnLastNameChanging(string value);
        partial void OnLastNameChanged();
        /// <summary>
        /// There are no comments for Property Emails in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("Emails")]
        public virtual global::System.Collections.ObjectModel.ObservableCollection<string> Emails
        {
            get
            {
                return this._Emails;
            }
            set
            {
                this.OnEmailsChanging(value);
                this._Emails = value;
                this.OnEmailsChanged();
                this.OnPropertyChanged("Emails");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private global::System.Collections.ObjectModel.ObservableCollection<string> _Emails = new global::System.Collections.ObjectModel.ObservableCollection<string>();
        partial void OnEmailsChanging(global::System.Collections.ObjectModel.ObservableCollection<string> value);
        partial void OnEmailsChanged();
        /// <summary>
        /// There are no comments for Property AddressInfo in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("AddressInfo")]
        public virtual global::System.Collections.ObjectModel.ObservableCollection<global::Microsoft.OData.SampleService.Models.TripPin.Location> AddressInfo
        {
            get
            {
                return this._AddressInfo;
            }
            set
            {
                this.OnAddressInfoChanging(value);
                this._AddressInfo = value;
                this.OnAddressInfoChanged();
                this.OnPropertyChanged("AddressInfo");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private global::System.Collections.ObjectModel.ObservableCollection<global::Microsoft.OData.SampleService.Models.TripPin.Location> _AddressInfo = new global::System.Collections.ObjectModel.ObservableCollection<global::Microsoft.OData.SampleService.Models.TripPin.Location>();
        partial void OnAddressInfoChanging(global::System.Collections.ObjectModel.ObservableCollection<global::Microsoft.OData.SampleService.Models.TripPin.Location> value);
        partial void OnAddressInfoChanged();
        /// <summary>
        /// There are no comments for Property Gender in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("Gender")]
        public virtual global::System.Nullable<global::Microsoft.OData.SampleService.Models.TripPin.PersonGender> Gender
        {
            get
            {
                return this._Gender;
            }
            set
            {
                this.OnGenderChanging(value);
                this._Gender = value;
                this.OnGenderChanged();
                this.OnPropertyChanged("Gender");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private global::System.Nullable<global::Microsoft.OData.SampleService.Models.TripPin.PersonGender> _Gender;
        partial void OnGenderChanging(global::System.Nullable<global::Microsoft.OData.SampleService.Models.TripPin.PersonGender> value);
        partial void OnGenderChanged();
        /// <summary>
        /// There are no comments for Property Concurrency in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("Concurrency")]
        [global::System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessage = "Concurrency is required.")]
        public virtual long Concurrency
        {
            get
            {
                return this._Concurrency;
            }
            set
            {
                this.OnConcurrencyChanging(value);
                this._Concurrency = value;
                this.OnConcurrencyChanged();
                this.OnPropertyChanged("Concurrency");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private long _Concurrency;
        partial void OnConcurrencyChanging(long value);
        partial void OnConcurrencyChanged();
        /// <summary>
        /// There are no comments for Property Friends in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("Friends")]
        public virtual global::Microsoft.OData.Client.DataServiceCollection<global::Microsoft.OData.SampleService.Models.TripPin.Person> Friends
        {
            get
            {
                return this._Friends;
            }
            set
            {
                this.OnFriendsChanging(value);
                this._Friends = value;
                this.OnFriendsChanged();
                this.OnPropertyChanged("Friends");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private global::Microsoft.OData.Client.DataServiceCollection<global::Microsoft.OData.SampleService.Models.TripPin.Person> _Friends = new global::Microsoft.OData.Client.DataServiceCollection<global::Microsoft.OData.SampleService.Models.TripPin.Person>(null, global::Microsoft.OData.Client.TrackingMode.None);
        partial void OnFriendsChanging(global::Microsoft.OData.Client.DataServiceCollection<global::Microsoft.OData.SampleService.Models.TripPin.Person> value);
        partial void OnFriendsChanged();
        /// <summary>
        /// There are no comments for Property Trips in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("Trips")]
        public virtual global::Microsoft.OData.Client.DataServiceCollection<global::Microsoft.OData.SampleService.Models.TripPin.Trip> Trips
        {
            get
            {
                return this._Trips;
            }
            set
            {
                this.OnTripsChanging(value);
                this._Trips = value;
                this.OnTripsChanged();
                this.OnPropertyChanged("Trips");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private global::Microsoft.OData.Client.DataServiceCollection<global::Microsoft.OData.SampleService.Models.TripPin.Trip> _Trips = new global::Microsoft.OData.Client.DataServiceCollection<global::Microsoft.OData.SampleService.Models.TripPin.Trip>(null, global::Microsoft.OData.Client.TrackingMode.None);
        partial void OnTripsChanging(global::Microsoft.OData.Client.DataServiceCollection<global::Microsoft.OData.SampleService.Models.TripPin.Trip> value);
        partial void OnTripsChanged();
        /// <summary>
        /// There are no comments for Property Photo in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("Photo")]
        public virtual global::Microsoft.OData.SampleService.Models.TripPin.Photo Photo
        {
            get
            {
                return this._Photo;
            }
            set
            {
                this.OnPhotoChanging(value);
                this._Photo = value;
                this.OnPhotoChanged();
                this.OnPropertyChanged("Photo");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private global::Microsoft.OData.SampleService.Models.TripPin.Photo _Photo;
        partial void OnPhotoChanging(global::Microsoft.OData.SampleService.Models.TripPin.Photo value);
        partial void OnPhotoChanged();
        /// <summary>
        /// There are no comments for Property DynamicProperties in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]

        [global::Microsoft.OData.Client.OriginalNameAttribute("DynamicProperties")]
        [global::Microsoft.OData.Client.ContainerProperty]
        public virtual global::System.Collections.Generic.IDictionary<string, object> DynamicProperties
        {
            get
            {
                return this._DynamicProperties;
            }
            set
            {
                this.OnDynamicPropertiesChanging(value);
                this._DynamicProperties = value;
                this.OnDynamicPropertiesChanged();
                this.OnPropertyChanged("DynamicProperties");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        private global::System.Collections.Generic.IDictionary<string, object> _DynamicProperties = new global::System.Collections.Generic.Dictionary<string, object>();
        partial void OnDynamicPropertiesChanging(global::System.Collections.Generic.IDictionary<string, object> value);
        partial void OnDynamicPropertiesChanged();
        /// <summary>
        /// This event is raised when the value of the property is changed
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// The value of the property is changed
        /// </summary>
        /// <param name="property">property name</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "#VersionNumber#")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
        /// <summary>
        /// There are no comments for GetFavoriteAirline in the schema.
        /// </summary>
        [global::Microsoft.OData.Client.OriginalNameAttribute("GetFavoriteAirline")]
        public virtual  global::Microsoft.OData.SampleService.Models.TripPin.AirlineSingle GetFavoriteAirline()
        {
            global::System.Uri requestUri;
            Context.TryGetUri(this, out requestUri);

            return new global::Microsoft.OData.SampleService.Models.TripPin.AirlineSingle(this.Context.CreateFunctionQuerySingle<global::Microsoft.OData.SampleService.Models.TripPin.Airline>(string.Join("/", global::System.Linq.Enumerable.Select(global::System.Linq.Enumerable.Skip(requestUri.Segments, this.Context.BaseUri.Segments.Length), s => s.Trim('/'))), "Microsoft.OData.SampleService.Models.TripPin.GetFavoriteAirline", true));
        }
        /// <summary>
        /// There are no comments for GetFriendsTrips in the schema.
        /// </summary>
        [global::Microsoft.OData.Client.OriginalNameAttribute("GetFriendsTrips")]
        public virtual global::Microsoft.OData.Client.DataServiceQuery<global::Microsoft.OData.SampleService.Models.TripPin.Trip> GetFriendsTrips(string userName)
        {
            global::System.Uri requestUri;
            Context.TryGetUri(this, out requestUri);
            return this.Context.CreateFunctionQuery<global::Microsoft.OData.SampleService.Models.TripPin.Trip>(string.Join("/", global::System.Linq.Enumerable.Select(global::System.Linq.Enumerable.Skip(requestUri.Segments, this.Context.BaseUri.Segments.Length), s => s.Trim('/'))), "Microsoft.OData.SampleService.Models.TripPin.GetFriendsTrips", true, new global::Microsoft.OData.Client.UriOperationParameter("userName", userName));
        }
        /// <summary>
        /// There are no comments for ShareTrip in the schema.
        /// </summary>
        [global::Microsoft.OData.Client.OriginalNameAttribute("ShareTrip")]
        public virtual global::Microsoft.OData.Client.DataServiceActionQuery ShareTrip(string userName, int tripId)
        {
            global::Microsoft.OData.Client.EntityDescriptor resource = Context.EntityTracker.TryGetEntityDescriptor(this);
            if (resource == null)
            {
                throw new global::System.Exception("cannot find entity");
            }

            return new global::Microsoft.OData.Client.DataServiceActionQuery(this.Context, resource.EditLink.OriginalString.Trim('/') + "/Microsoft.OData.SampleService.Models.TripPin.ShareTrip", new global::Microsoft.OData.Client.BodyOperationParameter("userName", userName),
                    new global::Microsoft.OData.Client.BodyOperationParameter("tripId", tripId));
        }
    }
}
