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

namespace LinqToSqlWinForms.Views
{
    public partial class PeopleCitiesForm : Form
    {
        private QueriesController _queriesController;

        public PeopleCitiesForm(): this(new QueriesController()) { }
        public PeopleCitiesForm(QueriesController queriesController) {
            InitializeComponent();

            _queriesController = queriesController;
        } // PeopleCitiesForm 


        // При загрузке формы заполняем оба DataGridView
        private void PeopleCitiesForm_Load(object sender, EventArgs e) {

            // получиь данные из запроса и вывести в DataGridView
            DgvCities.DataSource = _queriesController.QueryCities();
            DgvPeople.DataSource = _queriesController.QueryPeopleCity();
        } // PeopleCitiesForm_Load

    } // class PeopleCitiesForm
}
