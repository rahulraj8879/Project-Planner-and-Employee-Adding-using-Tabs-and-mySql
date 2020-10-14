using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPlanner
{
    public partial class Form1 : Form
    {

        // You need to have mysql installed and rnning with database schema name " projectplanner" and it should have 2 tables in it
        //one table named "employee" 
        //second table named "project"
        // column names for both can be seen in design view of both tabs and for date timepicker i have used "Datetime" type of mysql
        //rest all columns are of varchar datatye with name colm having varchar(100) and others varchar(45)
        // don.t forget to change connection string below with your mysql " servername;uid;port;pwd;databaseName "


       static string conn = "server=127.0.0.1;uid=root;port=3306;pwd=password;database=projectplanner;";
        MySqlConnection sqlcon = new MySqlConnection(conn);
        public Form1()
        {
            InitializeComponent();
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            comboBox3.Visible = true;
            button3.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        { // root@127.0.0.1:3306
          //  jdbc:mysql://127.0.0.1:3306/?user=root
          // "server=127.0.0.1;uid=root;port=3306;pwd=password;database=projectplanner;"
          //  @"Data Source=(RahulRaj)\projectPlanner;Initial Catalog=(projectplanner);Connect Timeout=30"


            textBox1.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            button3.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;




            ///// project tab display set to false on load
            textBox2.Visible = false;
            textBox3.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            label5.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;

            sqlcon.Open();
           
            
            
           
        }

        private void loadEmployee()
        {
            
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter("Select Name,Dept,Exp,Team from employee", sqlcon);
            DataTable dataSet = new DataTable();
            sqlDataAdapter.Fill(dataSet);

            foreach (DataRow row in dataSet.Rows)
            {

                //dataGridView11.Update();

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = row.Table;
                dataGridView11.DataSource = bindingSource;

                //dataGridView11.DataMember(row["Exp"], txtExp);
                //0 String txtName = (String)row["Name"];
                //MessageBox.Show(txtName);


            }
        }
        private void loadProject()
        {
            MySqlDataAdapter sqlDataAdapter2 = new MySqlDataAdapter("Select Name,Variant,StartDate,EndDate from project", sqlcon);

            DataTable dataSet2 = new DataTable();

            sqlDataAdapter2.Fill(dataSet2);






            foreach (DataRow row in dataSet2.Rows)
            {

                //dataGridView11.Update();

                BindingSource bindingSource2 = new BindingSource();
                bindingSource2.DataSource = row.Table;
                dataGridView2.DataSource = bindingSource2;

                //dataGridView11.DataMember(row["Exp"], txtExp);
                //0 String txtName = (String)row["Name"];
                //MessageBox.Show(txtName);


            }
        }

        private void dataGridView11_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if(textBox1.Text != "" && comboBox1.Text!="" && comboBox2.Text!= "" && comboBox3.Text != "")
            {
                // INSERT INTO `projectplanner`.`employee` (`idEmployee`, `Name`, `Dept`, `Exp`, `Team`) VALUES('2', 'er', 'fdcs', 'fs', 'gdf');
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter("Insert into `projectplanner`.`employee`( `Name`, `Dept`, `Exp`, `Team`) VALUES( '" + textBox1.Text + "', '" + comboBox1.Text + "', '" + comboBox2.Text + "', '" + comboBox3.Text + "'); ", sqlcon);
                DataTable dataSet = new DataTable();

                sqlDataAdapter.Fill(dataSet);






                foreach (DataRow row in dataSet.Rows)
                {

                    //dataGridView11.Update();

                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = row.Table;
                    dataGridView11.DataSource = bindingSource;

                    //dataGridView11.DataMember(row["Exp"], txtExp);
                    //0 String txtName = (String)row["Name"];
                    //MessageBox.Show(txtName);


                }
                MessageBox.Show(" Added a new Employee " +
                    "\n Click View Employee to view Entered Employee");
                
            }
            else
            {
                MessageBox.Show(" Enter all Values First ");
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Visible = true;
            textBox3.Visible = true;
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
            label5.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (textBox2.Text != ""&& textBox3.Text!=""&&dateTimePicker1.Value!= null&&dateTimePicker2.Value!= null)
            {
                //INSERT INTO `projectplanner`.`project` (`Name`, `Variant`, `StartDate`, `EndDate`, `projectId`) VALUES('af', 'sdf', 'vc', 'f', 'f');
                //+textBox1.Text + "

                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter("INSERT INTO `projectplanner`.`project` (`Name`, `Variant`, `StartDate`, `EndDate`) VALUES('" + textBox2.Text + "', '" + textBox3.Text + "', '" + dateTimePicker1.Text + "', '" + dateTimePicker2.Text + "');", sqlcon);
                DataTable dataSet = new DataTable();

                sqlDataAdapter.Fill(dataSet);



                foreach (DataRow row in dataSet.Rows)
                {

                    //dataGridView11.Update();

                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = row.Table;
                    dataGridView11.DataSource = bindingSource;

                    //dataGridView11.DataMember(row["Exp"], txtExp);
                    //0 String txtName = (String)row["Name"];
                    //MessageBox.Show(txtName);


                }
                MessageBox.Show("  Added a new Project " +
                    "\n Click View Project to view inserted Project");
                
            }
            else
            {
                MessageBox.Show("Insert all Fields");
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            loadProject();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            loadEmployee();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            sqlcon.Close();
            
        }
    }
}
