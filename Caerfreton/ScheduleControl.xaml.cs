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
    /// Interaction logic for ScheduleControl.xaml
    /// </summary>
    public partial class ScheduleControl : UserControl {

        #region NeedDep

        /// <summary>
        /// Need Dependency Property
        /// </summary>
        public static readonly DependencyProperty NeedDepProperty =
            DependencyProperty.Register( "NeedDep", typeof( Need ), typeof( ScheduleControl ),
                new FrameworkPropertyMetadata( (Need)new Need() ) );

        /// <summary>
        /// Gets or sets the Need property.  This dependency property 
        /// indicates ....
        /// </summary>
        public Need NeedDep {
            get { return (Need)GetValue( NeedDepProperty ); }
            set { 
                SetValue( NeedDepProperty, value );
                if ( value.Schedule != null ) {
                    ScheduleDep = value.Schedule;
                } else {
                    ScheduleDep = new Schedule( );
                }
            }
        }

        #endregion

        #region ScheduleDep

        /// <summary>
        /// Schedule Dependency Property
        /// </summary>
        public static readonly DependencyProperty ScheduleDepProperty =
            DependencyProperty.Register( "ScheduleDep", typeof( Schedule ), typeof( ScheduleControl ),
                new FrameworkPropertyMetadata( (Schedule)new Schedule() ) );

        /// <summary>
        /// Gets or sets the Schedule property.  This dependency property 
        /// indicates ....
        /// </summary>
        public Schedule ScheduleDep {
            get { return (Schedule)GetValue( ScheduleDepProperty ); }
            set { SetValue( ScheduleDepProperty, value ); }
        }

        #endregion

        

        

        

        public ScheduleControl( ):this(new Need()) {
            InitializeComponent( );
            Loaded += ScheduleControl_Loaded;
            DataContext = this;
        }

        void ScheduleControl_Loaded( object sender, RoutedEventArgs e ) {
            
        }

        public ScheduleControl( Need need ){
            NeedDep = need;
        }
    }
}
