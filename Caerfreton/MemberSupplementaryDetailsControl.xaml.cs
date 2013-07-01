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
    /// Interaction logic for MemberSupplementaryDetailsControl.xaml
    /// </summary>
    public partial class MemberSupplementaryDetailsControl : UserControl {

        #region PersonalDetailsDep

        /// <summary>
        /// PersonalDetailsDep Dependency Property
        /// </summary>
        public static readonly DependencyProperty PersonalDetailsDepProperty =
            DependencyProperty.Register( "PersonalDetailsDep", typeof( PersonalDetail ), typeof( MemberSupplementaryDetailsControl ),
                new FrameworkPropertyMetadata( (PersonalDetail)new PersonalDetail() ) );

        /// <summary>
        /// Gets or sets the PersonalDetailsDep property.  This dependency property 
        /// indicates ....
        /// </summary>
        public PersonalDetail PersonalDetailsDep {
            get { return (PersonalDetail)GetValue( PersonalDetailsDepProperty ); }
            set { SetValue( PersonalDetailsDepProperty, value ); }
        }

        #endregion

        

        public MemberSupplementaryDetailsControl( ):this(new PersonalDetail()) {
            InitializeComponent( );
            DataContext = this;
        }

        public MemberSupplementaryDetailsControl( PersonalDetail pd ) {
            PersonalDetailsDep = pd;
        }
    }
}
