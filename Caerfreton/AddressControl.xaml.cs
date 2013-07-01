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
    /// Interaction logic for AddressControl.xaml
    /// </summary>
    public partial class AddressControl : UserControl {

        #region AddressDep

        /// <summary>
        /// AddressDep Dependency Property
        /// </summary>
        public static readonly DependencyProperty AddressDepProperty =
            DependencyProperty.Register( "AddressDep", typeof( Address ), typeof( AddressControl ),
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

        

        public AddressControl( ):this(new Address()) {
            InitializeComponent( );
            DataContext = this;
            Loaded += AddressControl_Loaded;
        }

        void AddressControl_Loaded( object sender, RoutedEventArgs e ) {
            
        }

        public AddressControl( Address address ) {
            AddressDep = address;
        }
    }
}
