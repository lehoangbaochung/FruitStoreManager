using FruitStoreManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FruitStoreManager.Databases
{
    class Execute
    {
        static readonly DataTable data = new DataTable();

        public static void Select(DataGridView dataGridView, string value, string table)
        {
            new SqlDataAdapter("Select " + value + " from " + table, Connect.ConnectString()).Fill(data);
            dataGridView.DataSource = data;
        }

        public static DataTable SelectWhere(string value, string table, string where)
        {
            new SqlDataAdapter("Select " + value + " from " + table + " where " + where, Connect.ConnectString()).Fill(data);
            return data;
        }

        public static void Insert(DataGridView dataGridView, string table)
        {
            string values = null;
            string value;

            //for (int i = element.TableRowsCount; i < element.Table.RowCount; i++)
            //{
            //    for (int j = 0; j < element.Table.ColumnCount; j++)
            //    {
            //        if (element.Table.Rows[i].Cells[j].Value == null) val = "";
            //        else val = element.Table.Rows[i].Cells[j].Value.ToString();

            //        values += "N'" + val + "',";
            //        values = values.Substring(0, values.Length - 2);

            //        SqlCommand cmd = new SqlCommand("Insert into " + table + "values (" + values + ")", Connect.ConnectString());
            //        cmd.ExecuteNonQuery();
            //    }
            //}

            for (int i = 1; i < dataGridView.ColumnCount; i++)
            {
                if (dataGridView.CurrentRow.Cells[i].Value == null) value = null; // impo
                else value = dataGridView.CurrentRow.Cells[i].Value.ToString();

                values += "N'" + value + "',";
            }

            values = values.Substring(0, values.Length - 1);

            new SqlDataAdapter("Insert into " + table + " values (" + values + ")", Connect.ConnectString()).Fill(data);
            dataGridView.DataSource = data;
        }

        public static void Update(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, Connect.ConnectString());

            cmd.ExecuteNonQuery();
        }

        public static void Delete(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, Connect.ConnectString());

            cmd.ExecuteNonQuery();
        }
    }
}
