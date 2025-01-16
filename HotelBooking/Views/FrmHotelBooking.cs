using HotelBooking.Repository.Entities;
using HotelBooking.Repository.Repos;

namespace HotelTester.Views
{
    public partial class FrmHotelBooking : Form
    {
        private readonly RoomRepo _roomRepo;
        private readonly CustomerRepo _customerRepo;
        private readonly BookingRepo _bookingRepo;
        private Booking? _currentBooking;
        private Room _currentRoom;
        private bool _newBooking = true;
        private bool _isNewRoomChosen = false;
        private DateTime _orgStartDate;
        private DateTime _orgEndDate;
        private bool _ignoreDateChangeEvent = false;

        public FrmHotelBooking()
        {
            InitializeComponent();

            _roomRepo = new RoomRepo();
            _customerRepo = new CustomerRepo();
            _bookingRepo = new BookingRepo();
            _currentBooking = new Booking();
            _currentRoom = new Room();
            _bookingRepo.CheckAllBookings();
            DisplayAllBookings();
            DisplayAllCustomers();
            ResetButtonsBooking();
            ResetButtonsCustomer();
        }

        private void btnCreateCustomer_Click(object sender, EventArgs e)
        {
            ClearBookingFields();
            ResetButtonsBooking();
            ResetButtonsCustomer();

            if (AllCustomerfieldsHasValues())
            {
                try
                {
                    if (_customerRepo.GetCustomerId(txtEmail.Text) == 0)
                    {
                        Customer customer = new();
                        customer.CustomerName = txtCustomerName.Text;
                        customer.Email = txtEmail.Text;
                        customer.Phone = txtPhone.Text;
                        _customerRepo.InsertCustomer(customer);
                        ClearCustomerFields();
                        DisplayAllCustomers();
                        ResetButtonsBooking();
                        ResetButtonsCustomer();
                    }
                    else { MessageBox.Show("Angiven e-postadress finns redan registrerad"); }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else { MessageBox.Show("Alla fält måste vara ifyllda!"); }
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            ClearBookingFields();
            ResetButtonsBooking();
            ResetButtonsCustomer();

            try
            {
                Customer customer = new();
                customer.CustomerId = GetCustomerID();
                customer.CustomerName = txtCustomerName.Text;
                customer.Email = txtEmail.Text;
                customer.Phone = txtPhone.Text;

                if (AllCustomerfieldsHasValues())
                {
                    _customerRepo.UpdateCustomer(customer);
                    MessageBox.Show("Kunden är uppdaterad");
                    ClearCustomerFields();
                    DisplayAllCustomers();
                    ResetButtonsCustomer();
                    ResetButtonsBooking();
                }
                else { MessageBox.Show("Alla fält måste vara ifyllda!"); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            ClearBookingFields();
            ResetButtonsBooking();
            ResetButtonsCustomer();

            var confirmResult = MessageBox.Show("Är du säker på att du vill ta bort kunden?",
                                                "Bekräfta borttagning", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    int customerId = _customerRepo.GetCustomerId(txtEmail.Text);
                    if (customerId == 0)
                        MessageBox.Show("Kunden kunde inte hittas.");
                    else if (_customerRepo.hasBookings(customerId))
                        MessageBox.Show("Kunden har bokningar och kan inte tas bort!");
                    else
                    {
                        _customerRepo.DeleteCustomer(customerId);
                        MessageBox.Show("Kunden har tagits bort.");
                        ClearCustomerFields();
                        DisplayAllCustomers();
                        ResetButtonsBooking();
                        ResetButtonsCustomer();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void btnChooseCustomer_Click(object sender, EventArgs e)
        {
            ClearBookingFields();
            ResetButtonsBooking();
            ResetButtonsCustomer();

            try
            {
                Customer customer = _customerRepo.GetCustomerById(GetCustomerID());
                txtCustomerName.Text = customer.CustomerName;
                txtEmail.Text = customer.Email;
                txtPhone.Text = customer.Phone;

                btnUpdateCustomer.Visible = true;
                btnDeleteCustomer.Visible = true;
                btnCreateCustomer.Visible = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnNewBooking_Click(object sender, EventArgs e)
        {
            ClearBookingFields();
            ClearCustomerFields();
            ResetButtonsBooking();
            ResetButtonsCustomer();
            _bookingRepo.CheckAllBookings();

            _newBooking = true;
            btnSearchRooms.Enabled = true;
            cmbCustomers.Visible = true;
            txtCustomer.Visible = false;
            btnCreateBooking.Enabled = true;
            btnCreateCustomer.Visible = true;
            btnCreateCustomer.Enabled = true;
        }

        private void btnSearchRooms_Click(object sender, EventArgs e)
        {
            try
            {
                _bookingRepo.CheckAllBookings();
                btnChooseRoom.Enabled = true;
                DateTime startDate = dtpStartDate.Value.Date;
                DateTime endDate = dtpEndDate.Value.Date;

                if (endDate <= startDate)
                    MessageBox.Show("Slutdatum måste vara senare än startdatum.");
                else
                {
                    int numbOfGuests = (int)nudNumberOfGuests.Value;
                    var availableRooms = _roomRepo.SearchAvailableRooms(startDate, endDate, numbOfGuests);
                    lstSearchResult.DataSource = availableRooms;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void cmbCustomers_DropDown(object sender, EventArgs e)
        {
            cmbCustomers.DataSource = _customerRepo.GetAllCustomers();
            cmbCustomers.DisplayMember = "CustomerName";
            cmbCustomers.ValueMember = "CustomerId";
        }

        private void btnChooseRoom_Click(object sender, EventArgs e)
        {
            try
            {
                _isNewRoomChosen = true;

                var selectedRoom = lstSearchResult.SelectedItem as Room;
                _currentRoom = selectedRoom;
                txtRoomNumber.Text = selectedRoom.RoomId.ToString();
                txtRoomType.Text = selectedRoom.RoomName;
                decimal pricePerNight = selectedRoom.RoomSize.PricePerNight;
                txtAmount.Text = _bookingRepo.GetBookingAmount(pricePerNight, dtpStartDate.Value.Date,
                                                                dtpEndDate.Value.Date).ToString();
                if (_newBooking)
                {
                    txtCustomer.Visible = false;
                    cmbCustomers.Visible = true;
                    cmbCustomers.Enabled = true;
                    btnCreateBooking.Enabled = true;
                    txtExtraBed.Text = "0";
                    lblDisplayBookingDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
                }
                else
                {
                    cmbCustomers.Visible = false;
                    txtCustomer.Visible = true;

                    if (_currentRoom.RoomName != "Enkelrum")
                    {
                        if (_currentRoom.RoomSize.RoomSizeName != "Medium")
                            txtExtraBed.Text = _currentBooking.NumbOfExtraBeds.ToString();
                        else
                            txtExtraBed.Text = "0";
                    }
                    else
                        txtExtraBed.Text = "0";
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnChooseBooking_Click(object sender, EventArgs e)
        {
            ResetButtonsCustomer();
            ResetButtonsBooking();
            ClearCustomerFields();
            DisplayBooking(lstDisplayBookings.SelectedItem as Booking);
        }

        private void btnCreateBooking_Click(object sender, EventArgs e)
        {
            ResetButtonsCustomer();
            if (AllBookingfieldsHasValues() && cmbCustomers.SelectedIndex != -1)
            {
                if (AnyIncorrectChanges())
                    MessageBox.Show("Du måste först söka och välja ett ledigt rum för de valda datumen!");
                else
                {
                    try
                    {
                        var selectedCustomer = cmbCustomers.SelectedItem as Customer;
                        var selectedRoom = _currentRoom;

                        Booking booking = new Booking
                        {
                            Customer = selectedCustomer,
                            BookingDate = DateTime.Today,
                            StartDate = dtpStartDate.Value,
                            EndDate = dtpEndDate.Value,
                            Amount = decimal.Parse(txtAmount.Text),
                            NumbOfGuests = (int)nudNumberOfGuests.Value,
                            Room = selectedRoom,
                            PaymentDueDate = DateTime.Today.AddDays(10),
                            IsPaid = false
                        };
                        _bookingRepo.InsertBooking(booking, selectedCustomer, selectedRoom);
                        MessageBox.Show($"Ny bokning med bokningsnummer: {booking.BookingId}.");
                        DisplayAllBookings();
                        ClearBookingFields();
                        ClearCustomerFields();
                        ResetButtonsCustomer();
                        ResetButtonsBooking();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            }
            else { MessageBox.Show("Alla fält måste vara ifylda!"); }
        }

        private void btnUpdateBooking_Click(object sender, EventArgs e)
        {
            if (AllBookingfieldsHasValues() && !string.IsNullOrWhiteSpace(txtCustomer.Text))
            {
                if (AnyIncorrectChanges())
                    MessageBox.Show("Du måste först söka och välja ett ledigt rum för de valda datumen!");
                else
                {
                    try
                    {
                        var selectedBooking = lstDisplayBookings.SelectedItem as Booking;
                        var newRoom = _currentRoom;
                        var oldRoom = selectedBooking.Room;

                        if (newRoom.RoomId != oldRoom.RoomId)
                        {
                            int newMaxExtraBeds = newRoom.RoomSize.MaxExtraBeds;
                            int oldRoomNumbOfBeds = selectedBooking.NumbOfExtraBeds;
                            while (oldRoomNumbOfBeds > newMaxExtraBeds)
                            {
                                _bookingRepo.UpdateExtraBedInBooking(selectedBooking, -1);
                                oldRoomNumbOfBeds--;
                            }
                            selectedBooking.Room = newRoom;
                        }

                        Booking updatedBooking = new Booking
                        {
                            BookingId = selectedBooking.BookingId,
                            Customer = selectedBooking.Customer,
                            Room = selectedBooking.Room,
                            StartDate = dtpStartDate.Value,
                            EndDate = dtpEndDate.Value,
                            NumbOfGuests = (int)nudNumberOfGuests.Value,
                            Amount = decimal.Parse(txtAmount.Text)
                        };

                        _bookingRepo.UpdateBooking(updatedBooking);
                        MessageBox.Show("Bokningen är uppdaterad");
                        DisplayAllBookings();
                        ClearBookingFields();
                        ClearCustomerFields();
                        ResetButtonsCustomer();
                        ResetButtonsBooking();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            }
            else { MessageBox.Show("Alla fält måste vara ifyllda!"); }
        }

        private void btnDeleteBooking_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Är du säker på att du vill ta bort bokningen?",
                                                "Bekräfta avbokning", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    _bookingRepo.DeleteBooking(_currentBooking.BookingId);
                    MessageBox.Show("Bokningen är avbokad och borttagen");
                    DisplayAllBookings();
                    ClearBookingFields();
                    ClearCustomerFields();
                    ResetButtonsCustomer();
                    ResetButtonsBooking();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (_ignoreDateChangeEvent) return;
            else if (dtpStartDate.Value != _orgStartDate || dtpEndDate.Value != _orgStartDate)
                _isNewRoomChosen = false;
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            if (_ignoreDateChangeEvent) return;
            else if (dtpStartDate.Value != _orgStartDate || dtpEndDate.Value != _orgStartDate)
                _isNewRoomChosen = false;
        }

        private void btnAddExtraBed_Click(object sender, EventArgs e)
        {
            if (_currentBooking == null)
                return;
            else
            {
                int maxExtraBeds = _currentBooking.Room.RoomSize.MaxExtraBeds;
                if (_currentBooking.NumbOfExtraBeds < maxExtraBeds && int.Parse(txtExtraBed.Text) < maxExtraBeds)
                {
                    _currentBooking.NumbOfExtraBeds++;
                    _bookingRepo.UpdateExtraBedInBooking(_currentBooking, 1);
                    txtExtraBed.Text = _currentBooking.NumbOfExtraBeds.ToString();
                }
                else { MessageBox.Show("Max antal extra sängar är uppnådd för denna bokning."); }
            }
        }

        private void btnDeleteExtraBed_Click(object sender, EventArgs e)
        {
            if (_currentBooking == null)
                return;
            else
            {
                if (_currentBooking.NumbOfExtraBeds > 0)
                {
                    _currentBooking.NumbOfExtraBeds--;
                    _bookingRepo.UpdateExtraBedInBooking(_currentBooking, -1);
                    txtExtraBed.Text = _currentBooking.NumbOfExtraBeds.ToString();
                }
                else { MessageBox.Show("Det finns ingen extra säng att ta bort."); }
            }
        }

        private void btnPayInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                var confirmResult = MessageBox.Show("Är du säker på att du vill betala?",
                                                "Bekräfta betalning", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    if (_bookingRepo.RegisterPayment(_currentBooking))
                    {
                        DisplayAllBookings();
                        ClearBookingFields();
                        ClearCustomerFields();
                        ResetButtonsCustomer();
                        ResetButtonsBooking();
                    }
                    else { MessageBox.Show("Fakturan kunde inte betalas"); }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private bool AnyIncorrectChanges()
        {
            DateTime dtpStart = dtpStartDate.Value;
            DateTime dtpEnd = dtpEndDate.Value;
            bool changes = false;

            if (dtpStart == _orgStartDate && dtpEnd == _orgEndDate)
                changes = false;
            else if (dtpStart != _orgStartDate || dtpEnd != _orgEndDate)
            {
                if (!_isNewRoomChosen)
                    changes = true;
                else
                    changes = false;
            }
            return changes;
        }

        private void DisplayAllCustomers()
        {
            try
            {
                var customers = _customerRepo.GetAllCustomers();
                lstDisplayCustomers.DisplayMember = "CustomerName";
                lstDisplayCustomers.ValueMember = "CustomerId";
                lstDisplayCustomers.DataSource = customers;
                btnChooseCustomer.Enabled = customers.Count > 0;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DisplayAllBookings()
        {
            try
            {
                var bookings = _bookingRepo.GetAllBookings();
                lstDisplayBookings.DataSource = bookings;
                btnChooseBooking.Enabled = bookings.Count > 0;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private bool AllBookingfieldsHasValues()
        {
            return int.TryParse(txtRoomNumber.Text, out _) &&
                   !string.IsNullOrWhiteSpace(txtRoomType.Text) &&
                   !string.IsNullOrWhiteSpace(txtAmount.Text) &&
                   !string.IsNullOrWhiteSpace(lblDisplayBookingDate.Text);
        }

        private bool AllCustomerfieldsHasValues()
        {
            if (!string.IsNullOrWhiteSpace(txtCustomerName.Text) && !string.IsNullOrWhiteSpace(txtEmail.Text)
                && txtEmail.Text.Contains('@') && !string.IsNullOrWhiteSpace(txtPhone.Text))
                return true;
            else
                return false;
        }

        private int GetCustomerID()
        {
            return (int)lstDisplayCustomers.SelectedValue;
        }

        private void DisplayBooking(Booking selectedBooking)
        {
            _newBooking = false;
            _ignoreDateChangeEvent = true;
            txtCustomer.Visible = true;
            cmbCustomers.Visible = false;
            btnDeleteBooking.Enabled = true;
            _ignoreDateChangeEvent = false;

            _currentBooking = selectedBooking;
            _currentRoom = selectedBooking.Room;
            _orgStartDate = selectedBooking.StartDate;
            _orgEndDate = selectedBooking.EndDate;
            txtCustomer.Text = selectedBooking.Customer.CustomerName;
            dtpStartDate.Value = selectedBooking.StartDate;
            dtpEndDate.Value = selectedBooking.EndDate;
            txtRoomNumber.Text = selectedBooking.Room.RoomId.ToString();
            txtRoomType.Text = selectedBooking.Room.RoomName;
            nudNumberOfGuests.Value = selectedBooking.NumbOfGuests;
            txtAmount.Text = selectedBooking.Amount.ToString();
            lblDisplayBookingDate.Text = selectedBooking.BookingDate.ToString("yyyy-MM-dd");

            if (!selectedBooking.IsPaid)
            {
                if (selectedBooking.Room.RoomSize.RoomSizeName != "Small")
                {
                    btnAddExtraBed.Enabled = true;
                    btnDeleteExtraBed.Enabled = true;
                    txtExtraBed.Text = selectedBooking.NumbOfExtraBeds.ToString();
                }
                btnSearchRooms.Enabled = true;
                btnUpdateBooking.Enabled = true;
                btnPayInvoice.Visible = true;
                btnPayInvoice.Enabled = true;
                lblDisplayInvoiceAmount.Text = selectedBooking.Amount.ToString();
                lblDueDays.Text = selectedBooking.PaymentDueDate.ToString("yyyy-MM-dd");
            }
            else
            {
                txtExtraBed.Text = selectedBooking.NumbOfExtraBeds.ToString();
                lblDisplayInvoiceAmount.Text = "0";
                lblDueDays.Text = "Betald";
            }
        }

        private void ClearCustomerFields()
        {
            txtCustomerName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
        }

        private void ResetButtonsBooking()
        {
            btnChooseBooking.Enabled = lstDisplayBookings.Items.Count > 0;
            btnSearchRooms.Enabled = false;
            btnChooseRoom.Enabled = false;
            btnAddExtraBed.Enabled = false;
            btnDeleteExtraBed.Enabled = false;
            btnCreateBooking.Enabled = false;
            btnUpdateBooking.Enabled = false;
            btnDeleteBooking.Enabled = false;
            btnPayInvoice.Visible = false;
        }

        private void ResetButtonsCustomer()
        {
            btnChooseCustomer.Enabled = lstDisplayCustomers.Items.Count > 0;
            btnCreateCustomer.Enabled = true;
            btnCreateCustomer.Visible = true;
            btnUpdateCustomer.Visible = false;
            btnDeleteCustomer.Visible = false;
        }

        private void ClearBookingFields()
        {
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today.AddDays(1);
            nudNumberOfGuests.Value = 1;
            txtCustomer.Clear();
            cmbCustomers.SelectedIndex = -1;
            cmbCustomers.Visible = false;
            txtCustomer.Visible = true;
            txtRoomNumber.Clear();
            txtRoomType.Clear();
            txtAmount.Clear();
            txtExtraBed.Text = "";
            lblDisplayBookingDate.Text = null;
            lblDueDays.Text = null;
            lblDisplayInvoiceAmount.Text = null;
            lstSearchResult.DataSource = null;
            _currentBooking = null;
        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
