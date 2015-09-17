using System;
using PetaPoco;


namespace CQRS.Talk.Dependencies
{
    [TableName("PEOPLE")]
    public class Person
    {
        [Column(Name: "People_id")]
        public Guid PersonId { get; set; }

        public String ReferenceNumber { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        [Column(Name: "EMAILPRIMARY")]
        public String Email { get; set; }

        public DateTime JoinDate { get; set; }

        public DateTime LeavingDate { get; set; }

        public bool NewPensionScheme { get; set; }

        public bool IsCurrentlyEmployed { get; set; }

        #region Audit fields

        public DateTime DateCreated { get; set; }
        public String CreatedBy { get; set; }
        public DateTime DateLastModied { get; set; }
        public String LastModifiedBy { get; set; }

        #endregion
    }
}