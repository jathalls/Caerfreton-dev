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
    /// Interaction logic for BasicPersonControl.xaml
    /// </summary>
    public partial class BasicPersonControl : UserControl {

        #region ContactList

        /// <summary>
        /// ContactList Dependency Property
        /// </summary>
        public static readonly DependencyProperty ContactListProperty =
            DependencyProperty.Register( "ContactList", typeof( List<ContactDetail> ), typeof( BasicPersonControl ),
                new FrameworkPropertyMetadata( (List<ContactDetail>)new List<ContactDetail>() ) );

        /// <summary>
        /// Gets or sets the ContactList property.  This dependency property 
        /// indicates ....
        /// </summary>
        public List<ContactDetail> ContactList {
            get { return (List<ContactDetail>)GetValue( ContactListProperty ); }
            set { SetValue( ContactListProperty, value ); }
        }

        #endregion

        #region NameDep

        /// <summary>
        /// NameDep Dependency Property
        /// </summary>
        public static readonly DependencyProperty NameDepProperty =
            DependencyProperty.Register( "NameDep", typeof( Name ), typeof( BasicPersonControl ),
                new FrameworkPropertyMetadata( (Name)new Name() ) );

        /// <summary>
        /// Gets or sets the NameDep property.  This dependency property 
        /// indicates ....
        /// </summary>
        public Name NameDep {
            get { return (Name)GetValue( NameDepProperty ); }
            set { SetValue( NameDepProperty, value ); }
        }

        #endregion


        #region AddressDep

        /// <summary>
        /// AddressDep Dependency Property
        /// </summary>
        public static readonly DependencyProperty AddressDepProperty =
            DependencyProperty.Register( "AddressDep", typeof( Address ), typeof( BasicPersonControl ),
                new FrameworkPropertyMetadata( (Address)new Address() ) );

        /// <summary>
        /// Gets or sets the AddressDep property.  This dependency property 
        /// indicates ....
        /// </summary>
        public Address AddressDep {
            get { return (Address)GetValue( AddressDepProperty ); }
            set { SetValue( AddressDepProperty, value ); }
        }

        #endregion

        
        


        public BasicPersonControl( ):this(new Name(),new Address(),new List<ContactDetail>()) {
            InitializeComponent( );
            Loaded += BasicPersonControl_Loaded;
        }

        void BasicPersonControl_Loaded( object sender, RoutedEventArgs e ) {
            
        }

        public BasicPersonControl( Name name, Address address, List<ContactDetail> contacts ) {
            NameDep = name;
            AddressDep = address;
            ContactList = contacts;
        }
    }
}
