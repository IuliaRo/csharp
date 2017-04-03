using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

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
            return FirstName == other.FirstName && LastName == other.LastName;
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
            return "Name = " + FirstName + "\nLastname =  " + LastName + "\nAddres =  " + Address;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (LastName.CompareTo(other.LastName) == 0) return FirstName.CompareTo(other.FirstName);
            else
            {
                return LastName.CompareTo(other.LastName);
            }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Nickname { get; set; }
        public string Photo { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string TelephoneHome { get; set; }
        public string TelephoneMobile { get; set; }
        public string TelephoneWork { get; set; }
        public string Fax { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Homepage { get; set; }
        public string BirthdayDay { get; set; }
        public string BirthdayMonth { get; set; }
        public string BirthdayYear { get; set; }
        public string AnniversaryDay { get; set; }
        public string AnniversaryMonth { get; set; }
        public string AnniversaryYear { get; set; }
        public string SecondaryAddress { get; set; }
        public string SecondaryHome { get; set; }
        public string SecondaryNotes { get; set; }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(TelephoneHome) + CleanUp(TelephoneMobile) + CleanUp(TelephoneWork)).Trim();
                }
            }
            set { allPhones = value; }
        }
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUp(Email1) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set { allEmails = value; }
        }

        public string WholeContactString
        {
            get
            {
                if (wholeContactString != null)
                {
                    return wholeContactString;
                }
                else
                {
                    return (CleanUp(FirstName + LastName + Title + Address + AllPhones + AllEmails)).Trim();
                }
            }
            set { wholeContactString = value; }
        }

        private string CleanUp(string phoneNumber)
        {
            if (phoneNumber == null || phoneNumber == "")
                return "";
            return Regex.Replace(phoneNumber, @"[: -()\r\nHM]", "") + "\r\n";
        }

        private string wholeContactString;
        private string allEmails;
        private string allPhones;

    }
}