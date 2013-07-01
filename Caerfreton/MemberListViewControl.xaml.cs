using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for MemberListViewControl.xaml
    /// </summary>
    public partial class MemberListViewControl : UserControl {

        #region MemberListDep

        /// <summary>
        /// MemberListDep Dependency Property
        /// </summary>
        public static readonly DependencyProperty MemberListDepProperty =
            DependencyProperty.Register( "MemberListDep", typeof( List<PersonalDetail> ), typeof( MemberListViewControl ),
                new FrameworkPropertyMetadata( (List<PersonalDetail>)new List<PersonalDetail>() ) );

        /// <summary>
        /// Gets or sets the MemberListDep property.  This dependency property 
        /// indicates ....
        /// </summary>
        public List<PersonalDetail> MemberListDep {
            get { return (List<PersonalDetail>)GetValue( MemberListDepProperty ); }
            set { SetValue( MemberListDepProperty, value ); }
        }

        #endregion

        

        public MemberListViewControl( ) : this(new List<PersonalDetail>()) {
            InitializeComponent( );
            Loaded += MemberListViewControl_Loaded;
            DataContext = this;
            

        }

        void MemberListViewControl_Loaded( object sender, RoutedEventArgs e ) {
           
        }

        public MemberListViewControl( List<PersonalDetail> membersList ) {
            MemberListDep = membersList;
        }

        private void MemberListDataGrid_SelectionChanged( object sender, SelectionChangedEventArgs e ) {
            try {
                PersonalDetail selection = (PersonalDetail)( sender as DataGrid ).SelectedItem;
                OnSelectionChanged( new DataGridSelectionChangedEventArgs( selection ) );
            } catch ( Exception ex ) {
                Debug.WriteLine( ex.Message );
                Debug.WriteLine( ex.StackTrace );
            }

        }


        private readonly object SelectionChangedEventLock = new object( );
        private EventHandler SelectionChangedEvent;
        
        /// <summary>
        /// Event raised after the <see cref="Text" /> property value has changed.
        /// </summary>
        public event EventHandler SelectionChanged {
            add {
                lock ( SelectionChangedEventLock ) {
                    SelectionChangedEvent += value;
                }
            }
            remove {
                lock ( SelectionChangedEventLock ) {
                    SelectionChangedEvent -= value;
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="SelectionChanged" /> event.
        /// </summary>
        /// <param name="e"><see cref="EventArgs" /> object that provides the arguments for the event.</param>
        protected virtual void OnSelectionChanged( EventArgs e ) {
            EventHandler handler = null;

            lock ( SelectionChangedEventLock ) {
                handler = SelectionChangedEvent;

                if ( handler == null )
                    return;
            }

            handler( this, e );
        }

        

    }


    /// <summary>
    /// Provides arguments for an event.
    /// </summary>
    [Serializable]
    public class DataGridSelectionChangedEventArgs : EventArgs {
        public new static readonly DataGridSelectionChangedEventArgs Empty = new DataGridSelectionChangedEventArgs(null );

        #region Public Properties
        public PersonalDetail selectedPersonalDetail;
        #endregion

        #region Private / Protected
        #endregion

        #region Constructors
        /// <summary>
        /// Constructs a new instance of the <see cref="DataGridSelectionChangedEventArgs" /> class.
        /// </summary>
        public DataGridSelectionChangedEventArgs(PersonalDetail pd ) {
            selectedPersonalDetail = pd;
        }
        #endregion
    }
    
}
