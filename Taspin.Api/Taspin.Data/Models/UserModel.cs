using System;
using System.Runtime.Serialization;

namespace Taspin.Data.Models
{
    public class UserModel
    {
        [DataMember(Name = "user_id")]
        public int Id { get; set; }

        [DataMember(Name = "username")]
        public string Username { get; set; }

        //[DataMember(Name = "name")]
        //public string Name { get; set; }

        //[DataMember(Name = "surname")]
        //public string Surname { get; set; }

        //[DataMember(Name = "email")]
        //public string Email { get; set; }

        //[DataMember(Name = "passwrod")]
        //public string Password { get; set; }
    }
}
