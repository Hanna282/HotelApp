namespace HotelTester.Views
{
    partial class FrmHotelBooking
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblHotel = new Label();
            lblBooking = new Label();
            nudNumberOfGuests = new NumericUpDown();
            btnSearchRooms = new Button();
            lstSearchResult = new ListBox();
            lblRoomID = new Label();
            txtRoomNumber = new TextBox();
            lblAvailableCustomers = new Label();
            cmbCustomers = new ComboBox();
            lblBookings = new Label();
            txtRoomType = new TextBox();
            lblRoomType = new Label();
            lblExtraBeds = new Label();
            lblBookingDate = new Label();
            lblDisplayBookingDate = new Label();
            lblAmount = new Label();
            txtAmount = new TextBox();
            btnCreateBooking = new Button();
            lblInvoiceAmount = new Label();
            lblDisplayInvoiceAmount = new Label();
            btnPayInvoice = new Button();
            btnDeleteBooking = new Button();
            btnUpdateBooking = new Button();
            lblManageCustomer = new Label();
            lblCustomerName = new Label();
            txtCustomerName = new TextBox();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtPhone = new TextBox();
            lblPhone = new Label();
            btnCreateCustomer = new Button();
            btnDeleteCustomer = new Button();
            btnUpdateCustomer = new Button();
            lstDisplayCustomers = new ListBox();
            btnChooseCustomer = new Button();
            btnCLose = new Button();
            btnChooseRoom = new Button();
            txtCustomer = new TextBox();
            lblDueDays = new Label();
            lblDue = new Label();
            btnChooseBooking = new Button();
            dtpStartDate = new DateTimePicker();
            lblDateCheckIn = new Label();
            lblDateCheckOut = new Label();
            dtpEndDate = new DateTimePicker();
            label1 = new Label();
            btnNewBooking = new Button();
            btnAddExtraBed = new Button();
            txtExtraBed = new TextBox();
            btnDeleteExtraBed = new Button();
            lstDisplayBookings = new ListBox();
            ((System.ComponentModel.ISupportInitialize)nudNumberOfGuests).BeginInit();
            SuspendLayout();
            // 
            // lblHotel
            // 
            lblHotel.AutoSize = true;
            lblHotel.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHotel.Location = new Point(22, 22);
            lblHotel.Name = "lblHotel";
            lblHotel.Size = new Size(138, 54);
            lblHotel.TabIndex = 0;
            lblHotel.Text = "Hotell";
            // 
            // lblBooking
            // 
            lblBooking.AutoSize = true;
            lblBooking.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBooking.Location = new Point(28, 464);
            lblBooking.Name = "lblBooking";
            lblBooking.Size = new Size(96, 30);
            lblBooking.TabIndex = 1;
            lblBooking.Text = "Bokning";
            // 
            // nudNumberOfGuests
            // 
            nudNumberOfGuests.Location = new Point(31, 709);
            nudNumberOfGuests.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            nudNumberOfGuests.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudNumberOfGuests.Name = "nudNumberOfGuests";
            nudNumberOfGuests.Size = new Size(107, 31);
            nudNumberOfGuests.TabIndex = 5;
            nudNumberOfGuests.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnSearchRooms
            // 
            btnSearchRooms.Location = new Point(198, 693);
            btnSearchRooms.Name = "btnSearchRooms";
            btnSearchRooms.Size = new Size(122, 47);
            btnSearchRooms.TabIndex = 6;
            btnSearchRooms.Text = "Sök rum";
            btnSearchRooms.UseVisualStyleBackColor = true;
            btnSearchRooms.Click += btnSearchRooms_Click;
            // 
            // lstSearchResult
            // 
            lstSearchResult.FormattingEnabled = true;
            lstSearchResult.ItemHeight = 25;
            lstSearchResult.Location = new Point(342, 536);
            lstSearchResult.Name = "lstSearchResult";
            lstSearchResult.Size = new Size(289, 229);
            lstSearchResult.TabIndex = 7;
            // 
            // lblRoomID
            // 
            lblRoomID.AutoSize = true;
            lblRoomID.Location = new Point(25, 850);
            lblRoomID.Name = "lblRoomID";
            lblRoomID.Size = new Size(124, 25);
            lblRoomID.TabIndex = 12;
            lblRoomID.Text = "Rumsnummer";
            // 
            // txtRoomNumber
            // 
            txtRoomNumber.BackColor = Color.Ivory;
            txtRoomNumber.Location = new Point(25, 878);
            txtRoomNumber.Name = "txtRoomNumber";
            txtRoomNumber.ReadOnly = true;
            txtRoomNumber.Size = new Size(124, 31);
            txtRoomNumber.TabIndex = 13;
            txtRoomNumber.TabStop = false;
            // 
            // lblAvailableCustomers
            // 
            lblAvailableCustomers.AutoSize = true;
            lblAvailableCustomers.Location = new Point(28, 770);
            lblAvailableCustomers.Name = "lblAvailableCustomers";
            lblAvailableCustomers.Size = new Size(53, 25);
            lblAvailableCustomers.TabIndex = 14;
            lblAvailableCustomers.Text = "Kund";
            // 
            // cmbCustomers
            // 
            cmbCustomers.BackColor = Color.Ivory;
            cmbCustomers.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCustomers.FormattingEnabled = true;
            cmbCustomers.Location = new Point(28, 798);
            cmbCustomers.Name = "cmbCustomers";
            cmbCustomers.Size = new Size(298, 33);
            cmbCustomers.TabIndex = 15;
            cmbCustomers.TabStop = false;
            cmbCustomers.DropDown += cmbCustomers_DropDown;
            // 
            // lblBookings
            // 
            lblBookings.AutoSize = true;
            lblBookings.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBookings.Location = new Point(28, 102);
            lblBookings.Name = "lblBookings";
            lblBookings.Size = new Size(115, 30);
            lblBookings.TabIndex = 18;
            lblBookings.Text = "Bokningar";
            // 
            // txtRoomType
            // 
            txtRoomType.BackColor = Color.Ivory;
            txtRoomType.Location = new Point(170, 878);
            txtRoomType.Name = "txtRoomType";
            txtRoomType.ReadOnly = true;
            txtRoomType.Size = new Size(153, 31);
            txtRoomType.TabIndex = 20;
            txtRoomType.TabStop = false;
            // 
            // lblRoomType
            // 
            lblRoomType.AutoSize = true;
            lblRoomType.Location = new Point(170, 850);
            lblRoomType.Name = "lblRoomType";
            lblRoomType.Size = new Size(83, 25);
            lblRoomType.TabIndex = 19;
            lblRoomType.Text = "Rumstyp";
            // 
            // lblExtraBeds
            // 
            lblExtraBeds.AutoSize = true;
            lblExtraBeds.Location = new Point(183, 926);
            lblExtraBeds.Name = "lblExtraBeds";
            lblExtraBeds.Size = new Size(93, 25);
            lblExtraBeds.TabIndex = 23;
            lblExtraBeds.Text = "Extra säng";
            // 
            // lblBookingDate
            // 
            lblBookingDate.AutoSize = true;
            lblBookingDate.Location = new Point(28, 1035);
            lblBookingDate.Name = "lblBookingDate";
            lblBookingDate.Size = new Size(141, 25);
            lblBookingDate.TabIndex = 25;
            lblBookingDate.Text = "Bokningsdatum:";
            // 
            // lblDisplayBookingDate
            // 
            lblDisplayBookingDate.AutoSize = true;
            lblDisplayBookingDate.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblDisplayBookingDate.Location = new Point(177, 1039);
            lblDisplayBookingDate.Name = "lblDisplayBookingDate";
            lblDisplayBookingDate.Size = new Size(0, 21);
            lblDisplayBookingDate.TabIndex = 26;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Location = new Point(28, 927);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(111, 25);
            lblAmount.TabIndex = 27;
            lblAmount.Text = "Belopp i SEK";
            // 
            // txtAmount
            // 
            txtAmount.BackColor = Color.Ivory;
            txtAmount.Location = new Point(28, 954);
            txtAmount.Name = "txtAmount";
            txtAmount.ReadOnly = true;
            txtAmount.Size = new Size(149, 31);
            txtAmount.TabIndex = 28;
            txtAmount.TabStop = false;
            // 
            // btnCreateBooking
            // 
            btnCreateBooking.Location = new Point(159, 1073);
            btnCreateBooking.Name = "btnCreateBooking";
            btnCreateBooking.Size = new Size(164, 40);
            btnCreateBooking.TabIndex = 30;
            btnCreateBooking.Text = "Skapa bokning";
            btnCreateBooking.UseVisualStyleBackColor = true;
            btnCreateBooking.Click += btnCreateBooking_Click;
            // 
            // lblInvoiceAmount
            // 
            lblInvoiceAmount.AutoSize = true;
            lblInvoiceAmount.Location = new Point(25, 1127);
            lblInvoiceAmount.Name = "lblInvoiceAmount";
            lblInvoiceAmount.Size = new Size(126, 25);
            lblInvoiceAmount.TabIndex = 31;
            lblInvoiceAmount.Text = "Fakturabelopp";
            // 
            // lblDisplayInvoiceAmount
            // 
            lblDisplayInvoiceAmount.AutoSize = true;
            lblDisplayInvoiceAmount.Location = new Point(167, 1127);
            lblDisplayInvoiceAmount.Name = "lblDisplayInvoiceAmount";
            lblDisplayInvoiceAmount.Size = new Size(0, 25);
            lblDisplayInvoiceAmount.TabIndex = 32;
            // 
            // btnPayInvoice
            // 
            btnPayInvoice.Location = new Point(233, 1196);
            btnPayInvoice.Name = "btnPayInvoice";
            btnPayInvoice.Size = new Size(87, 38);
            btnPayInvoice.TabIndex = 33;
            btnPayInvoice.Text = "Betala";
            btnPayInvoice.UseVisualStyleBackColor = true;
            btnPayInvoice.Click += btnPayInvoice_Click;
            // 
            // btnDeleteBooking
            // 
            btnDeleteBooking.Location = new Point(177, 1240);
            btnDeleteBooking.Name = "btnDeleteBooking";
            btnDeleteBooking.Size = new Size(149, 47);
            btnDeleteBooking.TabIndex = 36;
            btnDeleteBooking.Text = "Avboka";
            btnDeleteBooking.UseVisualStyleBackColor = true;
            btnDeleteBooking.Click += btnDeleteBooking_Click;
            // 
            // btnUpdateBooking
            // 
            btnUpdateBooking.Location = new Point(22, 1240);
            btnUpdateBooking.Name = "btnUpdateBooking";
            btnUpdateBooking.Size = new Size(140, 47);
            btnUpdateBooking.TabIndex = 39;
            btnUpdateBooking.Text = "Uppdatera";
            btnUpdateBooking.UseVisualStyleBackColor = true;
            btnUpdateBooking.Click += btnUpdateBooking_Click;
            // 
            // lblManageCustomer
            // 
            lblManageCustomer.AutoSize = true;
            lblManageCustomer.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblManageCustomer.Location = new Point(801, 464);
            lblManageCustomer.Name = "lblManageCustomer";
            lblManageCustomer.Size = new Size(85, 30);
            lblManageCustomer.TabIndex = 40;
            lblManageCustomer.Text = "Kunder";
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Location = new Point(801, 884);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(60, 25);
            lblCustomerName.TabIndex = 41;
            lblCustomerName.Text = "Namn";
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(801, 912);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(323, 31);
            txtCustomerName.TabIndex = 42;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(801, 998);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(323, 31);
            txtEmail.TabIndex = 44;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(801, 970);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(115, 25);
            lblEmail.TabIndex = 43;
            lblEmail.Text = "E-postadress";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(801, 1083);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(323, 31);
            txtPhone.TabIndex = 46;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(801, 1055);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(135, 25);
            lblPhone.TabIndex = 45;
            lblPhone.Text = "Telefonnummer";
            // 
            // btnCreateCustomer
            // 
            btnCreateCustomer.Location = new Point(971, 1131);
            btnCreateCustomer.Name = "btnCreateCustomer";
            btnCreateCustomer.Size = new Size(153, 42);
            btnCreateCustomer.TabIndex = 48;
            btnCreateCustomer.Text = "Skapa kund";
            btnCreateCustomer.UseVisualStyleBackColor = true;
            btnCreateCustomer.Click += btnCreateCustomer_Click;
            // 
            // btnDeleteCustomer
            // 
            btnDeleteCustomer.Location = new Point(971, 1147);
            btnDeleteCustomer.Name = "btnDeleteCustomer";
            btnDeleteCustomer.Size = new Size(153, 42);
            btnDeleteCustomer.TabIndex = 49;
            btnDeleteCustomer.Text = "Ta bort kund";
            btnDeleteCustomer.UseVisualStyleBackColor = true;
            btnDeleteCustomer.Click += btnDeleteCustomer_Click;
            // 
            // btnUpdateCustomer
            // 
            btnUpdateCustomer.Location = new Point(802, 1147);
            btnUpdateCustomer.Name = "btnUpdateCustomer";
            btnUpdateCustomer.Size = new Size(163, 42);
            btnUpdateCustomer.TabIndex = 50;
            btnUpdateCustomer.Text = "Uppdatera kund";
            btnUpdateCustomer.UseVisualStyleBackColor = true;
            btnUpdateCustomer.Click += btnUpdateCustomer_Click;
            // 
            // lstDisplayCustomers
            // 
            lstDisplayCustomers.FormattingEnabled = true;
            lstDisplayCustomers.ItemHeight = 25;
            lstDisplayCustomers.Location = new Point(801, 536);
            lstDisplayCustomers.Name = "lstDisplayCustomers";
            lstDisplayCustomers.Size = new Size(323, 254);
            lstDisplayCustomers.TabIndex = 51;
            // 
            // btnChooseCustomer
            // 
            btnChooseCustomer.Location = new Point(945, 796);
            btnChooseCustomer.Name = "btnChooseCustomer";
            btnChooseCustomer.Size = new Size(179, 48);
            btnChooseCustomer.TabIndex = 53;
            btnChooseCustomer.Text = "Hantera kund";
            btnChooseCustomer.UseVisualStyleBackColor = true;
            btnChooseCustomer.Click += btnChooseCustomer_Click;
            // 
            // btnCLose
            // 
            btnCLose.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCLose.Location = new Point(950, 1233);
            btnCLose.Name = "btnCLose";
            btnCLose.Size = new Size(176, 54);
            btnCLose.TabIndex = 54;
            btnCLose.Text = "Avsluta";
            btnCLose.UseVisualStyleBackColor = true;
            btnCLose.Click += btnCLose_Click;
            // 
            // btnChooseRoom
            // 
            btnChooseRoom.Location = new Point(518, 771);
            btnChooseRoom.Name = "btnChooseRoom";
            btnChooseRoom.Size = new Size(113, 46);
            btnChooseRoom.TabIndex = 56;
            btnChooseRoom.Text = "Välj rum";
            btnChooseRoom.UseVisualStyleBackColor = true;
            btnChooseRoom.Click += btnChooseRoom_Click;
            // 
            // txtCustomer
            // 
            txtCustomer.BackColor = Color.Ivory;
            txtCustomer.Location = new Point(25, 800);
            txtCustomer.Name = "txtCustomer";
            txtCustomer.ReadOnly = true;
            txtCustomer.Size = new Size(298, 31);
            txtCustomer.TabIndex = 58;
            txtCustomer.TabStop = false;
            // 
            // lblDueDays
            // 
            lblDueDays.AutoSize = true;
            lblDueDays.Location = new Point(167, 1162);
            lblDueDays.Name = "lblDueDays";
            lblDueDays.Size = new Size(0, 25);
            lblDueDays.TabIndex = 60;
            // 
            // lblDue
            // 
            lblDue.AutoSize = true;
            lblDue.Location = new Point(25, 1162);
            lblDue.Name = "lblDue";
            lblDue.Size = new Size(124, 25);
            lblDue.TabIndex = 59;
            lblDue.Text = "Förfallodatum";
            // 
            // btnChooseBooking
            // 
            btnChooseBooking.Location = new Point(932, 334);
            btnChooseBooking.Name = "btnChooseBooking";
            btnChooseBooking.Size = new Size(194, 50);
            btnChooseBooking.TabIndex = 62;
            btnChooseBooking.Text = "Välj bokning";
            btnChooseBooking.UseVisualStyleBackColor = true;
            btnChooseBooking.Click += btnChooseBooking_Click;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(31, 548);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(289, 31);
            dtpStartDate.TabIndex = 63;
            dtpStartDate.Value = new DateTime(2024, 11, 15, 0, 0, 0, 0);
            dtpStartDate.ValueChanged += dtpStartDate_ValueChanged;
            // 
            // lblDateCheckIn
            // 
            lblDateCheckIn.AutoSize = true;
            lblDateCheckIn.Location = new Point(31, 520);
            lblDateCheckIn.Name = "lblDateCheckIn";
            lblDateCheckIn.Size = new Size(105, 25);
            lblDateCheckIn.TabIndex = 64;
            lblDateCheckIn.Text = "Start datum";
            // 
            // lblDateCheckOut
            // 
            lblDateCheckOut.AutoSize = true;
            lblDateCheckOut.Location = new Point(31, 599);
            lblDateCheckOut.Name = "lblDateCheckOut";
            lblDateCheckOut.Size = new Size(99, 25);
            lblDateCheckOut.TabIndex = 66;
            lblDateCheckOut.Text = "Slut datum";
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new Point(31, 627);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(289, 31);
            dtpEndDate.TabIndex = 65;
            dtpEndDate.Value = new DateTime(2024, 11, 15, 0, 0, 0, 0);
            dtpEndDate.ValueChanged += dtpEndDate_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 681);
            label1.Name = "label1";
            label1.Size = new Size(128, 25);
            label1.TabIndex = 67;
            label1.Text = "Antal personer";
            // 
            // btnNewBooking
            // 
            btnNewBooking.BackColor = SystemColors.GradientActiveCaption;
            btnNewBooking.FlatStyle = FlatStyle.Popup;
            btnNewBooking.Location = new Point(28, 370);
            btnNewBooking.Name = "btnNewBooking";
            btnNewBooking.Size = new Size(289, 66);
            btnNewBooking.TabIndex = 69;
            btnNewBooking.Text = "Ny bokning";
            btnNewBooking.UseVisualStyleBackColor = false;
            btnNewBooking.Click += btnNewBooking_Click;
            // 
            // btnAddExtraBed
            // 
            btnAddExtraBed.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddExtraBed.Location = new Point(250, 989);
            btnAddExtraBed.Name = "btnAddExtraBed";
            btnAddExtraBed.Size = new Size(73, 37);
            btnAddExtraBed.TabIndex = 70;
            btnAddExtraBed.Text = "Lägg till";
            btnAddExtraBed.UseVisualStyleBackColor = true;
            btnAddExtraBed.Click += btnAddExtraBed_Click;
            // 
            // txtExtraBed
            // 
            txtExtraBed.BackColor = Color.Ivory;
            txtExtraBed.Location = new Point(183, 954);
            txtExtraBed.Name = "txtExtraBed";
            txtExtraBed.ReadOnly = true;
            txtExtraBed.Size = new Size(143, 31);
            txtExtraBed.TabIndex = 71;
            txtExtraBed.TabStop = false;
            // 
            // btnDeleteExtraBed
            // 
            btnDeleteExtraBed.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDeleteExtraBed.Location = new Point(183, 989);
            btnDeleteExtraBed.Name = "btnDeleteExtraBed";
            btnDeleteExtraBed.Size = new Size(70, 37);
            btnDeleteExtraBed.TabIndex = 72;
            btnDeleteExtraBed.Text = "Ta bort";
            btnDeleteExtraBed.UseVisualStyleBackColor = true;
            btnDeleteExtraBed.Click += btnDeleteExtraBed_Click;
            // 
            // lstDisplayBookings
            // 
            lstDisplayBookings.FormattingEnabled = true;
            lstDisplayBookings.ItemHeight = 25;
            lstDisplayBookings.Location = new Point(28, 149);
            lstDisplayBookings.Name = "lstDisplayBookings";
            lstDisplayBookings.Size = new Size(1098, 179);
            lstDisplayBookings.TabIndex = 73;
            // 
            // FrmHotelBooking
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1162, 1312);
            Controls.Add(lstDisplayBookings);
            Controls.Add(btnDeleteExtraBed);
            Controls.Add(txtExtraBed);
            Controls.Add(btnAddExtraBed);
            Controls.Add(btnNewBooking);
            Controls.Add(label1);
            Controls.Add(lblDateCheckOut);
            Controls.Add(dtpEndDate);
            Controls.Add(lblDateCheckIn);
            Controls.Add(dtpStartDate);
            Controls.Add(btnChooseBooking);
            Controls.Add(lblDueDays);
            Controls.Add(lblDue);
            Controls.Add(txtCustomer);
            Controls.Add(btnChooseRoom);
            Controls.Add(btnCLose);
            Controls.Add(btnChooseCustomer);
            Controls.Add(lstDisplayCustomers);
            Controls.Add(btnUpdateCustomer);
            Controls.Add(btnDeleteCustomer);
            Controls.Add(btnCreateCustomer);
            Controls.Add(txtPhone);
            Controls.Add(lblPhone);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtCustomerName);
            Controls.Add(lblCustomerName);
            Controls.Add(lblManageCustomer);
            Controls.Add(btnUpdateBooking);
            Controls.Add(btnDeleteBooking);
            Controls.Add(btnPayInvoice);
            Controls.Add(lblDisplayInvoiceAmount);
            Controls.Add(lblInvoiceAmount);
            Controls.Add(btnCreateBooking);
            Controls.Add(txtAmount);
            Controls.Add(lblAmount);
            Controls.Add(lblDisplayBookingDate);
            Controls.Add(lblBookingDate);
            Controls.Add(lblExtraBeds);
            Controls.Add(txtRoomType);
            Controls.Add(lblRoomType);
            Controls.Add(lblBookings);
            Controls.Add(cmbCustomers);
            Controls.Add(lblAvailableCustomers);
            Controls.Add(txtRoomNumber);
            Controls.Add(lblRoomID);
            Controls.Add(lstSearchResult);
            Controls.Add(btnSearchRooms);
            Controls.Add(nudNumberOfGuests);
            Controls.Add(lblBooking);
            Controls.Add(lblHotel);
            Name = "FrmHotelBooking";
            Text = "Hantera bokningar och kunder";
            ((System.ComponentModel.ISupportInitialize)nudNumberOfGuests).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHotel;
        private Label lblBooking;
        private NumericUpDown nudNumberOfGuests;
        private Button btnSearchRooms;
        private ListBox lstSearchResult;
        private Label lblRoomID;
        private TextBox txtRoomNumber;
        private Label lblAvailableCustomers;
        private ComboBox cmbCustomers;
        private Label lblBookings;
        private TextBox txtRoomType;
        private Label lblRoomType;
        private Label lblExtraBeds;
        private Label lblBookingDate;
        private Label lblDisplayBookingDate;
        private Label lblAmount;
        private TextBox txtAmount;
        private Button btnCreateBooking;
        private Label lblInvoiceAmount;
        private Label lblDisplayInvoiceAmount;
        private Button btnPayInvoice;
        private Button btnDeleteBooking;
        private Button btnUpdateBooking;
        private Label lblManageCustomer;
        private Label lblCustomerName;
        private TextBox txtCustomerName;
        private TextBox txtEmail;
        private Label lblEmail;
        private TextBox txtPhone;
        private Label lblPhone;
        private Button btnCreateCustomer;
        private Button btnDeleteCustomer;
        private Button btnUpdateCustomer;
        private ListBox lstDisplayCustomers;
        private Button btnChooseCustomer;
        private Button btnCLose;
        private Button btnChooseRoom;
        private TextBox txtCustomer;
        private Label lblDueDays;
        private Label lblDue;
        private Button btnChooseBooking;
        private DateTimePicker dtpStartDate;
        private Label lblDateCheckIn;
        private Label lblDateCheckOut;
        private DateTimePicker dtpEndDate;
        private Label label1;
        private Button btnNewBooking;
        private Button btnAddExtraBed;
        private TextBox txtExtraBed;
        private Button btnDeleteExtraBed;
        private ListBox lstDisplayBookings;
    }
}