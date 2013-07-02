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
            get { 
                Need refinedNeed= (Need)GetValue( NeedDepProperty );
                refinedNeed.StartDate = new DateTime( StartDateDep.Year, StartDateDep.Month, StartDateDep.Day, StartTimeDep.Hours, StartTimeDep.Minutes, StartTimeDep.Seconds );
                refinedNeed.EndDate = new DateTime( EndDateDep.Year, EndDateDep.Month, EndDateDep.Day, EndTimeDep.Hours, EndTimeDep.Minutes, EndTimeDep.Seconds );
                return ( refinedNeed );
            }
            set {
                if ( value.StartDate == null ) value.StartDate = DateTime.Now;
                if ( value.EndDate == null ) value.EndDate = DateTime.Now;
                SetValue( NeedDepProperty, value );
                if ( value.Schedule != null ) {
                    ScheduleDep = value.Schedule;
                } else {
                    ScheduleDep = new Schedule( );
                }
                
                StartDateDep = value.StartDate.Value.Date;
                EndDateDep = value.EndDate.Value.Date;
                StartTimeDep = value.StartDate.Value.TimeOfDay;
                EndTimeDep = value.EndDate.Value.TimeOfDay;
                
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

        #region StartTimeDep

        /// <summary>
        /// StartTimeDep Dependency Property
        /// </summary>
        public static readonly DependencyProperty StartTimeDepProperty =
            DependencyProperty.Register( "StartTimeDep", typeof( TimeSpan ), typeof( ScheduleControl ),
                new FrameworkPropertyMetadata( (TimeSpan)new TimeSpan() ) );

        /// <summary>
        /// Gets or sets the StartTimeDep property.  This dependency property 
        /// indicates ....
        /// </summary>
        public TimeSpan StartTimeDep {
            get { 
                return (TimeSpan)GetValue(StartTimeDepProperty);  
            }
            set {
                
                SetValue( StartTimeDepProperty,new DateTime(StartDateDep.Year,StartDateDep.Month,StartDateDep.Day, value.Hours, value.Minutes, value.Seconds ).TimeOfDay ); 
            }
        }

        #endregion

        #region EndTimeDep

        /// <summary>
        /// EndTimeDep Dependency Property
        /// </summary>
        public static readonly DependencyProperty EndTimeDepProperty =
            DependencyProperty.Register( "EndTimeDep", typeof( TimeSpan ), typeof( ScheduleControl ),
                new FrameworkPropertyMetadata( (TimeSpan)new TimeSpan() ) );

        /// <summary>
        /// Gets or sets the EndTimeDep property.  This dependency property 
        /// indicates ....
        /// </summary>
        public TimeSpan EndTimeDep {
            get {
                return (TimeSpan)GetValue( EndTimeDepProperty );
            }
            set {
                
                SetValue( EndTimeDepProperty, new DateTime( EndDateDep.Year, EndDateDep.Month, EndDateDep.Day, value.Hours, value.Minutes, value.Seconds ).TimeOfDay ); 
            }
        }

        #endregion

        #region StartDateDep

        /// <summary>
        /// StartDateDep Dependency Property
        /// </summary>
        public static readonly DependencyProperty StartDateDepProperty =
            DependencyProperty.Register( "StartDateDep", typeof( DateTime ), typeof( ScheduleControl ),
                new FrameworkPropertyMetadata( (DateTime)DateTime.Now ) );

        /// <summary>
        /// Gets or sets the StartDateDep property.  This dependency property 
        /// indicates ....
        /// </summary>
        public DateTime StartDateDep {
            get { return (DateTime)GetValue( StartDateDepProperty ); }
            set { SetValue( StartDateDepProperty, value ); }
        }

        #endregion

        #region EndDateDep

        /// <summary>
        /// EndDateDep Dependency Property
        /// </summary>
        public static readonly DependencyProperty EndDateDepProperty =
            DependencyProperty.Register( "EndDateDep", typeof( DateTime ), typeof( ScheduleControl ),
                new FrameworkPropertyMetadata( (DateTime)DateTime.Now ) );

        /// <summary>
        /// Gets or sets the EndDateDep property.  This dependency property 
        /// indicates ....
        /// </summary>
        public DateTime EndDateDep {
            get { return (DateTime)GetValue( EndDateDepProperty ); }
            set { SetValue( EndDateDepProperty, value ); }
        }

        #endregion

        

        

        

        

        public ScheduleControl( ):this(new Need()) {
            InitializeComponent( );
            Loaded += ScheduleControl_Loaded;
            DataContext = this;
        }

        void ScheduleControl_Loaded( object sender, RoutedEventArgs e ) {
            switch ( NeedDep.Type ) {
                case 0: //Daily
                    DailyRadioButton.IsChecked = true;
                    RepeatUnits.Content = "Day(s)";
                    break;
                case 1: //Weekly
                    WeeklyRadioButton.IsChecked = true;
                    RepeatUnits.Content = "Week(s)";
                    break;
                case 2: //Monthly
                    MonthlyRadioButton.IsChecked = true;
                    RepeatUnits.Content = "Month(s)";
                    break;
                case 3: //Yearly
                    YearlyRadioButton.IsChecked = true;
                    RepeatUnits.Content = "Year(s)";
                    RepeatTextBox.Text = "1";
                    break;
                default:
                    DailyRadioButton.IsChecked = true;
                    RepeatUnits.Content = "Day(s)";
                    break;
            }


        }

        public ScheduleControl( Need need ){
            NeedDep = need;
        }
    }
}
