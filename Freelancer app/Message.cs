using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Freelancer_app
{
    public partial class Message : Form
    {
        private int _userId;
        private string _email;
        public Message(int userId, string email)
        {
            InitializeComponent();
            _userId = userId;
            _email = email;
        }

        private void Message_Load(object sender, EventArgs e)
        {

        }
    }
}
