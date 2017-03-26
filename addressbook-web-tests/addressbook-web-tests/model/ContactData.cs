using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstName;
        private string middleName = "";
        private string lastName;
        private string nickname = "";
        private string photo = "";
        private string title = "";
        private string company = "";
        private string address = "";
        private string telephoneHome = "";
        private string telephoneMobile = "";
        private string telephoneWork = "";
        private string fax = "";

        private string email1 = "";
        private string email2 = "";
        private string email3 = "";
        private string homepage = "";
        private string birthdayDay = "";
        private string birthdayMonth = "";
        private string birthdayYear = "";
        private string anniversaryDay = "";
        private string anniversaryMonth = "";
        private string anniversaryYear = "";

        private string secondaryAddress = "";
        private string secondaryHome = "";
        private string secondaryNotes = "";

        public ContactData(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }


        /// //////////////////////////////////////////////////////////////////
        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return FirstName == other.firstName && LastName == other.lastName;
        }

        public int GetHashCodeFirstName()
        {
            return FirstName.GetHashCode();
        }

        public int GetHashCodeLastName()
        {
            return LastName.GetHashCode();
        }

        public override string ToString()
        {
            return "name = " + FirstName + " " + LastName;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return FirstName.CompareTo(other.firstName);
        }

       
        /////////////////////////////////////////////////////////////////////

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string MiddleName
        {
            get { return middleName; }
            set { middleName = value; }
        }

        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }

        public string Photo
        {
            get { return photo; }
            set { photo = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Company
        {
            get { return company; }
            set { company = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string TelephoneHome
        {
            get { return telephoneHome; }
            set { telephoneHome = value; }
        }

        public string TelephoneMobile
        {
            get { return telephoneMobile; }
            set { telephoneMobile = value; }
        }

        public string TelephoneWork
        {
            get { return telephoneWork; }
            set { telephoneWork = value; }
        }

        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }

        public string Email1
        {
            get { return email1; }
            set { email1 = value; }
        }

        public string Email2
        {
            get { return email2; }
            set { email2 = value; }
        }

        public string Email3
        {
            get { return email3; }
            set { email3 = value; }
        }

        public string Homepage
        {
            get { return homepage; }
            set { homepage = value; }
        }

        public string BirthdayDay
        {
            get { return birthdayDay; }
            set { birthdayDay = value; }
        }

        public string BirthdayMonth
        {
            get { return birthdayMonth; }
            set { birthdayMonth = value; }
        }

        public string BirthdayYear
        {
            get { return birthdayYear; }
            set { birthdayYear = value; }
        }

        public string AnniversaryDay
        {
            get { return anniversaryDay; }
            set { anniversaryDay = value; }
        }

        public string AnniversaryMonth
        {
            get { return anniversaryMonth; }
            set { anniversaryMonth = value; }
        }

        public string AnniversaryYear
        {
            get { return anniversaryYear; }
            set { anniversaryYear = value; }
        }

        public string SecondaryAddress
        {
            get { return secondaryAddress; }
            set { secondaryAddress = value; }
        }

        public string SecondaryHome
        {
            get { return secondaryHome; }
            set { secondaryHome = value; }
        }

        public string SecondaryNotes
        {
            get { return secondaryNotes; }
            set { secondaryNotes = value; }
        }

    }
}