namespace MppProjectCSharp.GUI
{
    partial class MainForm
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
            tableFlights = new DataGridView();
            colDest = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            colTime = new DataGridViewTextBoxColumn();
            colAirport = new DataGridViewTextBoxColumn();
            colSeats = new DataGridViewTextBoxColumn();
            txtDestination = new TextBox();
            datePickerDeparture = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            btnSearch = new Button();
            tableSearchFlights = new DataGridView();
            txtClient = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txtAddress = new TextBox();
            label5 = new Label();
            numSeats = new NumericUpDown();
            label6 = new Label();
            btnBuy = new Button();
            txtTourists = new TextBox();
            colDestSearch = new DataGridViewTextBoxColumn();
            colTimeSearch = new DataGridViewTextBoxColumn();
            colSeatsSearch = new DataGridViewTextBoxColumn();
            colSearchId = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)tableFlights).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tableSearchFlights).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSeats).BeginInit();
            SuspendLayout();
            // 
            // tableFlights
            // 
            tableFlights.AllowUserToAddRows = false;
            tableFlights.AllowUserToDeleteRows = false;
            tableFlights.AllowUserToOrderColumns = true;
            tableFlights.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableFlights.Columns.AddRange(new DataGridViewColumn[] { colDest, colDate, colTime, colAirport, colSeats });
            tableFlights.Location = new Point(12, 12);
            tableFlights.Name = "tableFlights";
            tableFlights.ReadOnly = true;
            tableFlights.RowHeadersWidth = 51;
            tableFlights.RowTemplate.Height = 29;
            tableFlights.Size = new Size(632, 244);
            tableFlights.TabIndex = 0;
            tableFlights.CellFormatting += tableFlights_CellFormatting;
            // 
            // colDest
            // 
            colDest.HeaderText = "Destination";
            colDest.MinimumWidth = 6;
            colDest.Name = "colDest";
            colDest.ReadOnly = true;
            colDest.Width = 125;
            // 
            // colDate
            // 
            colDate.HeaderText = "DepartureDate";
            colDate.MinimumWidth = 6;
            colDate.Name = "colDate";
            colDate.ReadOnly = true;
            colDate.Width = 125;
            // 
            // colTime
            // 
            colTime.HeaderText = "departureTime";
            colTime.MinimumWidth = 6;
            colTime.Name = "colTime";
            colTime.ReadOnly = true;
            colTime.Width = 125;
            // 
            // colAirport
            // 
            colAirport.HeaderText = "Airport";
            colAirport.MinimumWidth = 6;
            colAirport.Name = "colAirport";
            colAirport.ReadOnly = true;
            colAirport.Width = 125;
            // 
            // colSeats
            // 
            colSeats.HeaderText = "No. Seats";
            colSeats.MinimumWidth = 6;
            colSeats.Name = "colSeats";
            colSeats.ReadOnly = true;
            colSeats.Width = 125;
            // 
            // txtDestination
            // 
            txtDestination.Location = new Point(130, 295);
            txtDestination.Name = "txtDestination";
            txtDestination.Size = new Size(200, 27);
            txtDestination.TabIndex = 1;
            // 
            // datePickerDeparture
            // 
            datePickerDeparture.Location = new Point(130, 357);
            datePickerDeparture.Name = "datePickerDeparture";
            datePickerDeparture.Size = new Size(200, 27);
            datePickerDeparture.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 298);
            label1.Name = "label1";
            label1.Size = new Size(85, 20);
            label1.TabIndex = 3;
            label1.Text = "Destination";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 362);
            label2.Name = "label2";
            label2.Size = new Size(112, 20);
            label2.TabIndex = 4;
            label2.Text = "Departure Date";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(107, 420);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // tableSearchFlights
            // 
            tableSearchFlights.AllowUserToAddRows = false;
            tableSearchFlights.AllowUserToDeleteRows = false;
            tableSearchFlights.AllowUserToOrderColumns = true;
            tableSearchFlights.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableSearchFlights.Columns.AddRange(new DataGridViewColumn[] { colDestSearch, colTimeSearch, colSeatsSearch, colSearchId });
            tableSearchFlights.Location = new Point(668, 12);
            tableSearchFlights.Name = "tableSearchFlights";
            tableSearchFlights.ReadOnly = true;
            tableSearchFlights.RowHeadersWidth = 51;
            tableSearchFlights.RowTemplate.Height = 29;
            tableSearchFlights.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tableSearchFlights.Size = new Size(506, 244);
            tableSearchFlights.TabIndex = 6;
            tableSearchFlights.CellFormatting += tableFlights_CellFormatting;
            // 
            // txtClient
            // 
            txtClient.Location = new Point(546, 299);
            txtClient.Name = "txtClient";
            txtClient.Size = new Size(200, 27);
            txtClient.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(431, 302);
            label3.Name = "label3";
            label3.Size = new Size(91, 20);
            label3.TabIndex = 8;
            label3.Text = "Client Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(431, 357);
            label4.Name = "label4";
            label4.Size = new Size(59, 20);
            label4.TabIndex = 10;
            label4.Text = "Tourists";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(899, 295);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(233, 27);
            txtAddress.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(807, 295);
            label5.Name = "label5";
            label5.Size = new Size(62, 20);
            label5.TabIndex = 12;
            label5.Text = "Address";
            // 
            // numSeats
            // 
            numSeats.Location = new Point(899, 355);
            numSeats.Name = "numSeats";
            numSeats.Size = new Size(150, 27);
            numSeats.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(807, 357);
            label6.Name = "label6";
            label6.Size = new Size(71, 20);
            label6.TabIndex = 14;
            label6.Text = "No. Seats";
            // 
            // btnBuy
            // 
            btnBuy.Location = new Point(929, 420);
            btnBuy.Name = "btnBuy";
            btnBuy.Size = new Size(94, 29);
            btnBuy.TabIndex = 15;
            btnBuy.Text = "Buy Ticket";
            btnBuy.UseVisualStyleBackColor = true;
            btnBuy.Click += btnBuy_Click;
            // 
            // txtTourists
            // 
            txtTourists.Location = new Point(496, 354);
            txtTourists.Name = "txtTourists";
            txtTourists.Size = new Size(305, 27);
            txtTourists.TabIndex = 16;
            // 
            // colDestSearch
            // 
            colDestSearch.HeaderText = "Destination";
            colDestSearch.MinimumWidth = 6;
            colDestSearch.Name = "colDestSearch";
            colDestSearch.ReadOnly = true;
            colDestSearch.Width = 125;
            // 
            // colTimeSearch
            // 
            colTimeSearch.HeaderText = "Departure Time";
            colTimeSearch.MinimumWidth = 6;
            colTimeSearch.Name = "colTimeSearch";
            colTimeSearch.ReadOnly = true;
            colTimeSearch.Width = 125;
            // 
            // colSeatsSearch
            // 
            colSeatsSearch.HeaderText = "Available Seats";
            colSeatsSearch.MinimumWidth = 6;
            colSeatsSearch.Name = "colSeatsSearch";
            colSeatsSearch.ReadOnly = true;
            colSeatsSearch.Width = 125;
            // 
            // colSearchId
            // 
            colSearchId.HeaderText = "ID";
            colSearchId.MinimumWidth = 6;
            colSearchId.Name = "colSearchId";
            colSearchId.ReadOnly = true;
            colSearchId.Width = 125;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1186, 544);
            Controls.Add(txtTourists);
            Controls.Add(btnBuy);
            Controls.Add(label6);
            Controls.Add(numSeats);
            Controls.Add(label5);
            Controls.Add(txtAddress);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtClient);
            Controls.Add(tableSearchFlights);
            Controls.Add(btnSearch);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(datePickerDeparture);
            Controls.Add(txtDestination);
            Controls.Add(tableFlights);
            Name = "MainForm";
            Text = "MainForm";
            FormClosed += MainForm_FormClosed;
            Shown += MainForm_Shown;
            ((System.ComponentModel.ISupportInitialize)tableFlights).EndInit();
            ((System.ComponentModel.ISupportInitialize)tableSearchFlights).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSeats).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView tableFlights;
        private DataGridViewTextBoxColumn colDest;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colTime;
        private DataGridViewTextBoxColumn colAirport;
        private DataGridViewTextBoxColumn colSeats;
        private TextBox txtDestination;
        private DateTimePicker datePickerDeparture;
        private Label label1;
        private Label label2;
        private Button btnSearch;
        private DataGridView tableSearchFlights;
        private TextBox txtClient;
        private Label label3;
        private Label label4;
        private TextBox txtAddress;
        private Label label5;
        private NumericUpDown numSeats;
        private Label label6;
        private Button btnBuy;
        private TextBox txtTourists;
        private DataGridViewTextBoxColumn colDestSearch;
        private DataGridViewTextBoxColumn colTimeSearch;
        private DataGridViewTextBoxColumn colSeatsSearch;
        private DataGridViewTextBoxColumn colSearchId;
    }
}