using Marian_Bianca_Lab5;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.ComponentModel;

namespace Marian_Bianca_Lab5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    //lab1part19
    enum ActionState
    {
        New,
        Edit, 
        Delete,
        Nothing
    }
    public partial class MainWindow : Window
    {
        //lab1part20
        ActionState action = ActionState.Nothing;
        PhoneNumbersDataSet phoneNumbersDataSet = new PhoneNumbersDataSet();
        PhoneNumbersDataSetTableAdapters.PhoneNumbersTableAdapter tblPhoneNumbersAdapter = new PhoneNumbersDataSetTableAdapters.PhoneNumbersTableAdapter();
        Binding txtPhoneNumberBinding = new Binding();
        Binding txtSubscriberBinding = new Binding();
        Binding txtContractValueBinding = new Binding();
        Binding txtContractDateBinding = new Binding();
        public MainWindow()
        {
            InitializeComponent();
            //lab1part21
            grdMain.DataContext = phoneNumbersDataSet.PhoneNumbers;
            txtPhoneNumberBinding.Path = new PropertyPath("Phonenum");
            txtSubscriberBinding.Path = new PropertyPath("Subscriber");
            txtContractValueBinding.Path = new PropertyPath("ContractValue");
            txtContractDateBinding.Path = new PropertyPath("ContractDate");
            txtPhoneNumber.SetBinding(TextBox.TextProperty, txtPhoneNumberBinding);
            txtSubscriber.SetBinding(TextBox.TextProperty, txtSubscriberBinding);
            txtContractValue.SetBinding(TextBox.TextProperty, txtContractValueBinding);
            txtContractDate.SetBinding(TextBox.TextProperty, txtContractDateBinding);
        }
        //lab1part22
         private void lstPhonesLoad()
        {
            tblPhoneNumbersAdapter.Fill(phoneNumbersDataSet.PhoneNumbers);
        }
        //lab1part23
        private void grdMain_Loaded(object sender, RoutedEventArgs e)
        {
            lstPhonesLoad();
        }
        //lab1part24
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
        if(MessageBox.Show("Close Application?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
        //lab1part25
        private void frmMain_Loaded(object sender, RoutedEventArgs e)
        {
            PhoneNumbersDataSet phoneNumbersDataSet = ((PhoneNumbersDataSet)(this.FindResource("phoneNumbersDataSet")));
            System.Windows.Data.CollectionViewSource phoneNumbersViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("phoneNumbersViewSource")));
            phoneNumbersViewSource.View.MoveCurrentToFirst();
        }
        //lab1part26
        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.New;
            btnNew.IsEnabled = false;
            btnEdit.IsEnabled = false;
            btnDelete.IsEnabled = false;

            btnSave.IsEnabled = true;
            btnCancel.IsEnabled = true;
            lstPhones.IsEnabled = false;
            btnPrevious.IsEnabled = false;
            txtPhoneNumber.IsEnabled = true;
            txtSubscriber.IsEnabled = true;
            txtContractValue.IsEnabled = true;
            txtContractDate.IsEnabled = true;

            BindingOperations.ClearBinding(txtPhoneNumber, TextBox.TextProperty);
            BindingOperations.ClearBinding(txtSubscriber, TextBox.TextProperty);
            BindingOperations.ClearBinding(txtContractValue, TextBox.TextProperty);
            BindingOperations.ClearBinding(txtContractDate, TextBox.TextProperty);
            txtPhoneNumber.Text = "";
            txtSubscriber.Text = "";
            txtContractValue.Text = "";
            txtContractDate.Text = "";
            Keyboard.Focus(txtPhoneNumber);
        }
        //lab1part27
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Edit;
            string tempPhonenum = txtPhoneNumber.Text.ToString();
            string tempSubscriber = txtSubscriber.Text.ToString();
            string tempContractValue = txtContractValue.Text.ToString();
            string tempContractDate = txtContractDate.Text.ToString();

            btnNew.IsEnabled = false;
            btnEdit.IsEnabled = false;
            btnDelete.IsEnabled = false;

            btnSave.IsEnabled = true;
            btnCancel.IsEnabled = true;
            lstPhones.IsEnabled = false;
            btnPrevious.IsEnabled = false;
            btnNext.IsEnabled = false;
            txtPhoneNumber.IsEnabled = true;
            txtSubscriber.IsEnabled = true;
            txtContractValue.IsEnabled = true;
            txtContractDate.IsEnabled = true;

            BindingOperations.ClearBinding(txtPhoneNumber, TextBox.TextProperty);
            BindingOperations.ClearBinding(txtSubscriber, TextBox.TextProperty);
            BindingOperations.ClearBinding(txtContractValue, TextBox.TextProperty);
            BindingOperations.ClearBinding(txtContractDate, TextBox.TextProperty);
            txtPhoneNumber.Text = tempPhonenum;
            txtSubscriber.Text = tempSubscriber;
            txtContractValue.Text = tempContractValue;
            txtContractDate.Text = tempContractDate;
            Keyboard.Focus(txtPhoneNumber);
        }
        //lab1part28
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Delete;
            string tempPhonenum = txtPhoneNumber.Text.ToString();
            string tempSubscriber = txtSubscriber.Text.ToString();
            string tempContractValue = txtContractValue.Text.ToString();
            string tempContractDate = txtContractDate.Text.ToString();

            btnNew.IsEnabled = false;
            btnEdit.IsEnabled = false;
            btnDelete.IsEnabled = false;

            btnSave.IsEnabled = true;
            btnCancel.IsEnabled = true;
            lstPhones.IsEnabled = false;
            btnPrevious.IsEnabled = false;
            btnNext.IsEnabled = false;

            BindingOperations.ClearBinding(txtPhoneNumber, TextBox.TextProperty);
            BindingOperations.ClearBinding(txtSubscriber, TextBox.TextProperty);
            BindingOperations.ClearBinding(txtContractValue, TextBox.TextProperty);
            BindingOperations.ClearBinding(txtContractDate, TextBox.TextProperty);
            txtPhoneNumber.Text = tempPhonenum;
            txtSubscriber.Text = tempSubscriber;
            txtContractValue.Text = tempContractValue;
            txtContractDate.Text = tempContractDate;
        }
        //lab1part29
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Nothing;
            btnNew.IsEnabled = true;
            btnEdit.IsEnabled = true;

            btnDelete.IsEnabled = true;
            btnSave.IsEnabled = false;
            btnCancel.IsEnabled = false;

            lstPhones.IsEnabled = true;
            btnPrevious.IsEnabled = true;
            btnNext.IsEnabled = true;
            txtPhoneNumber.IsEnabled = false;
            txtSubscriber.IsEnabled = false;
            txtContractValue.IsEnabled = false;
            txtContractDate.IsEnabled = false;

            txtPhoneNumber.SetBinding(TextBox.TextProperty, txtPhoneNumberBinding);
            txtSubscriber.SetBinding(TextBox.TextProperty, txtSubscriberBinding);
            txtContractValue.SetBinding(TextBox.TextProperty, txtContractValueBinding);
            txtContractDate.SetBinding(TextBox.TextProperty, txtContractDateBinding);
        }
        //lab1part30
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
         if(action == ActionState.New)
          {
                try
                {
                    DataRow newRow = phoneNumbersDataSet.PhoneNumbers.NewRow();
                    newRow.BeginEdit();
                    newRow["Phonenum"] = txtPhoneNumber.Text.Trim();
                    newRow["Subscriber"] = txtSubscriber.Text.Trim();
                    newRow["ContractValue"] = txtContractValue.Text.Trim();
                    newRow["ContractDate"] = txtContractDate.Text.Trim();
                    newRow.EndEdit();
                    phoneNumbersDataSet.PhoneNumbers.Rows.Add(newRow);
                    tblPhoneNumbersAdapter.Update(phoneNumbersDataSet.PhoneNumbers);
                    phoneNumbersDataSet.AcceptChanges();
                }catch (DataException ex)
                {
                    phoneNumbersDataSet.RejectChanges();
                    MessageBox.Show(ex.Message);
                }
                btnNew.IsEnabled = true;
                btnEdit.IsEnabled = true;
                btnSave.IsEnabled = false;
                btnCancel.IsEnabled = false;
                lstPhones.IsEnabled = true;
                btnPrevious.IsEnabled = true;
                btnNext.IsEnabled = true;
                txtPhoneNumber.IsEnabled = false;
                txtSubscriber.IsEnabled = false;
                txtContractValue.IsEnabled = false;
                txtContractDate.IsEnabled = false;
          }
            else
            if (action == ActionState.Edit)
            {
                try
                {
                    DataRow editRow = phoneNumbersDataSet.PhoneNumbers.Rows[lstPhones.SelectedIndex];
                    editRow.BeginEdit();
                    editRow["Phonenum"] = txtPhoneNumber.Text.Trim();
                    editRow["Subscriber"] = txtSubscriber.Text.Trim();
                    editRow["ContractValue"] = txtContractValue.Text.Trim();
                    editRow["ContractDate"] = txtContractDate.Text.Trim();
                    editRow.EndEdit();
                    tblPhoneNumbersAdapter.Update(phoneNumbersDataSet.PhoneNumbers);
                    phoneNumbersDataSet.AcceptChanges();
                }

                catch (DataException ex)
                {
                    phoneNumbersDataSet.RejectChanges();
                    MessageBox.Show(ex.Message);
                }
                btnNew.IsEnabled = true;
                btnEdit.IsEnabled = true;
                btnDelete.IsEnabled = true;

                btnSave.IsEnabled = false;
                btnCancel.IsEnabled = false;
                lstPhones.IsEnabled = true;
                btnPrevious.IsEnabled = true;
                btnNext.IsEnabled = true;
                txtPhoneNumber.IsEnabled = false;
                txtSubscriber.IsEnabled = false;
                txtContractValue.IsEnabled = false;
                txtContractDate.IsEnabled = false;

                txtPhoneNumber.SetBinding(TextBox.TextProperty, txtPhoneNumberBinding);
                txtSubscriber.SetBinding(TextBox.TextProperty, txtSubscriberBinding);
                txtContractValue.SetBinding(TextBox.TextProperty, txtContractValueBinding);
                txtContractDate.SetBinding(TextBox.TextProperty, txtContractDateBinding);
            }
            else
            if (action == ActionState.Delete)
            {
                try
                {
                    DataRow deleterow = phoneNumbersDataSet.PhoneNumbers.Rows[lstPhones.SelectedIndex];

                    deleterow.Delete();

                    tblPhoneNumbersAdapter.Update(phoneNumbersDataSet.PhoneNumbers);
                    phoneNumbersDataSet.AcceptChanges();
                }
                catch (DataException ex)
                {
                    phoneNumbersDataSet.RejectChanges(); MessageBox.Show(ex.Message);
                    MessageBox.Show(ex.Message);
                }
                btnNew.IsEnabled = true;
                btnEdit.IsEnabled = true;
                btnDelete.IsEnabled = true;

                btnSave.IsEnabled = false;
                btnCancel.IsEnabled = false;
                lstPhones.IsEnabled = true;
                btnPrevious.IsEnabled = true;
                btnNext.IsEnabled = true;
                txtPhoneNumber.IsEnabled = false;
                txtSubscriber.IsEnabled = false;
                txtContractValue.IsEnabled = false;
                txtContractDate.IsEnabled = false;

                txtPhoneNumber.SetBinding(TextBox.TextProperty, txtPhoneNumberBinding);
                txtSubscriber.SetBinding(TextBox.TextProperty, txtSubscriberBinding);
                txtContractValue.SetBinding(TextBox.TextProperty, txtContractValueBinding);
                txtContractDate.SetBinding(TextBox.TextProperty, txtContractDateBinding);
            }
        }
        //lab1part31
        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView navigationView = CollectionViewSource.GetDefaultView(phoneNumbersDataSet.PhoneNumbers);
            navigationView.MoveCurrentToPrevious();
        }
        //lab1part32
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView navigationView =CollectionViewSource.GetDefaultView(phoneNumbersDataSet.PhoneNumbers);
            navigationView.MoveCurrentToNext();
        }
    }
}
