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
                memberSupplementaryDetailsControl.PersonalDetailsDep = value;
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
