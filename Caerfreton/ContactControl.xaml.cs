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
    /// Interaction logic for ContactControl.xaml
    /// </summary>
    public partial class ContactControl : UserControl {

        #region ContactDep

        /// <summary>
        /// ContactDep Dependency Property
        /// </summary>
        public static readonly DependencyProperty ContactDepProperty =
            DependencyProperty.Register( "ContactDep", typeof( ContactDetail ), typeof( ContactControl ),
                new FrameworkPropertyMetadata( (ContactDetail)new ContactDetail() ) );

        /// <summary>
        /// Gets or sets the ContactDep property.  This dependency property 
        /// indicates ....
        /// </summary>
        public ContactDetail ContactDep {
            get { return (ContactDetail)GetValue( ContactDepProperty ); }
            set { SetValue( ContactDepProperty, value ); }
        }

        #endregion

        

        public ContactControl( ):this(new ContactDetail()) {
            InitializeComponent( );
        }

        public ContactControl( ContactDetail contactDetail ) {
            ContactDep = contactDetail;
        }
    }
}
