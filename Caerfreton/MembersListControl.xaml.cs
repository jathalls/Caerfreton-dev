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
    /// Interaction logic for MembersListControl.xaml
    /// </summary>
    public partial class MembersListControl : UserControl {

        public DatabaseAccess databaseAccess = new DatabaseAccess( );
        public MembersListControl( ) {
            InitializeComponent( );
            Loaded += MembersListControl_Loaded;
        }

        void MembersListControl_Loaded( object sender, RoutedEventArgs e ) {
            memberListViewControl.SelectionChanged += memberListViewControl_SelectionChanged;
        }

        void memberListViewControl_SelectionChanged( object sender, EventArgs e ) {
            if ( (e as DataGridSelectionChangedEventArgs).selectedPersonalDetail != null ) {
                memberDetailViewControl.MemberDetailDep = (e as DataGridSelectionChangedEventArgs).selectedPersonalDetail;
            }
        }

        private void ImportButton_Click( object sender, RoutedEventArgs e ) {
            
            List<PersonalDetail> memberList=this.databaseAccess.ImportFromCSVFile( @"C:\DB\Care4Care.csv" );
            memberListViewControl.MemberListDep = memberList;
            if ( memberList.Count( ) > 0 ) {
                memberDetailViewControl.MemberDetailDep = memberList[0];
            }
            
        }
    }
}
