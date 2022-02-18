using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinqToSqlWinForms.Controllers;
using LinqToSqlWinForms.Views;

namespace LinqToSqlWinForms
{
    public partial class MainForm : Form {
        private QueriesController _queriesController;

        public MainForm() {
            InitializeComponent();
            _queriesController = new QueriesController();    
        }

        // при загрузке формы вывести персон
        private void MainForm_Load(object sender, EventArgs e) {
            PeopleView_Command(this, EventArgs.Empty);
        } // MainForm_Load


        private void PeopleView_Command(object sender, EventArgs e) {
            lblInfo.Text = "Таблица People: данные о сотрудниках предприятия";
            dgvMain.DataSource = _queriesController.QueryPeople();
        } // PeopleView_Command


        private void CityView_Command(object sender, EventArgs e) {
            lblInfo.Text = "Таблица Cities: данные о городах проживания сотрудников";
            dgvMain.DataSource = _queriesController.QueryCities();
        } // CityView_Command


        // создание и отображение окна вывода персон и городов
        private void PeopleCities_Command(object sender, EventArgs e) {
            PeopleCitiesForm peopleCitiesForm = new PeopleCitiesForm(_queriesController);

            peopleCitiesForm.ShowDialog();
        } // PeopleCities_Command


        private void Exit_Command(object sender, EventArgs e) => Application.Exit();
    } // class MainFoem
}
