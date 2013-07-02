using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Caerfreton {
    public class DatabaseAccess {
        public DatabaseAccess( ) {
        }

        Dictionary<string, int> csvheaders = new Dictionary<string, int>( );
        CFdbDataContext dc = new CFdbDataContext( );

        public List<PersonalDetail> ImportFromCSVFile(string filepath){
            if ( File.Exists( filepath ) ) {

                int i;
                var data = File.ReadAllLines( filepath );

                csvheaders.Clear( );
                var headerArray = data[0].Split( ",".ToCharArray( ) );
                for ( i = 0; i < headerArray.Count( ); i++ ) {
                    csvheaders.Add( headerArray[i], i );
                }

                for ( i = 1; i < data.Count( ); i++ ) {
                    ImportItem( data[i].Split( ",".ToCharArray( ) ) );
                }
                MessageBox.Show( "Added " + i + " items of data" );
            }
            var result =
                ( from pd in dc.PersonalDetails
                  select pd ).ToList( );

            return ( result );
        }

        private void ImportItem( string[] MemberItems ) {
            if ( MemberItems != null && MemberItems.Count( ) > 10 ) {
                
                PersonalDetail personalDetail = getPersonalDetails( MemberItems );
                Address address;
                if ( personalDetail.Address == null ) {
                    address = new Address( );
                    address.Id = -1;
                } else {
                    address=personalDetail.Address;
                }
                Name name;
                if ( personalDetail.Name == null ) {
                    name = new Name( );
                    name.Id = -1;
                } else {
                    name=personalDetail.Name;
                }

                name.Title = MemberItems[csvheaders["Title"]];
                name.Forename = MemberItems[csvheaders["First Name"]];
                name.Middle = MemberItems[csvheaders["MiddleName"]];
                name.Surname = MemberItems[csvheaders["Last Name"]];

                if ( name.Id < 0 ) {
                    dc.Names.InsertOnSubmit( name );
                }
                dc.SubmitChanges( );
                personalDetail.NameId = name.Id;

                address.House = MemberItems[csvheaders["HouseNumber"]];
                address.Street = MemberItems[csvheaders["Address"]];
                address.District = "";
                address.Town = MemberItems[csvheaders["City"]];
                address.County = "CAER";
                address.PostCode = MemberItems[csvheaders["Postal"]];

                if ( address.Id < 0 ) {
                    dc.Addresses.InsertOnSubmit( address );
                }
                dc.SubmitChanges( );
                personalDetail.AddressId = address.Id;

                if(personalDetail.Id<=0){
                dc.PersonalDetails.InsertOnSubmit(personalDetail);
                }
                dc.SubmitChanges();

                if(personalDetail.Id>0){
                    var existingContacts=
                        from cnt in dc.ContactDetails
                        from lnk in dc.Link_PersonalDetails_Contacts
                        where lnk.PersonalDetailsId==personalDetail.Id && cnt.Id==lnk.ContactId
                        select lnk;
                    foreach(var lnk in existingContacts){
                        dc.Link_PersonalDetails_Contacts.DeleteOnSubmit(lnk);
                        dc.ContactDetails.DeleteOnSubmit(lnk.ContactDetail);
                    }
                    dc.SubmitChanges();
                }

                if(!String.IsNullOrWhiteSpace(MemberItems[csvheaders["Mobile"]])){
                    String s=MemberItems[csvheaders["Mobile"]].Replace(" ","");
                    ContactDetail cd=new ContactDetail();
                    cd.Type=1;
                    cd.Detail=s;
                    dc.ContactDetails.InsertOnSubmit(cd);
                    dc.SubmitChanges();
                    Link_PersonalDetails_Contact link=new Link_PersonalDetails_Contact();
                    link.ContactId=cd.Id;
                    link.PersonalDetailsId=personalDetail.Id;
                    dc.Link_PersonalDetails_Contacts.InsertOnSubmit(link);
                    dc.SubmitChanges();
                }

                if(!String.IsNullOrWhiteSpace(MemberItems[csvheaders["Email"]])){
                    String s=MemberItems[csvheaders["Email"]];
                    ContactDetail cd=new ContactDetail();
                    cd.Type=2;
                    cd.Detail=s;
                    dc.ContactDetails.InsertOnSubmit(cd);
                    dc.SubmitChanges();
                    Link_PersonalDetails_Contact link=new Link_PersonalDetails_Contact();
                    link.ContactId=cd.Id;
                    link.PersonalDetailsId=personalDetail.Id;
                    dc.Link_PersonalDetails_Contacts.InsertOnSubmit(link);
                    dc.SubmitChanges();
                }
                
                DateTime dob;
                if(!String.IsNullOrWhiteSpace(MemberItems[csvheaders["Birthday"]])){
                    if(DateTime.TryParse(MemberItems[csvheaders["Birthday"]],out dob)){
                        personalDetail.DateOfBirth=dob;
                    }
                }

                if ( !String.IsNullOrWhiteSpace( MemberItems[csvheaders["Sex"]] ) ) {
                    personalDetail.Gender = MemberItems[csvheaders["Sex"]].ToUpper( )[0];
                }
                
                personalDetail.UserName = MemberItems[csvheaders["UserName"]];
                personalDetail.Password = MemberItems[csvheaders["Password"]];
                personalDetail.MothersMaidenName = MemberItems[csvheaders["MothersMaidenName"]];
                personalDetail.BankCardNumber = MemberItems[csvheaders["BankCard"]];
                personalDetail.CVV2 = MemberItems[csvheaders["CVV2"]];
                DateTime expiry;
                if ( DateTime.TryParse( MemberItems[csvheaders["CardExpiryDate"]], out expiry ) ) {
                    personalDetail.ExpiryDate = expiry;
                }
                
                personalDetail.NINumber = MemberItems[csvheaders["NINumber"]];
                personalDetail.Occupation = MemberItems[csvheaders["Occupation"]];
                if ( personalDetail.Occupation.Length > 150 ) {
                    personalDetail.Occupation = personalDetail.Occupation.Substring( 0, 150 );
                }
                personalDetail.BloodType = MemberItems[csvheaders["BloodType"]];
                
                float f;
                if(float.TryParse(MemberItems[csvheaders["Weight(kgs)"]],out f)){
                personalDetail.Weight_kgs_ = f ;
                }
                if(float.TryParse(MemberItems[csvheaders["Height(met)"]],out f)){
                personalDetail.Height_m_ = f;
                }
                
                SetNextOfKin(MemberItems,ref personalDetail);
                SetReferences(MemberItems,ref personalDetail);



                if ( personalDetail.Id < 0 ) {
                    dc.PersonalDetails.InsertOnSubmit( personalDetail );
                }
                dc.SubmitChanges( );
                
            }
        }

        private void SetReferences( string[] MemberItems, ref PersonalDetail personalDetail ) {
            if(!String.IsNullOrWhiteSpace(MemberItems[csvheaders["REF1-Surname"]])){
                SetReference(MemberItems,ref personalDetail,"REF1-");
            }
            if(!String.IsNullOrWhiteSpace(MemberItems[csvheaders["REF2-Surname"]])){
                SetReference(MemberItems,ref personalDetail,"REF2-");
            }
        }

        private void SetReference( string[] MemberItems,ref PersonalDetail personalDetail, string p ) {
            Address address;
            Name name;
            int personalDetailId = personalDetail.Id;
            dc.SubmitChanges( );
            if ( !String.IsNullOrWhiteSpace( MemberItems[csvheaders[p + "Surname"]] ) ) {
                Reference reference;
                var existingReferences =
                    from re in dc.References
                    from lnk in dc.Link_PersonalDetails_References
                    where re.Name.Surname == MemberItems[csvheaders[p + "Surname"]] &&
                        re.Name.Title == MemberItems[csvheaders[p + "Title"]] &&
                        lnk.PersonalDetailsId == personalDetailId && lnk.ReferenceId == re.Id
                    select re;
                if ( existingReferences != null && existingReferences.Count( ) > 0 ) {
                    reference = existingReferences.First( );
                } else {
                    reference = new Reference( );
                    reference.FollowedUp = null;
                    reference.ConfirmedOK = null;
                }
                if ( !String.IsNullOrWhiteSpace( MemberItems[csvheaders[p + "Occupation"]] ) ) {
                    reference.Occupation = MemberItems[csvheaders[p + "Occupation"]];
                    if ( reference.Occupation.Length > 150 ) {
                        reference.Occupation = reference.Occupation.Substring( 0, 150 );
                    }
                }
                if ( reference.Id <= 0 ) {
                    address = new Address( );
                    name = new Name( );
                    dc.SubmitChanges( );
                    dc.Addresses.InsertOnSubmit( address );
                    dc.SubmitChanges( );
                    dc.Names.InsertOnSubmit( name );
                    dc.SubmitChanges( );
                    reference.AddressId = address.Id;
                    reference.NameId = name.Id;
                    reference.PersonalDetailsId = personalDetail.Id;
                    dc.References.InsertOnSubmit( reference );
                    
                } 
                dc.SubmitChanges( );

                name = null;
                if ( reference.NameId > 0 ) {
                    name = reference.Name;
                } else {
                    name = new Name( );
                }
                if ( !String.IsNullOrWhiteSpace( MemberItems[csvheaders[p+"Title"]] ) )
                    name.Title = MemberItems[csvheaders[p+"Title"]];
                if ( !String.IsNullOrWhiteSpace( MemberItems[csvheaders[p+"GivenName"]] ) )
                    name.Forename = MemberItems[csvheaders[p+"GivenName"]];
                if ( !String.IsNullOrWhiteSpace( MemberItems[csvheaders[p+"MiddleInitial"]] ) )
                    name.Middle = MemberItems[csvheaders[p+"MiddleInitial"]];
                if ( !String.IsNullOrWhiteSpace( MemberItems[csvheaders[p+"Surname"]] ) )
                    name.Surname = MemberItems[csvheaders[p+"Surname"]];
                if ( name.Id <= 0 )
                    dc.Names.InsertOnSubmit( name );
                dc.SubmitChanges( );
                reference.NameId = name.Id;

                address = null;
                if ( reference.AddressId > 0 ) {
                    address = reference.Address;
                } else {
                    address = new Address( );
                }
                if ( !String.IsNullOrWhiteSpace( MemberItems[csvheaders[p+"StreetAddress"]] ) ) {
                    var words = MemberItems[csvheaders[p+"StreetAddress"]].Split( " ".ToCharArray( ) );
                    try {
                        address.House = words[0];
                        address.Street = MemberItems[csvheaders[p+"StreetAddress"]].Remove( 0, words[0].Length ).Trim( );
                    } catch ( Exception ) { }
                }
                if ( !String.IsNullOrWhiteSpace( MemberItems[csvheaders[p+"City"]] ) )
                    address.Town = MemberItems[csvheaders[p+"City"]];
                if ( !String.IsNullOrWhiteSpace( MemberItems[csvheaders[p+"ZipCode"]] ) )
                    address.PostCode = MemberItems[csvheaders[p+"ZipCode"]];
                if ( address.Id <= 0 ) {
                    dc.Addresses.InsertOnSubmit( address );
                }
                dc.SubmitChanges( );
                reference.AddressId = address.Id;

                if ( !String.IsNullOrWhiteSpace( MemberItems[csvheaders[p+"TelephoneNumber"]] ) ) {
                    string telno = MemberItems[csvheaders[p+"TelephoneNumber"]].Replace( " ", "" );

                    var existingContacts =
                        from cnt in dc.ContactDetails
                        from lnk in dc.Link_NextOfKin_Contacts
                        where lnk.NextOfKinId == reference.Id && lnk.ContactId == cnt.Id && cnt.Detail == telno
                        select cnt;

                    if ( existingContacts != null && existingContacts.Count( ) > 0 ) {
                        // do nothing
                    } else {
                        ContactDetail newContact = new ContactDetail( );
                        Link_Reference_Contact newLink = new Link_Reference_Contact( );
                        if ( telno.StartsWith( "07" ) ) {
                            newContact.Type = 1;
                        } else {
                            newContact.Type = 3;
                        }
                        newContact.Detail = telno;
                        dc.ContactDetails.InsertOnSubmit( newContact );
                        dc.SubmitChanges( );
                        if ( reference.Id <= 0 ) {
                            dc.References.InsertOnSubmit( reference );
                        }
                        dc.SubmitChanges( );
                        newLink.ReferenceId = reference.Id;
                        newLink.ContactId = newContact.Id;
                        dc.Link_Reference_Contacts.InsertOnSubmit( newLink );
                        dc.SubmitChanges( );
                    }

                }

                if ( !String.IsNullOrWhiteSpace( MemberItems[csvheaders[p + "EmailAddress"]] ) ) {
                    string email = MemberItems[csvheaders[p + "EmailAddress"]];

                    var existingContacts =
                        from cnt in dc.ContactDetails
                        from lnk in dc.Link_NextOfKin_Contacts
                        where lnk.NextOfKinId == reference.Id && lnk.ContactId == cnt.Id && cnt.Detail == email
                        select cnt;

                    if ( existingContacts != null && existingContacts.Count( ) > 0 ) {
                        // do nothing
                    } else {
                        ContactDetail newContact = new ContactDetail( );
                        Link_Reference_Contact newLink = new Link_Reference_Contact( );
                        newContact.Type = 2;
                        newContact.Detail = email;
                        dc.ContactDetails.InsertOnSubmit( newContact );
                        dc.SubmitChanges( );
                        if ( reference.Id <= 0 ) {
                            dc.References.InsertOnSubmit( reference );
                        }
                        dc.SubmitChanges( );
                        newLink.ReferenceId = reference.Id;
                        newLink.ContactId = newContact.Id;
                        dc.Link_Reference_Contacts.InsertOnSubmit( newLink );
                        dc.SubmitChanges( );
                    }

                }

                var existingLinks =
                    from lnk in dc.Link_PersonalDetails_References
                    where lnk.PersonalDetailsId == personalDetailId && lnk.ReferenceId == reference.Id
                    select lnk;

                if ( !( existingLinks != null && existingLinks.Count( ) > 0 ) ) {
                    Link_PersonalDetails_Reference link = new Link_PersonalDetails_Reference( );
                    link.PersonalDetailsId = personalDetail.Id;
                    link.ReferenceId = reference.Id;
                    dc.Link_PersonalDetails_References.InsertOnSubmit( link );
                    dc.SubmitChanges( );
                }
            }
        }

        private void SetNextOfKin( string[] MemberItems,ref PersonalDetail personalDetail ) {
            Address address;
            Name name;
            
            if ( !String.IsNullOrWhiteSpace( MemberItems[csvheaders["NOK-Surname"]] ) ) {

                NextOfKin nok;
                if ( personalDetail.NextOfKinId > 0 ) {
                    nok = personalDetail.NextOfKin;
                } else {
                    nok = new NextOfKin( );
                    
                }


                name = null;
                if ( nok.NameId > 0 ) {
                    name = nok.Name;
                } else {
                    name = new Name( );
                }
                if ( !String.IsNullOrWhiteSpace( MemberItems[csvheaders["NOK-Title"]] ) )
                    name.Title = MemberItems[csvheaders["NOK-Title"]];
                if ( !String.IsNullOrWhiteSpace( MemberItems[csvheaders["NOK-GivenName"]] ) )
                    name.Forename = MemberItems[csvheaders["NOK-GivenName"]];
                if ( !String.IsNullOrWhiteSpace( MemberItems[csvheaders["NOK-MiddleInitial"]] ) )
                    name.Middle = MemberItems[csvheaders["NOK-MiddleInitial"]];
                if ( !String.IsNullOrWhiteSpace( MemberItems[csvheaders["NOK-Surname"]] ) )
                    name.Surname = MemberItems[csvheaders["NOK-Surname"]];
                if ( name.Id <= 0 )
                    dc.Names.InsertOnSubmit( name );
                try {
                    dc.SubmitChanges( );
                } catch ( Exception ) { }
                nok.NameId = name.Id;

                address = null;
                if ( nok.AddressId > 0 ) {
                    address = nok.Address;
                } else {
                    address = new Address( );
                }
                if ( !String.IsNullOrWhiteSpace( MemberItems[csvheaders["NOK-StreetAddress"]] ) ) {
                    var words = MemberItems[csvheaders["NOK-StreetAddress"]].Split( " ".ToCharArray( ) );
                    try {
                        address.House = words[0];
                        address.Street = MemberItems[csvheaders["NOK-StreetAddress"]].Remove( 0, words[0].Length ).Trim( );
                    } catch ( Exception ) { }
                }
                if ( !String.IsNullOrWhiteSpace( MemberItems[csvheaders["NOK-City"]] ) )
                    address.Town = MemberItems[csvheaders["NOK-City"]];
                if ( !String.IsNullOrWhiteSpace( MemberItems[csvheaders["NOK-ZipCode"]] ) )
                    address.PostCode = MemberItems[csvheaders["NOK-ZipCode"]];
                if ( address.Id <= 0 ) {
                    dc.Addresses.InsertOnSubmit( address );
                }
                try {
                    dc.SubmitChanges( );
                } catch ( Exception ) { }
                nok.AddressId = address.Id;

                if ( !String.IsNullOrWhiteSpace( MemberItems[csvheaders["NOK-TelephoneNumber"]] ) ) {
                    string telno = MemberItems[csvheaders["NOK-TelephoneNumber"]].Replace( " ", "" );

                    var existingContacts =
                        from cnt in dc.ContactDetails
                        from lnk in dc.Link_NextOfKin_Contacts
                        where lnk.NextOfKinId == nok.Id && lnk.ContactId == cnt.Id && cnt.Detail == telno
                        select cnt;

                    if ( existingContacts != null && existingContacts.Count( ) > 0 ) {
                        // do nothing
                    } else {
                        ContactDetail newContact = new ContactDetail( );
                        Link_NextOfKin_Contact newLink = new Link_NextOfKin_Contact( );
                        if ( telno.StartsWith( "07" ) ) {
                            newContact.Type = 1;
                        } else {
                            newContact.Type = 3;
                        }
                        newContact.Detail = telno;
                        dc.ContactDetails.InsertOnSubmit( newContact );
                        try {
                            dc.SubmitChanges( );
                        } catch ( Exception ) { }
                        if ( nok.Id <= 0 ) {
                            dc.NextOfKins.InsertOnSubmit( nok );
                        }
                        try {
                            dc.SubmitChanges( );
                        } catch ( Exception ) { }
                        newLink.NextOfKinId = nok.Id;
                        newLink.ContactId = newContact.Id;
                        dc.Link_NextOfKin_Contacts.InsertOnSubmit( newLink );
                        try {
                            dc.SubmitChanges( );
                        } catch ( Exception ) { }
                    }

                }




            }
        }

        private PersonalDetail getPersonalDetails( string[] MemberItems ) {
            String NINumber = MemberItems[csvheaders["NINumber"]];
            String Surname = MemberItems[csvheaders["Last Name"]];
            PersonalDetail result = null;
            var pd =
                from pds in dc.PersonalDetails
                where pds.NINumber == NINumber && pds.Name.Surname==Surname
                select pds;
            if ( pd != null && pd.Count( ) > 0 ) {
                result = pd.First( );
            } else {
                result = new PersonalDetail( );
                result.Id = -1;
            }
            return ( result );
        }

        public static List<Reference> GetReferences( int memberId ) {
            CFdbDataContext dc = new CFdbDataContext( );

            var references =
                from refer in dc.References
                from lnk in dc.Link_PersonalDetails_References
                where lnk.PersonalDetailsId == memberId && lnk.ReferenceId == refer.Id
                select refer;

            if ( references != null && references.Count( ) > 0 ) {
                return ( references.ToList() );
            }
            return ( null );
        }

        
    }
}
