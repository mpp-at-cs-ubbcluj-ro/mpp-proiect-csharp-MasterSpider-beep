using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemaC.domain;
using MppProjectCSharp.services;
using MppProjectCSharp.Exceptions;

namespace MppProjectCSharp.GUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private Service service;
        private User user;
        private DataTable flightsTableSource = new DataTable("AllFlights");
        private DataTable flightsSearchSource = new DataTable("FilteredFlights");

        public User User { set { user = value; } }

        public MainForm(Service service)
        {
            InitializeComponent();
            this.service = service;

            initialize();
        }

        private void initialize()
        {
            resetInputs();

            flightsTableSource.Columns.Add("destination", typeof(string));
            flightsTableSource.Columns.Add("departureDate", typeof(DateOnly));
            flightsTableSource.Columns.Add("departureTime", typeof(TimeOnly));
            flightsTableSource.Columns.Add("airport", typeof(string));
            flightsTableSource.Columns.Add("noSeats", typeof(int));

            tableFlights.AutoGenerateColumns = false;
            tableFlights.DataSource = flightsTableSource;
            colDest.DataPropertyName = "destination";
            colDate.DataPropertyName = "departureDate";
            colTime.DataPropertyName = "departureTime";
            colAirport.DataPropertyName = "airport";
            colSeats.DataPropertyName = "noSeats";

            flightsSearchSource.Columns.Add("destination", typeof(string));
            flightsSearchSource.Columns.Add("departureTime", typeof(TimeOnly));
            flightsSearchSource.Columns.Add("noSeats", typeof(int));
            flightsSearchSource.Columns.Add("flightId", typeof(int));

            tableSearchFlights.AutoGenerateColumns = false;
            tableSearchFlights.DataSource = flightsSearchSource;
            colDestSearch.DataPropertyName = "destination";
            colTimeSearch.DataPropertyName = "departureTime";
            colSeatsSearch.DataPropertyName = "noSeats";
            colSearchId.DataPropertyName = "flightId";


            txtTourists.PlaceholderText = "Write the names separated by ;";
            numSeats.Minimum = 0;
            numSeats.Maximum = 100;
        }

        private void loadAllFlights()
        {
            flightsTableSource.Rows.Clear();
            List<Flight> flights = service.getAllFlights();
            foreach (Flight flight in flights)
            {
                flightsTableSource.Rows.Add(flight.Destination, flight.DepartureDate, flight.DepartureTime, flight.Airport, flight.AvailableSeats);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            loadAllFlights();
        }

        private void tableFlights_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value is TimeOnly)
            {
                TimeOnly time = (TimeOnly)e.Value;
                if (time == TimeOnly.MinValue)
                {
                    e.Value = "00:00";
                    e.FormattingApplied = true;
                }
            }
        }

        private void resetInputs()
        {
            txtDestination.Text = string.Empty;
            datePickerDeparture.Text = string.Empty;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtDestination.Text.Length == 0 && datePickerDeparture.Checked == false)
            {
                MessageBox.Show("Please complete the required fileds!");
                return;
            }
            string? destination = null;
            DateOnly? departureDate = null;
            if (txtDestination.Text.Length != 0)
            {
                destination = txtDestination.Text;
            }
            if (datePickerDeparture.Checked)
            {
                departureDate = DateOnly.Parse(datePickerDeparture.Value.ToShortDateString());
            }
            var flights = service.getAllFilteredFlights(destination, departureDate);

            flightsSearchSource.Rows.Clear();
            foreach (var flight in flights)
            {
                flightsSearchSource.Rows.Add(flight.Destination, flight.DepartureTime, flight.AvailableSeats, flight.Id);
            }
        }

        private void resetBuyInputs()
        {
            txtAddress.Text = string.Empty;
            txtClient.Text = string.Empty;
            txtTourists.Text = string.Empty;
            numSeats.Value = 0;
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (tableSearchFlights.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a flight!");
                return;
            }
            if (txtClient.Text.Trim().Length == 0 || txtAddress.Text.Trim().Length == 0 || txtTourists.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please complete all the required fileds!");
                return;
            }
            string clientName = txtClient.Text.Trim();
            int flightId = (int)tableSearchFlights.SelectedRows[0].Cells[3].Value;
            string address = txtAddress.Text.Trim();
            string tourists = txtTourists.Text.Trim();
            int noSeats = (int)numSeats.Value;
            try
            {
                service.buyTicket(flightId, clientName, tourists, address, noSeats);
                MessageBox.Show("Ticket bought successfully!");
                loadAllFlights();
                btnSearch_Click(sender, e);
                resetBuyInputs();
            }
            catch (ServiceException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
