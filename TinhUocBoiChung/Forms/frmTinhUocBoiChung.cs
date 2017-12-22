using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinhUocBoiChung
{
    public partial class Form1 : Form
    {
        private int NumberA;
        private int NumberB;

        //Thông báo lỗi
        string errorMessage;

        public Form1()
        {
            InitializeComponent();
        }

        //Lệnh Tính
        private void btnResult_Click(object sender, EventArgs e)
        {
            //Lấy giá trị A và B
            string strA = txtNumberA.Text;
            string strB = txtNumberB.Text;

            //Kiểm tra A và B đã nhập đúng chưa ? Chưa thì hiện bảng thông báo lỗi
            if (IsValidNumber(strA, strB) == true)
            {
                //Kiểm tra nếu chưa hoặc đã lựa chọn phép tính gì
                if (!rdUCLN.Checked && !rdBCNN.Checked)
                {
                    MessageBox.Show("Vui long chon phep tinh.");
                    return;
                }

                int Result;
                if (rdUCLN.Checked)
                    Result = TimUCLN();
                else
                    Result = TimBCNN();

                //Hiển thị kết quả
                txtResult.Text = Result.ToString();
            }
            else
                MessageBox.Show(errorMessage);
        }

        //Hàm tính Ước chung lớn nhất & Bội chung nhỏ nhất
        private int TimUCLN()
        {
            while (NumberA != NumberB)
            {
                if (NumberA > NumberB)
                    NumberA -= NumberB;
                else
                    NumberB -= NumberA;
            }
            return NumberA;
        }

        private int TimBCNN()
        {
            return NumberA * NumberB / TimUCLN();
        }

        /// <summary>
        /// Hàm kiểm tra 2 số nhập vào
        /// return true: Nếu 2 số hợp lệ
        /// return false: Nếu có ít nhất 1 số không hợp lệ
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private  bool IsValidNumber(string a, string b)
        {
            errorMessage = "";

            //Lỗi không nhập giá trị
            if (string.IsNullOrEmpty(a))
            {
                errorMessage += "Vui long nhap so A!\n";
            }

            if (string.IsNullOrEmpty(b))
            {
                errorMessage += "Vui long nhap so B!\n";
            }

            //Lỗi nhập giá trị không hợp lệ
            try
            {
                NumberA = int.Parse(a);
                NumberB = int.Parse(b);
            }
            catch (Exception)
            {
                errorMessage += "Gia tri da nhap khong hop le!\n";
            }

            return (errorMessage == "") ? true : false;
        }

        //Lệnh Thoát
        private void btnExit_Click(object sender, EventArgs e)
        {
        //    Form1.Visible(false);
        }
    }
}
