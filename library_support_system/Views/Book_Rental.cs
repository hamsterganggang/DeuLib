using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library_support_system.Views
{
    public partial class Book_Rental : Form
    {
        public Book_Rental()
        {
            InitializeComponent();
        }

        private void book_rental_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();

            // 컬럼의 속성 설정
            buttonColumn.Name = "ButtonColumn"; // 컬럼의 이름
            buttonColumn.HeaderText = "동작"; // 컬럼 헤더에 표시될 텍스트
            buttonColumn.Text = "클릭"; // 버튼에 표시될 텍스트
            buttonColumn.UseColumnTextForButtonValue = true; // 버튼에 Text 속성값 사용

            // DataGridView에 컬럼 추가
            dataGridView1.Columns.Add(buttonColumn);

            // 예시 데이터 추가
            dataGridView1.Rows.Add("데이터1", "데이터2");
            dataGridView1.Rows.Add("데이터3", "데이터4");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
