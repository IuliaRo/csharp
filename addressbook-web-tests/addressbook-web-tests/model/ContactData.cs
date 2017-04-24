using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Xml.Serialization;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public ContactData()
        {
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

        [Column (Name = "firstname")]
        public string FirstName { get; set; }

        [Column(Name = "lastname")]
        public string LastName { get; set; }

        [Column(Name = "middlename")]
        public string MiddleName { get; set; }

        [Column(Name = "nickname")]
        public string Nickname { get; set; }

        //public string Photo { get; set; }

        [Column(Name = "title")]
        public string Title { get; set; }

        [Column(Name = "company")]
        public string Company { get; set; }

        [Column(Name = "address")]
        public string Address { get; set; }

        [Column(Name = "home")]
        public string TelephoneHome { get; set; }

        [Column(Name = "mobile")]
        public string TelephoneMobile { get; set; }

        [Column(Name = "work")]
        public string TelephoneWork { get; set; }

        [Column(Name = "fax")]
        public string Fax { get; set; }

        [Column(Name = "email")]
        public string Email1 { get; set; }

        [Column(Name = "email2")]
        public string Email2 { get; set; }

        [Column(Name = "email3")]
        public string Email3 { get; set; }

        [Column(Name = "homepage")]
        public string Homepage { get; set; }

        [Column(Name = "bday")]
        public string BirthdayDay { get; set; }

        [Column(Name = "bmonth")]
        public string BirthdayMonth { get; set; }

        [Column(Name = "byear")]
        public string BirthdayYear { get; set; }

        [Column(Name = "aday")]
        public string AnniversaryDay { get; set; }

        [Column(Name = "amonth")]
        public string AnniversaryMonth { get; set; }

        [Column(Name = "ayear")]
        public string AnniversaryYear { get; set; }

        [Column(Name = "address2")]
        public string SecondaryAddress { get; set; }

        [Column(Name = "phone2")]
        public string SecondaryHome { get; set; }

        [Column(Name = "notes")]
        public string SecondaryNotes { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity] //PrimaryKey - the unique key of the table; Identity - for unique objects identification
        public string Id { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB()) //using this using *.Close method will be called automatically
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }

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

        [JsonIgnore]
        [XmlIgnore]
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