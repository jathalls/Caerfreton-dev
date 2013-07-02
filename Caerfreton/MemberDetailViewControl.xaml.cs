using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Caerfreton {
    /// <summary>
    /// Interaction logic for MemberDetailViewControl.xaml
    /// </summary>
    public partial class MemberDetailViewControl : UserControl {

        #region MemberDetailDep

        /// <summary>
        /// MemberDetailDep Dependency Property
        /// </summary>
        public static readonly DependencyProperty MemberDetailDepProperty =
            DependencyProperty.Register( "MemberDetailDep", typeof( PersonalDetail ), typeof( MemberDetailViewControl ),
                new FrameworkPropertyMetadata( (PersonalDetail)new PersonalDetail() ) );

        /// <summary>
        /// Gets or sets the MemberDetailDep property.  This dependency property 
        /// indicates ....
        /// </summary>
        public PersonalDetail MemberDetailDep {
            get { return (PersonalDetail)GetValue( MemberDetailDepProperty ); }
            set { 
                SetValue( MemberDetailDepProperty, value );
                if ( MemberDetailName != null ) {
                    MemberDetailName.NameDep = value.Name;
                }
                if ( MemberDetailAddress != null ) {
                    MemberDetailAddress.AddressDep = value.Address;
                }
                if ( memberSupplementaryDetailsControl != null ) {
                    memberSupplementaryDetailsControl.PersonalDetailsDep = value;
                }

                if ( value.NextOfKin != null && NOKBasicPersonControl!=null ) {
                    NOKBasicPersonControl.NameDep = value.NextOfKin.Name;
                    NOKBasicPersonControl.AddressDep = value.NextOfKin.Address;
                    NOKBasicPersonControl.UpdateLayout( );
                }

                if ( ReferencesTabControl != null ) {
                    ReferencesTabControl.Items.Clear( );
                    var references = DatabaseAccess.GetReferences( value.Id );
                    if ( references != null && references.Count( ) > 0 ) {
                        int i=1;
                        foreach ( var reference in references ) {
                            TabItem ti = new TabItem( );
                            ti.Header = "REF" + i++;
                            BasicPersonControl bpc = new BasicPersonControl( );
                            bpc.NameDep = reference.Name;
                            bpc.AddressDep = reference.Address;
                            ti.Content = bpc;
                            ReferencesTabControl.Items.Add( ti );
                        }

                    }
                }
                this.UpdateLayout( );
            }
        }

        #endregion

        

        public MemberDetailViewControl( ) {
            InitializeComponent( );
            this.DataContext = this.MemberDetailDep;
            

        }
    }
}
