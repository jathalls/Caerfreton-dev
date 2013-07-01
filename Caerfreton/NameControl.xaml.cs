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
    /// Interaction logic for NameControl.xaml
    /// </summary>
    public partial class NameControl : UserControl {

#region NameDep

        /// <summary>
        /// NameDep Dependency Property
        /// </summary>
        public static readonly DependencyProperty NameDepProperty =
            DependencyProperty.Register("NameDep", typeof(Name), typeof(NameControl),
                new FrameworkPropertyMetadata((Name)new Name()));

        /// <summary>
        /// Gets or sets the NameDep property.  This dependency property 
        /// indicates ....
        /// </summary>
        public Name NameDep
        {
            get { return (Name)GetValue(NameDepProperty); }
            set { 
                SetValue(NameDepProperty, value); 
            }
        }
        
        #endregion

        
        public NameControl( ):this(new Name()) {
            InitializeComponent( );
            DataContext = this;
            Loaded+=NameControl_Loaded;
        }

        void NameControl_Loaded(object sender, RoutedEventArgs e)
        {
            
           

            

            
        }

        public NameControl( Name name ) {
            NameDep=name;
        }
    }
}
